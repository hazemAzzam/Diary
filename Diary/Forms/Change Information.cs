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
    public partial class Change_Information : Form
    {
        MySqlConnection connection;
        string connectionString;
        string email;
        public Change_Information(string Email, string connectionTEXT)
        {
            email = Email;
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionString);
            InitializeComponent();

            // Import data to textBoxes
            string query = "SELECT * FROM User WHERE Email = \"" + email + "\"";
            connection.Close();
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetString(1);
                textBox2.Text = reader.GetString(0);
                textBox3.Text = reader.GetString(2);
                textBox4.Text = reader.GetString(3);
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string nametext = textBox1.Text;
            string emailtext = textBox2.Text;
            string passwtext = textBox3.Text;
            string secretComment = textBox4.Text;

            if (nametext == "" ||
                emailtext == "" ||
                passwtext == "" ||
                secretComment == "")
            {
                MessageBox.Show("Please fill up fields!!");          
            }
            else
            {
                string query = "UPDATE User SET " +
                "email = \"" + emailtext + "\", " +
                "username = \"" + nametext + "\", " +
                "password = \"" + passwtext + "\", " +
                "secret_comment = \"" + secretComment + "\" " +
                "WHERE email = \"" + email + "\"";

                if (!isEmailExist(emailtext, email))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    MessageBox.Show("Information been Updated!!");
                    connection.Close();
                }
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
