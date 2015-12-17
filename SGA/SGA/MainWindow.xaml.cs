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

namespace SGA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Left = getPos("Left");
            Application.Current.MainWindow.Top = getPos("Top");
        }

        public static double getPos(string leftortop)
        {
            double largeur_ecran = SystemParameters.PrimaryScreenWidth;
            double hauteur_ecran = SystemParameters.PrimaryScreenHeight;
            double largeur_main = Application.Current.MainWindow.Width;
            double hauteur_main = Application.Current.MainWindow.Height;
            double pos_left_ecran = (largeur_ecran / 2) - (largeur_main / 2);
            double pos_top_ecran = (hauteur_ecran / 2) - (hauteur_main / 2);

            if (leftortop == "Left")
            {
                return pos_left_ecran;
            }
            else
                return pos_top_ecran;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            MenuClient menuClient = new MenuClient();
            menuClient.Left = getPos("Left");
            menuClient.Top =  getPos("Top");
            menuClient.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Left = getPos("Left");
            menuAdmin.Top = getPos("Top");
            menuAdmin.ShowDialog();
        }


    }
}
