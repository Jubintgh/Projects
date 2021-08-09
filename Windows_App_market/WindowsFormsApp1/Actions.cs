using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Actions : Form
    {
        public Actions(String aName, int Aid)
        {
            Accountname = aName;
            AccountId = Aid;
            InitializeComponent();

        }
        public String Accountname;
        public int AccountId;
        public Actions()
        {
        }
   
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listing_An_Tran listing = new Listing_An_Tran();
            listing.Show(this);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Browsing browsing = new Browsing();
            browsing.Show(this);
            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
             History history = new History();
            history.Show(this);
            this.Hide();
        }

        private void Actions_Load_1(object sender, EventArgs e)
        {
            welcomeLabel.Text = "Welcome " + Accountname + "! What do you want to do?";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
