using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Export ProID = new Export();
            
            txtReceipt.Clear();
            txtReceipt.Text += "**          Receipt          **\n";
            txtReceipt.Text += "*******************************\n";
            txtReceipt.Text += "Date :" + DateTime.Now + "\n";
            txtReceipt.Text += "ProductID: "         +"\n";
            txtReceipt.Text += "**          Receipt          **\n";
            txtReceipt.Text += "**          Receipt          **\n";
            txtReceipt.Text += "**          Receipt          **\n";
            txtReceipt.Text += "\n     Signature";

        }
    }
}
