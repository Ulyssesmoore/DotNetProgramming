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
    public partial class BuyForm : Form
    {
        private Store myStore;
        private Customer currentCustomer;
        public BuyForm(Store s, Customer c)
        {
            InitializeComponent();
            myStore = s;
            currentCustomer = c;
        }

        private void BuyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
