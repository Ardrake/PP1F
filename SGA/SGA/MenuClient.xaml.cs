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
    }
}
