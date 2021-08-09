using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Listing_An_Tran : Form
    {
        Image uploadImage = null;
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");

        public Listing_An_Tran()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uploadBotton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                uploadImage = Image.FromFile(open.FileName);
                pictureBox1.Image = uploadImage;

                // image file path  
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                //Creating the SQL Statement to execute
                string vsql2 = string.Format("insert into Product(P_Name,P_Type,P_Quantity,P_Price,P_Description,P_Condition,Image) values('{0}','{1}','{2}','{3}','{4}','{5}',@photo )", titleBox.Text, typeBox.Text, QuantityBox.Text, pricesBox.Text, descriptionBox.Text, conditionBox.Text);

                SqlCommand vCom2 = new SqlCommand(vsql2, vCon);
                vCom2.Parameters.AddWithValue("@photo", photo_aray);

                //command to execute the sql statement
                try
                {
                    vCom2.ExecuteNonQuery(); //executing the command
                    vCom2.Dispose(); //releasing the command object 
                    MessageBox.Show("Item is created!");
                    titleBox.Text = typeBox.Text = QuantityBox.Text = pricesBox.Text = descriptionBox.Text = conditionBox.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error occured " + ex.Message);

                }
                return;
            }
            string vsql = string.Format("insert into Product(P_Name,P_Type,P_Quantity,P_Price,P_Description,P_Condition) values('{0}','{1}','{2}','{3}','{4}','{5}')", titleBox.Text, typeBox.Text, QuantityBox.Text, pricesBox.Text, descriptionBox.Text,conditionBox.Text);
            //Creating the SQL Statement to execute
            SqlCommand vCom = new SqlCommand(vsql, vCon);
            //command to execute the sql statement
            try
            {
                vCom.ExecuteNonQuery(); //executing the command
                vCom.Dispose(); //releasing the command object 
                MessageBox.Show("Item is created!");
                titleBox.Text = typeBox.Text = QuantityBox.Text = pricesBox.Text = descriptionBox.Text = conditionBox.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("error occured " + ex.Message);

            }
        }

        private void Listing_An_Tran_Load(object sender, EventArgs e)
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
