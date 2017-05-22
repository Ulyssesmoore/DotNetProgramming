using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperStore.model;

namespace SuperStore
{
    public partial class SuperStore : Form
    {
        private Customer currentUser;
        private DataGridView inventory, storage;
        private Label userLabel, budgetLabel;

        public SuperStore(Customer c, Store s)
        {
            currentUser = c;
            userLabel = new Label
            {
                Text = "Current user: " + currentUser.Name,
                Location =  new Point(30,50),
                Size = new Size(200,25)
            };

            budgetLabel = new Label
            {
                Text = "Credit: " + currentUser.Budget.ToString("C", CultureInfo.CurrentCulture),
                Location = new Point(30,75)
            };

            inventory = new DataGridView
            {
                Location = new Point(30, 150),
                Size = new Size(200, 200),
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                AllowUserToAddRows = false
            };
            inventory.Columns.Add("name", "Name");
            inventory.Columns.Add("amount", "Amount");

            storage = new DataGridView
            {
                Location = new Point(330, 150),
                Size = new Size(300, 200),
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                AllowUserToAddRows = false
            };

            storage.Columns.Add("name", "Name");
            storage.Columns.Add("price", "Price");
            storage.Columns.Add("amount", "Amount");

            foreach (Product p in currentUser.GetOwnedProducts())
            {
                inventory.Rows.Add(p.Name, p.AmountOwned);
            }

            foreach (KeyValuePair<Product, int> p in s.GetStock())
            {
                storage.Rows.Add(p.Key.Name, p.Key.Price.ToString("C", CultureInfo.CurrentCulture), p.Value);
            }

            this.Size = new Size(700,500);

            this.Controls.Add(userLabel);
            this.Controls.Add(budgetLabel);
            this.Controls.Add(inventory);
            this.Controls.Add(storage);
            this.FormClosing += delegate { currentUser = null; };

            CenterToScreen();
        }

        private void SuperStore_Load(object sender, EventArgs e)
        {

        }
    }
}
