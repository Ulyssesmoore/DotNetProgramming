using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            currentBudget.Content = Convert.ToString(currentUser.Budget);
            substraction.Content = "0.0";
            budgetLeft.Content = "0.0";

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
                amountInput.PreviewTextInput += IsTextAllowed;
                amountInput.TextChanged += GetSum;
                DataObject.AddPastingHandler(amountInput, OnCancelCommand);
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

        private void IsTextAllowed(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$"); //regex that matches disallowed text
            e.Handled = !regex.IsMatch(e.Text);
            
        }

        private void GetSum(object sender, TextChangedEventArgs e)
        {
            double totalprice = 0.0;
            for (int i=0; i < selectProducts.RowDefinitions.Count;i++)
            {
                Label priceLabel = (Label) selectProducts.Children.Cast<UIElement>()
                    .First(ef => Grid.GetColumn(ef) == 1 && Grid.GetRow(ef) == i);
                TextBox tb = (TextBox)selectProducts.Children.Cast<UIElement>().First(ef => Grid.GetColumn(ef) == 3 && Grid.GetRow(ef) == i);
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    totalprice += Convert.ToInt32(tb.Text) * Convert.ToDouble(priceLabel.Content);
                }
            }
            Debug.WriteLine(totalprice);
            substraction.Content = Convert.ToString(totalprice * -1);
            BuyButton.IsEnabled = !((currentUser.Budget - totalprice) < 0.0);
            notifications.Content = (currentUser.Budget - totalprice < 0.0) ? "You dont have enough budget for this purchase" : "No notifications";
            budgetLeft.Content = Convert.ToString(currentUser.Budget - totalprice);
        }



        private void OnCancelCommand(object sender, DataObjectEventArgs e)
        {
            e.CancelCommand();
        }
    }
}
