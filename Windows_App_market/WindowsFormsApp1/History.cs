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

namespace WindowsFormsApp1
{
    public partial class History : Form
    {
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");

        public History()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                vCon.Open(); //Trying to open connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("error occured " + ex.Message);
                this.Dispose();
            }
            string vsql = string.Format("select * from Orders where buyer_id = " + UserSession.userId);
            SqlCommand vCom = new SqlCommand(vsql, vCon);
            using (SqlDataReader reader = vCom.ExecuteReader())
            {
            
                while (reader.Read())
                {
                    // string vsql = string.Format("insert into ORDERS(Total_Amount,Order_Quantity,U_PaymentCard,Buyer_ID) values('{0}',{1},'{2}',{3})", UserSession.totalCost, UserSession.cartsItems.Count, cardpayment, UserSession.userId);

                    listBox1.Items.Add("total cost: " + reader["Total_Amount"] + "--total items: " + reader["Order_Quantity"] + "-- payment: " + reader["U_PaymentCard"]);
                }
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
