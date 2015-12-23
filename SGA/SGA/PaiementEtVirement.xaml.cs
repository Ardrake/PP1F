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
    /// Interaction logic for PaiementEtVirement.xaml
    /// </summary>
    public partial class PaiementEtVirement : Window
    {
        public PaiementEtVirement()
        {
            InitializeComponent();
            compteSource.Items.Add("Épargne");
            compteSource.Items.Add("Chèque");

            foreach (Compte item in ClientCourant.CompteActif)
            {
                if (item.GetType() == typeof(Cheque))
                {
                    ClientCourant.compteCheque = item;
                }
                if (item.GetType() == typeof(Epargne))
                {
                    ClientCourant.compteEpargne = item;
                }
            }
        }

        private void Accepter_Click(object sender, RoutedEventArgs e)
        {
            decimal montantVirement = 0;
            bool montantValid = false;
            Transaction newTransac = null;
            Compte compteTransac = null;
            bool transacValid = false;
            decimal frais = (decimal)1.25;

            try
            {
                montantVirement = Convert.ToDecimal(montant.Text);
            }
            catch
            {
                MessageBox.Show("Caractere non valide, veuillez entré un nombre");
            }

            do
            {
                if (compteCible.Text == "Facture")
                {
                    if (montantVirement > 0 && montantVirement <= 10000)
                    {
                        montantValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Le Montant doit etre entre 0$ et 10 000$");
                        break;
                    }
                }

                if (compteCible.Text != "Facture")
                {
                    if (montantVirement > 0 && montantVirement <= 100000)
                    {
                        montantValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Le Montant doit etre entre 0$ et 100 000$");
                        break;
                    }
                }
            }
            while (!montantValid);


            if (montantValid)
            {
                if (compteSource.Text == "Chèque" && compteCible.Text != "Facture")
                {
                    compteTransac = ClientCourant.compteCheque;
                    if (compteTransac.Balance >= montantVirement)
                    {
                        compteTransac.Retrait(montantVirement);
                        newTransac = new Transaction(DateTime.Now, TypeTransaction.TransfertRetrait, compteTransac, montantVirement, compteTransac.Balance);
                        DataGuichet.listeTrasanction.Add(newTransac);
                        transacValid = true;
                    }
                    else MessageBox.Show("Fond insufissant pour le transfert - Balance de " + compteTransac.Balance + "$");

                }

                if (compteSource.Text == "Épargne")
                {
                    compteTransac = ClientCourant.compteEpargne;
                    if (compteTransac.Balance >= montantVirement)
                    {
                        compteTransac.Retrait(montantVirement);
                        newTransac = new Transaction(DateTime.Now, TypeTransaction.TransfertRetrait, compteTransac, montantVirement, compteTransac.Balance);
                        DataGuichet.listeTrasanction.Add(newTransac);
                        transacValid = true;
                    }
                    else MessageBox.Show("Fond insufissant pour le transfert - Balance de " + compteTransac.Balance + "$");

                }

                if (compteCible.Text == "Chèque" && transacValid)
                {
                    compteTransac = ClientCourant.compteCheque;
                    compteTransac.Depot(montantVirement);
                    newTransac = new Transaction(DateTime.Now, TypeTransaction.TransfertDepot, compteTransac, montantVirement, compteTransac.Balance);
                    DataGuichet.listeTrasanction.Add(newTransac);
                }

                if (compteCible.Text == "Épargne" && transacValid)
                {
                    compteTransac = ClientCourant.compteEpargne;
                    compteTransac.Depot(montantVirement);
                    newTransac = new Transaction(DateTime.Now, TypeTransaction.TransfertDepot, compteTransac, montantVirement, compteTransac.Balance);
                    DataGuichet.listeTrasanction.Add(newTransac);
                }

                if (compteSource.Text == "Chèque" && compteCible.Text == "Facture")
                {
                    compteTransac = ClientCourant.compteCheque;
                    if (compteTransac.Balance >= montantVirement + frais)
                    {
                        compteTransac.Retrait(montantVirement);
                        newTransac = new Transaction(DateTime.Now, TypeTransaction.Facture, compteTransac, montantVirement, compteTransac.Balance);
                        DataGuichet.listeTrasanction.Add(newTransac);
                        compteTransac.Retrait(frais);
                        newTransac = new Transaction(DateTime.Now, TypeTransaction.Frais, compteTransac, frais, compteTransac.Balance);
                        DataGuichet.listeTrasanction.Add(newTransac);
                        transacValid = true;
                    }
                    else MessageBox.Show("Fond insufissant pour le transfert - Balance de " + compteTransac.Balance + "$");

                }

                if (transacValid)
                {
                    foreach (Transaction item in DataGuichet.listeTrasanction)
                    {
                        Compteur.compteurTransac = Program.GetCompteurValue("compteurTransac.dat");
                        Program.EcrireTransac(item);
                        Program.SetCompteurValue("compteurTransac.dat", Compteur.compteurTransac + 1);
                    }

                    DataGuichet.listeTrasanction.Clear();

                    MessageBox.Show("Virement du compte: " + compteSource.Text + " au compte: " + compteCible.Text + " de " + montant.Text + "$");
                    this.Close();
                }
            }
        }

        private void Annulé_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void compteSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            compteCible.Items.Clear();
            compteCible.Text = "";
            ;
            if (compteSource.SelectedItem.ToString() == "Chèque")
            {
                compteCible.Items.Add("Épargne");
                compteCible.Items.Add("Facture");
            }
            if (compteSource.SelectedItem.ToString() == "Épargne")
            {
                compteCible.Items.Add("Chèque");
            }
        }
    }
}
