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
using SuperStoreWebService2;

namespace SuperStoreWPF
{
    /// <summary>
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        private Store myStore;
        public RegisterForm(Store s)
        {
            InitializeComponent();
            myStore = s;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameInput.Text) && string.IsNullOrWhiteSpace(PasswordInput.Password) && string.IsNullOrWhiteSpace(ConfirmPasswordInput.Password))
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }
            if (PasswordInput.Password != ConfirmPasswordInput.Password)
            {
                MessageBox.Show("These passwords do not match");
                return;
            }
            if (!myStore.AddCustomer(UsernameInput.Text, PasswordInput.Password))
            {
                MessageBox.Show("Successfully Registered!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Username Already Exists");
                UsernameInput.Text = "";
            }
        }
    }
}
