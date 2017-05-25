using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using SuperStore;
using SuperStoreWebService2;

namespace SuperStoreWPF
{
    /// <summary>
    /// Interaction logic for AddProductScreen.xaml
    /// </summary>
    public partial class AddProductScreen : Window
    {
        private Store myStore;
        private Customer currentUser;
        private SuperStore storescreen;
        public AddProductScreen(Customer c, Store s, SuperStore ss)
        {
            InitializeComponent();
            myStore = s;
            currentUser = c;
            storescreen = ss;

            amountInput.PreviewTextInput += IsTextAllowed;
            DataObject.AddPastingHandler(amountInput, OnCancelCommand);
            DataObject.AddPastingHandler(priceInput, OnCancelCommand);

            AddProduct.Click += AddProduct_Click;

            Closing += BackToStore;
        }

        private void BackToStore(object sender, CancelEventArgs e)
        {
            storescreen.SetupDataGrids();
            storescreen.Show();
        }

        private void IsTextAllowed(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);

        }

        private void OnCancelCommand(object sender, DataObjectEventArgs e)
        {
            e.CancelCommand();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && !string.IsNullOrWhiteSpace(priceInput.Text)&&!string.IsNullOrWhiteSpace(amountInput.Text))
            {
                IStoreService iss = new SuperStoreWebService2.StoreService();
                iss.AddProductToDatabase(new Product(nameInput.Text, Convert.ToDouble(priceInput.Text), Convert.ToInt32(amountInput.Text)));
            }
        }
    }
}
