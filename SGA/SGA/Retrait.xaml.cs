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
    /// Interaction logic for Retrait.xaml
    /// </summary>
    public partial class Retrait : Window
    {
        public Retrait()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cheque_button_Click(object sender, RoutedEventArgs e)
        {
            SelectionCompte.selectedCompte = "Cheque";
            RetraitMontant menuRetraitMontant = new RetraitMontant();
            menuRetraitMontant.Left = Application.Current.MainWindow.Left;
            menuRetraitMontant.Top = Application.Current.MainWindow.Top;
            menuRetraitMontant.Height = Application.Current.MainWindow.Height;
            menuRetraitMontant.Width = Application.Current.MainWindow.Width;
            menuRetraitMontant.ShowDialog();
            this.Close();
        }

        private void eparge_button_Click(object sender, RoutedEventArgs e)
        {
            SelectionCompte.selectedCompte = "Épargne";
            RetraitMontant menuRetraitMontant = new RetraitMontant();
            menuRetraitMontant.Left = Application.Current.MainWindow.Left;
            menuRetraitMontant.Top = Application.Current.MainWindow.Top;
            menuRetraitMontant.Height = Application.Current.MainWindow.Height;
            menuRetraitMontant.Width = Application.Current.MainWindow.Width;
            menuRetraitMontant.ShowDialog();
            this.Close();
        }
    }
}
