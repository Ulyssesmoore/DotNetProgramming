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
            int i = 0;
            foreach (KeyValuePair<Product, int> entry in myStore.GetStock())
            {
                selectProducts.RowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Auto
                });
                Label nameLabel = new Label
                {
                    Content = entry.Key.Name
                };
                nameLabel.SetValue(Grid.ColumnProperty, 0);
                nameLabel.SetValue(Grid.RowProperty, i);
                Label priceLabel = new Label
                {
                    Content = entry.Key.Price
                };
                priceLabel.SetValue(Grid.ColumnProperty, 1);
                priceLabel.SetValue(Grid.RowProperty, i);
                Label amountLabel = new Label
                {
                    Content = entry.Value.ToString()
                };
                amountLabel.SetValue(Grid.ColumnProperty, 2);
                amountLabel.SetValue(Grid.RowProperty, i);
                TextBox amountInput = new TextBox();
                amountInput.TextChanged += CheckText;
                amountInput.SetValue(Grid.ColumnProperty, 3);
                amountInput.SetValue(Grid.RowProperty, i);
                selectProducts.Children.Add(nameLabel);
                selectProducts.Children.Add(priceLabel);
                selectProducts.Children.Add(amountLabel);
                selectProducts.Children.Add(amountInput);
                i++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckText(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
