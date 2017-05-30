using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SuperStoreWebService2;

namespace SuperStoreWPF
{
    /// <summary>
    /// Interaction logic for RestockScreen.xaml
    /// </summary>
    public partial class RestockScreen : Window
    {
        private Store myStore;
        private Customer currentUser;
        private SuperStore storescreen;

        public RestockScreen(Customer c, Store s, SuperStore ss)
        {
            InitializeComponent();
            myStore = s;
            currentUser = c;
            storescreen = ss;

            AmountInput.PreviewTextInput += IsTextAllowed;

            ObservableCollection<string> productList = new ObservableCollection<string>();
            var stock = myStore.Stock;
            foreach (KeyValuePair<Product, int> entry in stock)
            {
                productList.Add(entry.Key.Name);
            }

            ProductList.ItemsSource = productList;

            Closing += delegate { storescreen.Show(); };
        }


        private void IsTextAllowed(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);

        }

        private void RestockButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ProductList.Text) && !string.IsNullOrWhiteSpace(AmountInput.Text))
            {
                
            }
        }
    }
}
