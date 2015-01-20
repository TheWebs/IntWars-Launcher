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

namespace IntWarsLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            texto = File.ReadAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua");
            ChangeRank();

    }

        private void ChangeRank()
        {
            // Function 100% complete
            string[] virgulas = texto.Split(',');
            string[] iguais = virgulas[0].Split('=');
            string[] aspas = iguais[3].Split('"');
            texto = texto.Replace(aspas[1], comboBox_Copy.SelectedValue.ToString().ToUpper());
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\lua\\config.lua", texto);
        }
    }
}
