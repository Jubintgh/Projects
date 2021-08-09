using System;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Browsing : Form
    {
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");
        ArrayList arlist = new ArrayList(); ArrayList idList = new ArrayList(); ArrayList nameList = new ArrayList();
        ArrayList costList = new ArrayList();

        public Browsing()
        {
            InitializeComponent();
            //Creating the SQL Statement to execute
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Browsing_Load(object sender, EventArgs e)
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
            string vsql = string.Format("select * from Product");

            SqlCommand vCom = new SqlCommand(vsql, vCon);
            using (SqlDataReader reader = vCom.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    if (i > 6)
                    {
                        return;
                    }
                    arlist.Add("Name: " + reader["P_Name"] + "\n" + "Type: " + reader["P_Type"] + "\n" + "Quantity: " + reader["P_Quantity"] + "\n" + "Price: " + reader["P_Price"] + "\n" +
                        "Condition: " + reader["P_Condition"] + "\n" + "Descriptions: " + reader["P_Description"]);
                    idList.Add(reader["Product_ID"]);
                    nameList.Add(reader["P_Name"]);
                    costList.Add((int)reader["P_Price"]);
                    if (i == 0)
                    {
                        item1.Visible = true;
                        picture1.Visible = true;

                        item1.Text = "" + reader["P_Name"];
                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture1.Image = Image.FromStream(ms);

                        }
                      
                    }
                    if (i == 1)
                    {
                        item2.Visible = true;
                        item2.Text = "" + reader["P_Name"];
                        picture2.Visible = true;

                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture2.Image = Image.FromStream(ms);
                        }
                    }
                    if (i == 2)
                    {
                        item3.Visible = true;
                        item3.Text = "" + reader["P_Name"];
                        picture3.Visible = true;

                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture3.Image = Image.FromStream(ms);
                        }
                    }
                    if (i == 3)
                    {
                        item4.Visible = true;
                        picture4.Visible = true;

                        item4.Text = "" + reader["P_Name"];
                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture4.Image = Image.FromStream(ms);
                        }
                    }
                    if (i == 4)
                    {
                        item5.Visible = true;
                        item5.Text = "" + reader["P_Name"];
                        picture5.Visible = true;

                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture5.Image = Image.FromStream(ms);
                        }
                    }
                    if (i == 5)
                    {
                        item6.Visible = true;
                        item6.Text = "" + reader["P_Name"];
                        picture6.Visible = true;

                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture6.Image = Image.FromStream(ms);
                        }
                    }
                    if (i == 6)
                    {
                        item7.Visible = true;
                        picture7.Visible = true;

                        item7.Text = "" + reader["P_Name"];
                        if (reader["image"] != System.DBNull.Value)
                        {
                            byte[] photo_aray = (byte[])reader["image"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            picture7.Image = Image.FromStream(ms);
                        }
                    }
                    //  MessageBox.Show("Login successful for user: " + reader["Email"]);
                    i++;
                }

            }

        }

        private void item1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[0],(string)nameList[0], (string)arlist[0],picture1.Image, (int)idList[0],this);
            b2.Show(this);
            this.Hide();
        }

        private void item2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[1], (string)nameList[1],(string)arlist[1], picture2.Image, (int)idList[1], this);
            b2.Show(this);
            this.Hide();
        }

        private void item3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[2], (string)nameList[2],(string)arlist[2], picture3.Image, (int)idList[2], this);
            b2.Show(this);
            this.Hide();
        }

        private void item4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[3], (string)nameList[3], (string)arlist[3], picture4.Image, (int)idList[3], this);
            b2.Show(this);
            this.Hide();
        }

        private void item5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[4], (string)nameList[4], (string)arlist[4], picture5.Image, (int)idList[4], this);
            b2.Show(this);
            this.Hide();
        }

        private void item6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[5], (string)nameList[5], (string)arlist[5], picture6.Image, (int)idList[5], this);
            b2.Show(this);
            this.Hide();
        }

        private void item7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browsing2 b2 = new Browsing2((int)costList[6], (string)nameList[6], (string)arlist[6], picture7.Image, (int)idList[6], this);
            b2.Show(this);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_To_Cart a = new Add_To_Cart();
            a.Show(this);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
