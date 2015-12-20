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
        }

        private void annuler_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accepeter_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectionTransaction.selectedTransac + " pour " + montantRetrait + " fait dans le compte " + SelectionCompte.selectedCompte);

            this.Close();

        }

        private void button_Click_10(object sender, RoutedEventArgs e)
        {
            montantRetrait = 10;
        }

        private void button_Click_20(object sender, RoutedEventArgs e)
        {
            montantRetrait = 20;
        }

        private void button_Click_30(object sender, RoutedEventArgs e)
        {
            montantRetrait = 30;
        }

        private void button_Click_40(object sender, RoutedEventArgs e)
        {
            montantRetrait = 40;
        }

        private void button_Click_50(object sender, RoutedEventArgs e)
        {
            montantRetrait = 50;
        }

        private void button_Click_100(object sender, RoutedEventArgs e)
        {
            montantRetrait = 100;
        }

        private void button_Click_200(object sender, RoutedEventArgs e)
        {
            montantRetrait = 200;
        }

        private void button_Click_300(object sender, RoutedEventArgs e)
        {
            montantRetrait = 300;
        }

        private void button_Click_400(object sender, RoutedEventArgs e)
        {
            montantRetrait = 400;
        }

        private void button_Click_500(object sender, RoutedEventArgs e)
        {
            montantRetrait = 500;
        }

    }
}
