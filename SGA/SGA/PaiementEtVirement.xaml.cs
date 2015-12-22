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
        }

        private void Accepter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Virement du compte: " + compteSource.Text + " au compte: " + compteCible.Text + " de " + montant.Text + "$");
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
