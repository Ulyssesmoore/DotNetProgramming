using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.ServiceModel.Description;
using SuperStoreWebService2;

namespace SuperStoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Store myStore;
        public MainWindow()
        {
            InitializeComponent();
            
            myStore = new Store();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var c = myStore.CheckLogin(UsernameBox.Text, PasswordBox.Password);
            if (c == null)
            {
                MessageBox.Show("Login Failed");
                return;
            }
            var storeForm = new SuperStore(c, myStore);
            storeForm.Closing += delegate { this.Show(); };
            this.Hide();
            UsernameBox.Text = "";
            PasswordBox.Password = "";
            storeForm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var rg = new RegisterForm(myStore);
            rg.Closing+= delegate { this.Show(); };
            this.Hide();
            rg.Show();
        }
    }
}
