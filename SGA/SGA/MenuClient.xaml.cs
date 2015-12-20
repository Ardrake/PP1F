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
    /// Interaction logic for MenuClient.xaml
    /// </summary>
    public partial class MenuClient : Window
    {
        public MenuClient()
        {
            InitializeComponent();
            //MainWindow.menuClient.Left = MainWindow.getPos("Left");
            //MainWindow.menuClient.Top = MainWindow.getPos("Top");
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void retrait_button_Click(object sender, RoutedEventArgs e)
        {
            SelectionTransaction.selectedTransac = "Retrait";
            Retrait menuRetrait = new Retrait();
            menuRetrait.Left = Application.Current.MainWindow.Left;
            menuRetrait.Top = Application.Current.MainWindow.Top;
            menuRetrait.Height = Application.Current.MainWindow.Height;
            menuRetrait.Width = Application.Current.MainWindow.Width;
            menuRetrait.ShowDialog();
        }

        private void depot_button_Click(object sender, RoutedEventArgs e)
        {
            SelectionTransaction.selectedTransac = "Dépot";
            Retrait menuDepot = new Retrait();
            menuDepot.Left = Application.Current.MainWindow.Left;
            menuDepot.Top = Application.Current.MainWindow.Top;
            menuDepot.Height = Application.Current.MainWindow.Height;
            menuDepot.Width = Application.Current.MainWindow.Width;
            menuDepot.ShowDialog();
        }


    }
}
