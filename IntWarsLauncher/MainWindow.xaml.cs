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
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua", texto);
                for (int i = 1; i <= 100; i++)
                {
                    ProgressBar1.Value = i;
                    System.Threading.Thread.Sleep(10);
                    textBlock.Text = i + "%";
                    DoEvents();
                    
                }
                ProgressBar1.Foreground = Brushes.Green;

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

        private void ChangeName()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[1].Split('=');
            string[] aspas = iguais[1].Split('"');
            texto = texto.Replace(aspas[1], textBox.Text);
        }

        private void ChangeChampion()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[2].Split('=');
            string[] aspas = iguais[1].Split('"');
            texto = texto.Replace(aspas[1], textBox_Copy.Text);
        }
    }
}
