using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodCompanyDataSet2.Agent' table. You can move, or remove it, as needed.
            this.agentTableAdapter.Fill(this.foodCompanyDataSet2.Agent);
            // TODO: This line of code loads data into the 'foodCompanyDataSet2.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.foodCompanyDataSet2.Product);
            SqlConnection connString = new SqlConnection(@"Data Source = MINHTHU\SQLEXPRESS03; Initial Catalog = FoodCompany; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("select ProductID from Product", connString);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbProductID.DataSource = dt;
            cbbProductID.DisplayMember = "ProductID";

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbProductID.SelectedIndex == 0)
            {
                txtProductName.Text = "Dâu";
                txtPrice.Text = "200000";
            }
            if (cbbProductID.SelectedIndex == 1)
            {
                txtProductName.Text = "Bơ";
                txtPrice.Text = "100000";
            }
            if (cbbProductID.SelectedIndex == 2)
            {
                txtProductName.Text = "Chuối";
                txtPrice.Text = "800000";
            }
            if (cbbProductID.SelectedIndex == 3)
            {
                txtProductName.Text = "Kiwi";
                txtPrice.Text = "850000";
            }
            if (cbbProductID.SelectedIndex == 4)
            {
                txtProductName.Text = "Táo";
                txtPrice.Text = "850000";
            }
            if (cbbProductID.SelectedIndex == 5)
            {
                txtProductName.Text = "Đào";
                txtPrice.Text = "400000";
            }
            if (cbbProductID.SelectedIndex == 6)
            {
                txtProductName.Text = "Cam";
                txtPrice.Text = "150000";
            }
            if (cbbProductID.SelectedIndex == 7)
            {
                txtProductName.Text = "Xoài";
                txtPrice.Text = "900000";
            }

        }

        private void cbbAgentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connString = new SqlConnection(@"Data Source = MINHTHU\SQLEXPRESS03; Initial Catalog = FoodCompany; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("select AgentID from Agent", connString);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbAgentID.DataSource = dt;
            cbbAgentID.DisplayMember = "AgentID";
            if (cbbAgentID.SelectedIndex == 0)
            {
                txtAgentName.Text = "AG1";
                txtAddress.Text = "13 Cao Thắng Phường 1 Quận 1 TPHCM";      
            }
            if (cbbAgentID.SelectedIndex == 1)
            {
                txtAgentName.Text = "AG2";
                txtAddress.Text = "6 Nguyễn Bỉnh Khiêm Phường 5 Quận 6 TPHCM";
            }
            if (cbbAgentID.SelectedIndex == 2)
            {
                txtAgentName.Text = "AG3";
                txtAddress.Text = "20 Lý Tự Trọng Phường 6 Quận 10 TPHCM";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtOrderID.Text, cbbProductID.Text, txtProductName.Text,cbbAgentID,txtAgentName,txtAddress, txtOrderQuantity.Text, txtPrice.Text);


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                {
                    double quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    double price = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    dataGridView1.Rows[i].Cells[8].Value = Convert.ToString(quantity * price);
                }
            }
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double totalPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                sum += totalPrice;
                txtTotal.Text = sum.ToString();
            }
    }

        private void btnCreateImportReceipt_Click(object sender, EventArgs e)
        {
            if (txtOrderID.ToString() == "")
            {
                MessageBox.Show("Enter ID Order", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //add datagridview to sql           
                SqlConnection connString = new SqlConnection(@"Data Source = MINHTHU\SQLEXPRESS03; Initial Catalog = FoodCompany; Integrated Security = True");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    connString.Open();
                    String sSQL2 = "insert into Order(ExportID,ProductID,ProductName,AgentID,AgentName,AgentAdress,Quantity,Price,TotalPrice) values('" + txtOrderID.Text + "','" + cbbProductID.Text + "',N'" + txtProductName.Text + "','" + cbbAgentID.Text + "',N'" + txtAgentName.Text + "',N'" + txtAddress.Text + "','"+ txtOrderQuantity.Text + "','" + txtPrice.Text + "','" + txtTotal.Text  + "')";
                    SqlCommand cmd = new SqlCommand(sSQL2, connString);
                    cmd.Parameters.AddWithValue("ExportID", txtOrderID.Text);
                    cmd.Parameters.AddWithValue("ProductID", cbbProductID.Text);
                    cmd.Parameters.AddWithValue("ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("AgentID", cbbAgentID.Text);
                    cmd.Parameters.AddWithValue("AgentName",txtAgentName.Text);
                    cmd.Parameters.AddWithValue("AgentAdress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("Quantity", Convert.ToInt32(txtOrderQuantity.Text));
                    cmd.Parameters.AddWithValue("Price", Convert.ToDecimal(txtPrice.Text));
                    cmd.Parameters.AddWithValue("TotalPrice", Convert.ToDecimal(txtTotal.Text));
                    cmd.ExecuteNonQuery();
                    connString.Close();
                }
                MessageBox.Show("Data has been saved", "Notification", MessageBoxButtons.OK);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}
