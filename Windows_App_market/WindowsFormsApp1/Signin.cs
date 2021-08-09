using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp1
{

    public partial class Signin : Form
    {
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");

        public Signin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Signin_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            string vsql = string.Format("select * from Users where Email='{0}' AND Password='{1}'", emailBox.Text, password.Text);
            //Creating the SQL Statement to execute
            SqlCommand vCom = new SqlCommand(vsql, vCon);
            using (SqlDataReader reader = vCom.ExecuteReader())
            {
                if (reader.Read())
                {

                  //  MessageBox.Show("Login successful for user: " + reader["Email"]);
                    Actions actions = new Actions(""+reader["Email"], (int)reader["User_ID"]);
                    UserSession.userId = (int)reader["User_ID"];
                    actions.Show(this);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login! Please try again");

                }
            }
            //command to execute the sql statement

        }
    }
}
