using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        SqlConnection vCon = new SqlConnection("Data Source=DESKTOP-IDOAP2A\\SQLEXPRESS;Initial Catalog=samtest;Persist Security Info=True;Integrated Security=True;");

        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string vsql = string.Format("insert into users(Name,email,address,paymentCard,password) values('{0}','{1}','{2}','{3}','{4}' )", NameBox.Text, EmailBox.Text, AddressBox.Text, CardNumberBox.Text, PasswordBox.Text);
            //Creating the SQL Statement to execute
            SqlCommand vCom = new SqlCommand(vsql, vCon);
            //command to execute the sql statement
            try
            {
                vCom.ExecuteNonQuery(); //executing the command
                vCom.Dispose(); //releasing the command object 
                MessageBox.Show("Account is created! Please login to access your Block Chain Account!");
                Signin signIn = new Signin();
                signIn.Show();
                //clearing the text boxes


            }
            catch (Exception ex)
            {
                MessageBox.Show("error occured " + ex.Message);

            }
        }

        private void SignUp_Load_1(object sender, EventArgs e)
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
            // TODO: This line of code loads data into the 'samtestDataSet.account' table. You can move, or remove it, as needed.
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            (new Signin()).Show();
            this.Hide();
        }
    }
}
