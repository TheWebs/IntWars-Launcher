using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;

namespace IntWarsLauncher
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// Made by TheWebs :DDD
    /// </summary>
    public partial class SplashScreen : Window
    {
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
        public SplashScreen()
        {
            InitializeComponent();
            this.Show();
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Icons"))
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run("Icons directory found!")));
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Icons");
                richTextBox.Document.Blocks.Add(new Paragraph(new Run("Icons directory not found!")));
            }
            int i = -1;
            WebClient cliente = new WebClient();
            WebClient joao = new WebClient();
            string text = joao.DownloadString("http://ddragon.leagueoflegends.com/realms/euw.json").ToString();
            string[] URL = text.Split(':');
            // url[8] da me isto "4.21.5","l"298
            string[] bom = URL[8].Split('"');
            // bom[1] da me isto 4.21.5
           
                while(i<=800)
                {
                try
                {
                    i++;
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\Icons\\" + i + ".png"))
                    {
                        richTextBox.Document.Blocks.Add(new Paragraph(new Run("Icon " + i + " found!")));
                        richTextBox.ScrollToEnd();
                        ProgressBar1.Value = i * 0.125;
                        textBlock1.Text = i*0.125 + "%";
                        DoEvents();
                    }
                    else
                    {
                        cliente.DownloadFile("http://ddragon.leagueoflegends.com/cdn/" + bom[1] + "/img/profileicon/" + i + ".png ", Directory.GetCurrentDirectory() + "\\Icons\\" + i + ".png");// AQUIAQUI
                        richTextBox.Document.Blocks.Add(new Paragraph(new Run("Icon " + i + " downloaded successfully!")));
                        richTextBox.ScrollToEnd();
                        ProgressBar1.Value = i * 0.125;
                        textBlock1.Text = i*0.125 + "%";
                        DoEvents();
                    }
                }
                catch (WebException Ex)
                {
                    richTextBox.Document.Blocks.Add(new Paragraph(new Run("Icon " + i + " doens't exist!")));
                    richTextBox.ScrollToEnd();
                    i++;
                    ProgressBar1.Value = i * 0.125;
                    textBlock1.Text = i*0.125 + "%";
                    DoEvents();
                }
            }
            
            MainWindow Comeca = new MainWindow();
            Comeca.Show();
            this.Close();
            /*WebClient joao = new WebClient();
            string text = joao.DownloadString("http://ddragon.leagueoflegends.com/realms/euw.json").ToString();
            string[] URL = text.Split(':');
            // url[8] da me isto "4.21.5","l"298
            string[] bom = URL[8].Split('"');
            // bom[1] da me isto 4.21.5
            WebClient joao2 = new WebClient();
            joao2.DownloadFile("http://ddragon.leagueoflegends.com/cdn/" + bom[1] + "/img/profileicon/" + ICON + ".png ", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Icon.png");
     */  
    }
    }
}
