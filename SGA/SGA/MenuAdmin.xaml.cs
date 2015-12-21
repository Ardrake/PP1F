using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGA
{
    /// <summary>
    /// Interaction logic for MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void button_Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_MettreHorsService(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void button_Rapport(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Impression des Rapport");
        }

        private void button_depotGuichet(object sender, RoutedEventArgs e)
        {
            double largeur_ecran = SystemParameters.PrimaryScreenWidth;
            double hauteur_ecran = SystemParameters.PrimaryScreenHeight;
            double largeur_main = Application.Current.MainWindow.Width;
            double hauteur_main = Application.Current.MainWindow.Height;
            int pos_left_ecran = ((int)largeur_ecran / 2) - ((int)largeur_main / 2) + 50;
            int pos_top_ecran = ((int)hauteur_ecran / 2) - ((int)hauteur_main / 2) + 50;

            string input = Interaction.InputBox("Montant du dépot (Minimum de 5000$)", "Dépot Guichet", "5000", pos_left_ecran, pos_top_ecran);

        }

        private void button_PaiementInteret(object sender, RoutedEventArgs e)
        {
            MessageBoxResult paiementInteret = MessageBox.Show("Voulez vous faire le paiement des interets", "Paiement des interets", MessageBoxButton.YesNo);
            if (paiementInteret == MessageBoxResult.Yes)
            {
                MessageBox.Show("Paiement des interets");
            }
        }
    }
}
