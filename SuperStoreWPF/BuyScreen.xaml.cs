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
using SuperStore;
using SuperStore.model;

namespace SuperStoreWPF
{
    /// <summary>
    /// Interaction logic for BuyScreen.xaml
    /// </summary>
    public partial class BuyScreen : Window
    {
        private Store myStore;
        private Customer currentUser;

        public BuyScreen(Customer c, Store s)
        {
            InitializeComponent();
            myStore = s;
            currentUser = c;

            SetupGrid();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SetupGrid()
        {
            selectProducts.ShowGridLines = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
