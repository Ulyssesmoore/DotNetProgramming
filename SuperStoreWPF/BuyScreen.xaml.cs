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

            SetupDataGrids();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SetupDataGrids()
        {
            DataGridTextColumn productNameColumn = new DataGridTextColumn()
            {
                Header = "Name",
                Binding = new Binding("Name")
            };
            selectProducts.Columns.Add(productNameColumn);

            DataGridTextColumn priceColumn = new DataGridTextColumn()
            {
                Header = "Price",
                Binding = new Binding("Price")
            };
            priceColumn.Binding.StringFormat = "$0.00";
            selectProducts.Columns.Add(priceColumn);

            DataGridTextColumn amountInStorageColumn = new DataGridTextColumn()
            {
                Header = "In Stock",
                Binding = new Binding("AmountOwned")
            };
            selectProducts.Columns.Add(amountInStorageColumn);

            foreach (KeyValuePair<Product, int> p in myStore.GetStock())
            {
                selectProducts.Items.Add(new Product(p.Key.Name, p.Key.Price, 0));
            }
        }
    }
}
