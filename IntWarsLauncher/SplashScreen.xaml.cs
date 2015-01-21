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

namespace IntWarsLauncher
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
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
