using System;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Browsing2 : Form
    {
        int id = 0;
        int cost = 0;

        Browsing b;
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");
        string itemName;
        public Browsing2(int cost,string name,string data,Image image, int Id,Browsing browsing)
        {
            b =browsing;
            
            InitializeComponent();
            pictureBox1.Image = image;
            label2.Text = data;
            id = Id;
            this.cost = cost;
            itemName = name;
          }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void Browsing2_Load(object sender, System.EventArgs e)
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (UserSession.carts == null)
            {
                UserSession.carts = new ArrayList();
                UserSession.cartsItems = new ArrayList();
                UserSession.totalCost = 0;
            }
         
            UserSession.carts.Add(id);
            UserSession.cartsItems.Add(itemName);
            UserSession.totalCost = UserSession.totalCost + cost;

            MessageBox.Show("Item added to Carts");
            b.cartLabel.Text = "Current Items in cart : "  + UserSession.carts.Count;
            this.Owner.Show();
            this.Hide();

        }
    }
}
