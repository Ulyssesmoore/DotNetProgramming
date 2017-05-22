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
using SuperStore.model;

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

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Name";
            nameColumn.Binding = new Binding("Name");
            inventory.Columns.Add(nameColumn);

            DataGridTextColumn amountOwnedColumn = new DataGridTextColumn();
            amountOwnedColumn.Header = "Amount";
            amountOwnedColumn.Binding = new Binding("AmountOwned");
            inventory.Columns.Add(amountOwnedColumn);

            DataGridTextColumn productNameColumn = new DataGridTextColumn();
            productNameColumn.Header = "Name";
            productNameColumn.Binding = new Binding("Name");
            storage.Columns.Add(productNameColumn);

            DataGridTextColumn priceColumn = new DataGridTextColumn();
            priceColumn.Header = "Price";
            priceColumn.Binding = new Binding("Price");
            priceColumn.Binding.StringFormat = "$0.00";
            storage.Columns.Add(priceColumn);

            DataGridTextColumn amountInStorageColumn = new DataGridTextColumn();
            amountInStorageColumn.Header = "AmountOwned";
            amountInStorageColumn.Binding = new Binding("AmountOwned");
            storage.Columns.Add(amountInStorageColumn);

            foreach (Product p in currentUser.GetOwnedProducts())
            {
                inventory.Items.Add(p);
            }

            foreach (KeyValuePair<Product, int> p in s.GetStock())
            {
                storage.Items.Add(new Product(p.Key.Name, p.Key.Price, p.Value));
            }

            userLabel.Content = "Current user: " + currentUser.Name;
            budgetLabel.Content = "Credit: " + currentUser.Budget.ToString("C", CultureInfo.CurrentCulture);

            this.Closing += delegate { currentUser = null; };
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
