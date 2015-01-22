using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace IntWarsLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Started by TheWebs ║▌║█║▌│║▌║▌█
    /// </summary>
    public partial class MainWindow : Window
    {

        string texto = File.ReadAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua");
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(Directory.GetCurrentDirectory() + "data.iwl"))
            {
                string settings = File.ReadAllText(Directory.GetCurrentDirectory() + "data.iwl");
                string[] settingsbons = settings.Split('}');
                textBox.Text = settingsbons[0];
                textBox_Copy.Text = settingsbons[1];
                comboBox.Items.Add("0");
                comboBox.Items.Add("1");
                comboBox.SelectedIndex = Convert.ToInt32(settingsbons[2]);
                comboBox_Copy.Items.Add("Bronze");
                comboBox_Copy.Items.Add("Silver");
                comboBox_Copy.Items.Add("Gold");
                comboBox_Copy.Items.Add("Platinum");
                comboBox_Copy.Items.Add("Diamond");
                comboBox_Copy.Items.Add("Challenger");
                comboBox_Copy.SelectedIndex = Convert.ToInt32(settingsbons[3]);
            }

            else
            {
                comboBox.Items.Add("0");
                comboBox.Items.Add("1");
                comboBox.SelectedIndex = 1;
                comboBox_Copy.Items.Add("Bronze");
                comboBox_Copy.Items.Add("Silver");
                comboBox_Copy.Items.Add("Gold");
                comboBox_Copy.Items.Add("Platinum");
                comboBox_Copy.Items.Add("Diamond");
                comboBox_Copy.Items.Add("Challenger");
                comboBox_Copy.SelectedIndex = 4;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
                DragMove();

        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox.Text == "") || (textBox_Copy.Text == "") || (textBox_Copy.Text.Contains("1") == true) || (textBox_Copy.Text.Contains("2") == true) || (textBox_Copy.Text.Contains("3") == true) || (textBox_Copy.Text.Contains("4") == true) || (textBox_Copy.Text.Contains("5") == true) || (textBox_Copy.Text.Contains("6") == true) || (textBox_Copy.Text.Contains("7") == true) || (textBox_Copy.Text.Contains("8") == true) || (textBox_Copy.Text.Contains("9") == true))
            {
                MessageBox.Show("Please check if you didn't leave any field in blank or numbers in champion!", "IntWars Launcher - Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                texto = File.ReadAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua");
                ChangeRank();
                ChangeName();
                ChangeChampion();
                ChangeSkin();
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua", texto);
                ProgressBar1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF424242"));
                textBlock.Foreground = Brushes.Black;
                for (int i = 1; i <= 100; i++)
                {
                    if (i == 45)
                    {
                        textBlock.Foreground = Brushes.White;
                        ProgressBar1.Value = i;
                        System.Threading.Thread.Sleep(10);
                        textBlock.Text = i + "%";
                        DoEvents();
                    }
                    else

                    {
                        ProgressBar1.Value = i;
                        System.Threading.Thread.Sleep(10);
                        textBlock.Text = i + "%";
                        DoEvents();
                    }

                }
                //AQUI
                ProgressBar1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF424242"));

            }

        }

        private void ChangeRank()
        {
            // Function 100% complete  What it does: Theoretically it changes the player's rank; Practically it changes the loading border
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[0].Split('=');
            string[] aspas = iguais[3].Split('"');
            texto = texto.Replace(aspas[1], comboBox_Copy.SelectedValue.ToString().ToUpper());

        }
        // Function 100% complete
        private void ChangeName()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[1].Split('=');
            string[] aspas = iguais[1].Split('"');
            texto = texto.Replace(aspas[1], textBox.Text);
        }
        // Function 100% complete
        private void ChangeChampion()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[2].Split('=');
            string[] aspas = iguais[1].Split('"');
            texto = texto.Replace(aspas[1], textBox_Copy.Text);
        }
        private void ChangeSkin()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[4].Split('=');
            texto = texto.Replace(iguais[1], " " + comboBox.SelectedItem.ToString());
        }

        

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Start_MouseEnter(object sender, MouseEventArgs e)
        {
            Start.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF424242"));
        }

        private void Start_MouseLeave(object sender, MouseEventArgs e)
        {
            Start.Foreground = Start.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFAFAFA"));
        }

        private void label_Copy4_MouseUp(object sender, MouseButtonEventArgs e)
        {

            File.WriteAllText(Directory.GetCurrentDirectory() + "data.iwl", textBox.Text + "}" + textBox_Copy.Text + "}" + comboBox.SelectedIndex + "}" + comboBox_Copy.SelectedIndex);
            Advanced advanced = new Advanced();
            advanced.Show();
            this.Hide();
        }

        /*
        CODDEEEE TAKEN FROMM MY OTHER PROJECTT LOLINFO! :PPP  It had the purpose of downloading the summoner's icon so it could be displayed!
        public void ObterIcons()
        {
            WebClient joao = new WebClient();
            string text = joao.DownloadString("http://ddragon.leagueoflegends.com/realms/euw.json").ToString();        From this line to 183 is so usefulll ^^
            string[] URL = text.Split(':');
            // url[8] da me isto "4.21.5","l"298
            string[] bom = URL[8].Split('"');
            // bom[1] da me isto 4.21.5
            WebClient joao2 = new WebClient();
            joao2.DownloadFile("http://ddragon.leagueoflegends.com/cdn/" + bom[1] + "/img/profileicon/" + ICON + ".png ", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Icon.png");
            FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Icon.png", FileMode.Open, FileAccess.Read);
            pictureBox1.BackgroundImage = Image.FromStream(fileStream);
            fileStream.Close();
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Icon.png");

        }
        */
    }
}
