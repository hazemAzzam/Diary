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
    public partial class ForgotPassword : Form
    {
        string connectionString;
        MySqlConnection connection;

        public ForgotPassword(string connectionTEXT)
        {
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionString);
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string secretComment = textBox2.Text;
            string password = textBox3.Text;
            
            if (isSecretCommentTrueForEmail(email, secretComment))
            {
                connection.Open();
                string query = "UPDATE User SET " +
                    "password = \"" + password + "\" " +
                    "WHERE email = \"" + email + "\"";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                MessageBox.Show("Password Been changed Successfully!!");
            }
            else
            {
                MessageBox.Show("Email or Secret Comment is incorrect!!");
            }
            connection.Close();
            
        }

        bool isSecretCommentTrueForEmail(string email, string secretComment)
        {
            string query = "SELECT Secret_Comment FROM User WHERE email = \"" + email + "\"";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == secretComment)
                {
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        int mouseX;
        int mouseY;
        bool dragging;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
            dragging = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
