using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStore
{
    public partial class RegisterForm : Form
    {
        private Button register;
        private TextBox name;
        private TextBox password;
        private TextBox confirmpassword;
        private Label nameLabel, passwordLabel, confirmpasswordLabel;
        private model.Store myStore;

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        public RegisterForm(model.Store s)
        {
            InitializeComponent();

            myStore = s;

            this.Size = new Size(300, 300);
            nameLabel = new Label
            {
                Text = "Username:",
                Location = new Point(25, 25)
            };
            passwordLabel = new Label
            {
                Text = "Password:",
                Location = new Point(25, 75)
            };
            confirmpasswordLabel = new Label
            {
                Text = "Confirm Password:",
                Location = new Point(25, 125)
            };
            name = new TextBox
            {
                Location = new Point(27, 50)
            };
            password = new TextBox
            {
                Location = new Point(27, 100),
                PasswordChar = '⚫'
            };
            confirmpassword = new TextBox
            {
                Location = new Point(27, 150),
                PasswordChar = '⚫'
            };

            register = new Button
            {
                Location = new Point(27, 190),
                Text = "Register",
            };

            register.Click += Register;

            Controls.Add(name);
            Controls.Add(password);
            Controls.Add(confirmpassword);
            Controls.Add(register);
            Controls.Add(nameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(confirmpasswordLabel);
        }


        private void Register(Object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(name.Text)&&string.IsNullOrWhiteSpace(password.Text)&&string.IsNullOrWhiteSpace(confirmpassword.Text))
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }
            if(password.Text!=confirmpassword.Text)
            {
                MessageBox.Show("These passwords do not match");
                return;
            }
            if (!myStore.AddCustomer(name.Text, password.Text))
            {
                MessageBox.Show("Successfully Registered!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Username Already Exists");
                name.Text = "";
            }
        }
    }
}
