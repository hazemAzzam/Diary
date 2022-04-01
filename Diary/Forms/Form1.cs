using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diary
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=127.0.0.1;Database=Diary;User Id=root;Password=root";
        //string connectionString = "Server=MYSQL5040.site4now.net;Database=db_a71428_diary;Uid=a71428_diary;Pwd=121035Diary";
        MySqlConnection connection;
        string username;
        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            using (StreamReader readtext = new StreamReader("MySqlData"))
            {
                textBox1.Text = readtext.ReadLine();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;


            if (CheckForInternetConnection())
            {
                string query = "SELECT * FROM User WHERE email = \"" + email + "\" AND Password = \"" + password + "\"";

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    username = reader.GetString(1);

                    using (StreamWriter writetext = new StreamWriter("MySqlData"))
                    {
                        writetext.WriteLine(email);
                        writetext.WriteLine(password);
                        writetext.WriteLine(username);
                    }

                    Forms.Dashboard d = new Forms.Dashboard(email, username, connectionString);
                    connection.Close();
                    //upload(email);
                    this.Hide();
                    d.ShowDialog();
                }
                else
                {
                    MessageBox.Show("False");
                }
                connection.Close();
            }
            // if no connection check from data file
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader("MySqlData"))
                    {
                        string emailFromFile = reader.ReadLine();
                        string passwordFromFile = reader.ReadLine();
                        string usernameFromFile = reader.ReadLine();

                        if (email == emailFromFile && password == passwordFromFile)
                        {
                            Forms.Dashboard d = new Forms.Dashboard(email, usernameFromFile, connectionString);
                            connection.Close();
                            this.Hide();
                            d.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No Internet Connection");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Forms.Signup signup = new Forms.Signup(connectionString);
            signup.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Forms.ForgotPassword forgotPassword = new Forms.ForgotPassword(connectionString);
            forgotPassword.ShowDialog();
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

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return true;
            }
        }

        void upload(string email)
        {
            if (Directory.Exists("MyDiarys"))
            {
                string mainDirectory = "MyDiarys";
                string[] directories = Directory.GetDirectories("MyDiarys").Select(Path.GetFileName).ToArray();
                foreach (string directory in directories)
                {
                    string yearDate = directory;
                    string[] files = Directory.GetFiles(mainDirectory + "\\" + directory).Select(Path.GetFileName).ToArray();

                    foreach (string file in files)
                    {
                        string date = file;
                        string startTime;
                        string finishTime;
                        string title;
                        string content = "";
                        string[] lines = File.ReadAllLines(mainDirectory + "\\" + directory + "\\" + date);
                        int line = 0;
                        while (line < lines.Length - 2)
                        {
                            string[] startAndFinishTime = lines[line].Replace(" --> ", ">").Split('>');
                            startTime = startAndFinishTime[0];
                            finishTime = startAndFinishTime[1];
                            title = lines[++line];
                            line++;
                            while (lines[line] != "~~~~~~")
                            {
                                content += lines[line];
                                line++;
                            }
                            line += 2;
                            
                            // if diary wasn't uploaded to database then upload it;
                            string query = "SELECT * FROM Diary where email = \"" + email + "\" and startTime = \"" + startTime + "\"";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            connection.Open();
                            MySqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                connection.Close();
                            }
                            else
                            {
                                connection.Close();
                                query = "insert into Diary(date, startTime, finishTime, title, content, email) VALUES (\"" + date.Replace(".txt", "") + "\", \"" + startTime + "\", \"" + finishTime + "\", \"" + title + "\", \"" + content + "\", \"" + email + "\")";
                                command = new MySqlCommand(query, connection);
                                connection.Open();
                                reader = command.ExecuteReader();
                                connection.Close();
                            }
                            content = "";
                        }
                    }
                }
            }
        }
    }
}
