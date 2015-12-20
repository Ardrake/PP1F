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
            double largeur_ecran = SystemParameters.PrimaryScreenWidth;
            double hauteur_ecran = SystemParameters.PrimaryScreenHeight;
            double largeur_main = Application.Current.MainWindow.Width;
            double hauteur_main = Application.Current.MainWindow.Height;
            double pos_left_ecran = (largeur_ecran / 2) - (largeur_main / 2);
            double pos_top_ecran = (hauteur_ecran / 2) - (hauteur_main / 2);
            Application.Current.MainWindow.Left = pos_left_ecran;
            Application.Current.MainWindow.Top = pos_top_ecran;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            MenuClient menuClient = new MenuClient();
            menuClient.Left = Application.Current.MainWindow.Left;
            menuClient.Top = Application.Current.MainWindow.Top;
            menuClient.Height = Application.Current.MainWindow.Height;
            menuClient.Width = Application.Current.MainWindow.Width;
            menuClient.ShowDialog();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Left = Application.Current.MainWindow.Left;
            menuAdmin.Top = Application.Current.MainWindow.Top;
            menuAdmin.Height = Application.Current.MainWindow.Height;
            menuAdmin.Width = Application.Current.MainWindow.Width;
            menuAdmin.ShowDialog();
        }


    }


}
