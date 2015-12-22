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

namespace SGA
{

    /// <summary>
    /// Interaction logic for RetraitMontant.xaml
    /// </summary>
    public partial class RetraitMontant : Window
    {
        decimal montantRetrait = 0;

        public RetraitMontant()
        {
            InitializeComponent();
            textBox.IsEnabled = false;
        }

        private void annuler_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accepeter_button_Click(object sender, RoutedEventArgs e)
        {
            Compte compteTransac = null;
            Transaction newTransac = null; 
            bool MontantValid = false;
            try
            {
                montantRetrait = Convert.ToDecimal(textBox.Text);
            }
            catch
            {
                MessageBox.Show("Caractere non valide, veuillez entré un nombre");
            }

            if (SelectionCompte.selectedCompteString == "Cheque")
            {
                compteTransac = ClientCourant.compteCheque;
            }
            if (SelectionCompte.selectedCompteString == "Épargne")
            {
                compteTransac = ClientCourant.compteEpargne;
            }

            do
                if ((montantRetrait % 10 == 0))
                {
                    if (montantRetrait >= 10 && montantRetrait <= 1000)
                    {
                        if (compteTransac.Balance >= montantRetrait)
                        {
                            if (DataGuichet.totalGuichet >= montantRetrait)
                            {
                                MontantValid = true;
                            }
                            else
                            {
                                MessageBoxResult result = MessageBox.Show("Fond insufisant dans le guichet une balance de " + DataGuichet.totalGuichet + "$\n Voulez vous modifier le montant pour " + DataGuichet.totalGuichet + "$", "Fond non disponible", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (result == MessageBoxResult.Yes)
                                {
                                    montantRetrait = DataGuichet.totalGuichet;
                                    textBox.Text = montantRetrait.ToString();
                                    MontantValid = true;
                                }
                                break;
                            }
                        }
                        else
                        {
                            int nouveauMontant = (int)((int)compteTransac.Balance/10)*10;
                            MessageBoxResult result = MessageBox.Show("Fond insufisant le compte a une balance de " + compteTransac.Balance + "$\n Voulez vous modifier le montant pour " + nouveauMontant + "$", "Fond insufisant", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                montantRetrait = nouveauMontant;
                                textBox.Text = montantRetrait.ToString();
                                MontantValid = true;
                            }
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le montant de retrait doit etre entre 10$ et 1000$");
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Le montant doit etre un multiple de 10");
                    break;
                }
            while (!MontantValid);

            if (MontantValid)
            {
                if (SelectionTransaction.selectedTransac == "Retrait")
                {
                    compteTransac.Retrait(montantRetrait);
                    newTransac = new Transaction(DateTime.Now, TypeTransaction.Retrait, compteTransac, montantRetrait, compteTransac.Balance);
                    DataGuichet.totalGuichet -= (int)montantRetrait;
                }
                if (SelectionTransaction.selectedTransac == "Dépot")
                {
                    compteTransac.Depot(montantRetrait);
                    newTransac = new Transaction(DateTime.Now, TypeTransaction.Depot, compteTransac, montantRetrait, compteTransac.Balance);
                }

                Compteur.compteurTransac = Program.GetCompteurValue("compteurTransac.dat");
                Program.EcrireTransac(newTransac);
                Program.SetCompteurValue("compteurTransac.dat", Compteur.compteurTransac + 1);
                MessageBox.Show(SelectionTransaction.selectedTransac + " pour " + montantRetrait + "$ fait dans le compte " + SelectionCompte.selectedCompteString + "\nLa balance de votre compte est de " + compteTransac.Balance + "$");
                this.Close();
            }

        }
        
        private void button_Click_10(object sender, RoutedEventArgs e)
        {
            montantRetrait = 10;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_20(object sender, RoutedEventArgs e)
        {
            montantRetrait = 20;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_30(object sender, RoutedEventArgs e)
        {
            montantRetrait = 30;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_40(object sender, RoutedEventArgs e)
        {
            montantRetrait = 40;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_50(object sender, RoutedEventArgs e)
        {
            montantRetrait = 50;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_100(object sender, RoutedEventArgs e)
        {
            montantRetrait = 100;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_200(object sender, RoutedEventArgs e)
        {
            montantRetrait = 200;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_300(object sender, RoutedEventArgs e)
        {
            montantRetrait = 300;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_400(object sender, RoutedEventArgs e)
        {
            montantRetrait = 400;
            textBox.Text = montantRetrait.ToString();
        }

        private void button_Click_500(object sender, RoutedEventArgs e)
        {
            montantRetrait = 500;
            textBox.Text = montantRetrait.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox.IsEnabled = true;
        }
    }
}
