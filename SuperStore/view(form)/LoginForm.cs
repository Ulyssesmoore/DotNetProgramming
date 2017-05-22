using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperStore.model;

namespace SuperStore
{
    public partial class LoginForm : Form
    {
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox username;
        private TextBox password;
        private Button login;
        private LinkLabel registerLink;
        private Store myStore;

        public LoginForm()
        {
            InitializeComponent();
            this.Size = new Size(200, 300);
            usernameLabel = new Label
            {
                Text = "Username:",
                Location = new Point(25, 25)
            };
            passwordLabel = new Label
            {
                Text = "Password:",
                Location = new Point(25, 75)
            };
            username = new TextBox
            {
                Location = new Point(27, 50)
            };
            password = new TextBox
            {
                Location = new Point(27, 100),
                PasswordChar = '⚫'
            };
            login = new Button
            {
                Location = new Point(27, 140),
                Text = "Login"
            };

            registerLink = new LinkLabel
            {
                Text = "Register",
                Location = new Point(40, 180)
            };

            login.Click += Login;
            registerLink.Click += GoToRegisterForm;

            this.Controls.Add(usernameLabel);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(username);
            this.Controls.Add(password);
            this.Controls.Add(login);
            this.Controls.Add(registerLink);

            myStore = new Store();
            CenterToScreen();
        }

        private void LoginForm_Load(Object sender, EventArgs e)
        {

        }

        private void Login(Object sender, EventArgs e)
        {
            var c = myStore.CheckLogin(username.Text, password.Text);
            MessageBox.Show( c != null
                ? "Welkom to the Superstore!"
                : "Login Failed!");
            if(c == null) return;
            var storeForm = new SuperStore(c, myStore);
            storeForm.FormClosing += delegate { this.Show(); };
            this.Hide();
            username.Text = "";
            password.Text = "";
            storeForm.Show();
        }

        private void GoToRegisterForm(Object sender, EventArgs e)
        {
            var rg = new RegisterForm(myStore);    
            rg.FormClosing += delegate { this.Show(); };
            this.Hide();
            rg.Show();
        }
    }
}