using System;
using System.Collections.Generic;
using System.Globalization;
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
using SuperStoreWebService2;

namespace SuperStoreWPF
{
    /// <summary>
    /// Interaction logic for SuperStore.xaml
    /// </summary>
    public partial class SuperStore : Window
    {
        private Store myStore;
        private Customer currentUser;
        public SuperStore(Customer c,Store s)
        {
            InitializeComponent();
            myStore = s;
            currentUser = c;

            SetupDataGrids();

            this.Closing += delegate { currentUser = null; };
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (c.Name == "Admin")
            {
                Restock.Visibility = Visibility.Visible;
                Restock.Click += Restock_Click;
                addProduct.Visibility = Visibility.Visible;
                addProduct.Click += AddProduct_Click;
            }
        }

        public void SetupDataGrids()
        {
            inventory.Items.Clear();
            inventory.Columns.Clear();
            storage.Items.Clear();
            storage.Columns.Clear();
            DataGridTextColumn nameColumn = new DataGridTextColumn()
            {
                Header = "Name",
                Binding = new Binding("Name")
            };
            inventory.Columns.Add(nameColumn);

            DataGridTextColumn amountOwnedColumn = new DataGridTextColumn()
            {
                Header = "Amount",
                Binding = new Binding("AmountOwned")
            };
            inventory.Columns.Add(amountOwnedColumn);

            DataGridTextColumn productNameColumn = new DataGridTextColumn()
            {
                Header = "Name",
                Binding = new Binding("Name")
            };
            storage.Columns.Add(productNameColumn);

            DataGridTextColumn priceColumn = new DataGridTextColumn()
            {
                Header = "Price",
                Binding = new Binding("Price")
            };
            priceColumn.Binding.StringFormat = "$0.00";
            storage.Columns.Add(priceColumn);

            DataGridTextColumn amountInStorageColumn = new DataGridTextColumn()
            {
                Header = "In Stock",
                Binding = new Binding("AmountOwned")
            };
            storage.Columns.Add(amountInStorageColumn);

            ICustomerService ics = new SuperStoreWebService2.CustomerService();

            foreach (Product p in ics.GetOwnedProducts(currentUser.Name))
            {
                inventory.Items.Add(p);
            }

            foreach (KeyValuePair<Product, int> p in myStore.Stock)
            {
                if (p.Value > 0)
                {
                    storage.Items.Add(new Product(p.Key.Name, p.Key.Price, p.Value));
                }
            }

            userLabel.Content = "Current user: " + currentUser.Name;
            budgetLabel.Content = "Credit: " + currentUser.Budget.ToString("C", CultureInfo.CurrentCulture);
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            var bs = new BuyScreen(currentUser, myStore, this);
            this.Hide();
            bs.Show();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var aps = new AddProductScreen(currentUser, myStore, this);
            this.Hide();
            aps.Show();
        }

        private void Restock_Click(object sender, RoutedEventArgs e)
        {
            var rs = new RestockScreen(currentUser, myStore, this);
            this.Hide();
            rs.Show();
        }
    }
}
