using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperStore.model;

namespace SuperStore
{
    public partial class SuperStore : Form
    {
        private TextBox inventory;

        private DataGrid inv;
        public SuperStore(Customer c, Store s)
        {
            InitializeComponent();
            inventory = new TextBox
            {
                ScrollBars = ScrollBars.Vertical,
                Multiline = true,
                Enabled = false,
                Size = new Size(100,100)
            };

            inv = new DataGrid
            {
                Size = new Size(100,100),
                
            };

            foreach (Product p in c.GetOwnedProducts())
            {
                inventory.AppendText(p.Name + ", " + p.AmountOwned + "\n");    
            }

            this.Size = new Size(300,300);

            this.Controls.Add(inventory);
        }

        private void SuperStore_Load(object sender, EventArgs e)
        {

        }
    }
}
