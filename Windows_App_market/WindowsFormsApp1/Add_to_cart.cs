using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Add_To_Cart : Form
    {
        public Add_To_Cart()
        {
            InitializeComponent();
        }

   

        private void button2_Click(object sender, EventArgs e)
        {

            Payment b2 = new Payment();
            b2.Show(this);
            this.Hide();
        }

        private void Add_To_Cart_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < UserSession.carts.Count; i++)
            {
                abc.Items.Add(UserSession.cartsItems[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.Show(this);
            this.Hide();
        }
    }
}
