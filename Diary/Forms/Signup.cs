using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diary.Forms
{
    public partial class Signup : Form
    {
        //MySqlConnection connection = new MySqlConnection("Server=192.168.1.108;Database=Diary;User Id=root;Password=SqlAdmin;");
        MySqlConnection connection;

        public Signup(string connectionString)
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            string secretComment = textBox4.Text;
            if (username == "" ||
                password == "" ||
                email == "" ||
                secretComment == "")
            {
                MessageBox.Show("Field cannot be null!!");
            }
            else if (!isEmailExist(email, ""))
            {
                string query = "INSERT INTO User VALUES(\"" + email + "\", \"" + username + "\", \"" + password + "\", \"" + secretComment + "\")";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                MessageBox.Show("Succefully Sign up !!");


                connection.Close();

            }
        }


        public bool isEmailExist(string email, string comparedEmail)
        {
            if (email.Length < 1)
                return true;
            string query = "SELECT * FROM User WHERE Email = \"" + email + "\"";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            if (Reader.Read() && Reader.GetString(0) != comparedEmail)
            {
                MessageBox.Show("This Email Already Exist !!");
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }
    }
}
