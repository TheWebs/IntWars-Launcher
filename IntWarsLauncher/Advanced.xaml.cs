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
using System.Windows.Shapes;
using System.IO;
using System.IO.Path;
using System.Windows.Threading;

namespace IntWarsLauncher
{
    /// <summary>
    /// Interaction logic for Advanced.xaml
    /// </summary>
    public partial class Advanced : Window
    {
        string texto = File.ReadAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua");
        public Advanced()
        {
            InitializeComponent();
           
            if (File.Exists(Directory.GetCurrentDirectory() + "data2.iwl"))
            {
                string settings = File.ReadAllText(Directory.GetCurrentDirectory() + "data2.iwl");
                string[] settingsbons = settings.Split('}');
                foreach (string joao in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Icons"))
                {
                    comboBox_Copy3.Items.Add(GetFileNameWithoutExtension(joao));
                }
                comboBox_Copy3.Items.Remove("Thumbs");
                comboBox_Copy1.Items.Add("Yellow");
                comboBox_Copy1.Items.Add("Blue");
                comboBox_Copy1.Items.Add("Red");
                comboBox_Copy1.Items.Add("Green");
                comboBox_Copy2.Items.Add("BLUE");
                comboBox_Copy2.Items.Add("PURPLE");
                comboBox_Copy1.SelectedIndex = Convert.ToInt32(settingsbons[0]);
                comboBox_Copy3.SelectedIndex = Convert.ToInt32(settingsbons[1]);
                comboBox_Copy2.SelectedIndex = Convert.ToInt32(settingsbons[2]);
            }

            else
            {
                foreach (string joao in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Icons"))
                {
                    comboBox_Copy3.Items.Add(GetFileNameWithoutExtension(joao));
                }
                comboBox_Copy3.Items.Remove("Thumbs");
                comboBox_Copy1.Items.Add("Yellow");
                comboBox_Copy1.Items.Add("Blue");
                comboBox_Copy1.Items.Add("Red");
                comboBox_Copy1.Items.Add("Green");
                comboBox_Copy2.Items.Add("BLUE");
                comboBox_Copy2.Items.Add("PURPLE");
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

        private void Start_MouseEnter(object sender, MouseEventArgs e)
        {
            Start.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF424242"));
        }

        private void Start_MouseLeave(object sender, MouseEventArgs e)
        {
            Start.Foreground = Start.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFAFAFA"));
        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
                texto = File.ReadAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua");
                ChangeRibbon();
                ChangeTeam();
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua", texto);
                ProgressBar1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF424242"));
                textBlock_Copy.Foreground = Brushes.Black;
                for (int i = 1; i <= 100; i++)
                {
                    if (i == 45)
                    {
                        textBlock_Copy.Foreground = Brushes.White;
                        ProgressBar1.Value = i;
                        System.Threading.Thread.Sleep(10);
                        textBlock_Copy.Text = i + "%";
                        DoEvents();
                    }
                    else

                    {
                        ProgressBar1.Value = i;
                        System.Threading.Thread.Sleep(10);
                        textBlock_Copy.Text = i + "%";
                        DoEvents();
                    }

                }
                //AQUI
                ProgressBar1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF424242"));

            }
        private void ChangeRibbon()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[7].Split('=');
            //indexes 0-->1(yellow) 1-->2(blue) 2-->3(red) 3-->4(green)
            decimal numero = Convert.ToDecimal(comboBox_Copy1.SelectedIndex.ToString());
            numero = numero + 1;
            texto = texto.Replace(iguais[1], " " + numero.ToString());
        }

        private void ChangeIcon()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[4].Split('=');
            texto = texto.Replace(iguais[1], " " + comboBox_Copy3.SelectedItem.ToString());
        }

        private void ChangeTeam()
        {
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[3].Split('=');
            string[] aspas = iguais[1].Split('"');
            texto = texto.Replace(aspas[1], comboBox_Copy2.SelectedItem.ToString().ToUpper());
        }

        private void label_Copy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + "data2.iwl", comboBox_Copy1.SelectedIndex + "}" + comboBox_Copy3.SelectedIndex + "}" + comboBox_Copy2.SelectedIndex );
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Hide();
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void comboBox_Copy3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + comboBox_Copy3.SelectedItem.ToString() + ".png");
            logo.EndInit();
            image.Source = logo;
        }
    }
    }

