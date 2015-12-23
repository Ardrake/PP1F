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

        int nbressaie = 0;
        public MainWindow()
        {

            // initialise les clients
            Program.OuvrirFichier("Clients.txt");

            // initialise les comptes
            Program.OuvrirFichier("Comptes.txt");

            // Dépose 5000$ dans le guichet si la limite le permet
            Program.DepotGuichet();
            

            InitializeComponent();
            // Calcul position de l'ecran - Centré
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

        private void button_Login(object sender, RoutedEventArgs e)
        {
            string nomClient = textboxNomClient.Text;
            string nipClient = textboxPassword.Password;

            Client clientLogin = DataGuichet.listeClients.Find(x => x.NomClient == nomClient);
            if (clientLogin == null)
            {
                MessageBox.Show("Client non trouvé");
            }
            else if (clientLogin.NIP == textboxPassword.Password)
            {
                if (clientLogin.NomClient == "Korben Dallas")
                {
                    MenuAdmin menuAdmin = new MenuAdmin();
                    menuAdmin.Left = Application.Current.MainWindow.Left;
                    menuAdmin.Top = Application.Current.MainWindow.Top;
                    menuAdmin.Height = Application.Current.MainWindow.Height;
                    menuAdmin.Width = Application.Current.MainWindow.Width;
                    menuAdmin.ShowDialog();
                }
                else
                {
                    MenuClient menuClient = new MenuClient();
                    menuClient.Left = Application.Current.MainWindow.Left;
                    menuClient.Top = Application.Current.MainWindow.Top;
                    menuClient.Height = Application.Current.MainWindow.Height;
                    menuClient.Width = Application.Current.MainWindow.Width;
                    ClientCourant.ClientActif = clientLogin;
                    foreach (Compte item in DataGuichet.listeComptes)
                    {
                        if (item.NumeroDeClient == clientLogin.NIP)
                        {
                            ClientCourant.CompteActif.Add(item);
                        }
                    }
                    nbressaie = 0;
                    menuClient.ShowDialog();
                }
            }
            else
            {
                if (nbressaie > 3)
                {
                    MessageBox.Show("Nombre d'essaie avec erreur dépassez - veuillez re-essayer plus tard");
                }
                else
                {
                    MessageBox.Show("Login incorrect");
                    nbressaie += 1;
                }
                
            }
        }
    }


}
