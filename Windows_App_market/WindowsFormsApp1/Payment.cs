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
    public partial class Payment : Form
    {
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");

        public Payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //confirm
            String cardpayment = "Name: " + textBox4.Text + "Card Number: " + textBox5.Text;
            string vsql = string.Format("insert into ORDERS(Total_Amount,Order_Quantity,U_PaymentCard,Buyer_ID) values('{0}',{1},'{2}',{3})", UserSession.totalCost, UserSession.cartsItems.Count, cardpayment,UserSession.userId);
            //command to execute the sql statement
            
            SqlCommand vCom = new SqlCommand(vsql, vCon);
            try
            {
                vCom.ExecuteNonQuery(); //executing the command
                vCom.Dispose(); //releasing the command object 
                                //clearing the text boxes

                int orderId = 0;
                string vsql2 = string.Format("SELECT TOP (1) Order_ID FROM ORDERS  order by Order_ID desc");
                vCom = new SqlCommand(vsql2, vCon);
                using (SqlDataReader reader = vCom.ExecuteReader())
                {
                    vCom.Dispose(); //releasing the command object 

                    if (reader.Read())
                    {

                        //  MessageBox.Show("Login successful for user: " + reader["Email"]);
                         orderId = (int)reader["Order_ID"];
                       
                    }
                    
                }
                if (orderId != 0)
                {
                    for (int i = 0; i < UserSession.carts.Count; i++)
                    {
                        int productId = (int)UserSession.carts[i];
                        string vsql3 = string.Format("insert into  ORDERS_USER(Order_ID,User_ID,Product_ID)  values({0},{1},{2})", orderId, UserSession.userId, productId);
                        SqlCommand vCom3 = new SqlCommand(vsql3, vCon);
                        vCom3.ExecuteNonQuery(); //executing the command
                        vCom3.Dispose(); //releasing the command object 
                    }
                }
                UserSession.carts = new System.Collections.ArrayList();

                UserSession.cartsItems = new System.Collections.ArrayList();
                UserSession.totalCost = 0;
                this.Owner.Owner.Owner.Show();
                this.Hide();
                MessageBox.Show("Payment Completed! Return to Main Menu");

            }
            catch (Exception ex)
            {
                MessageBox.Show("error occured " + ex.Message);

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
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
        }
    }
}
