using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows;
using System.IO;

namespace Diary.Forms
{
    public partial class Dashboard : Form
    {
        //MySqlConnection connection = new MySqlConnection("Server=192.168.1.108;Database=Diary;User Id=root;Password=SqlAdmin;"); 
        MySqlConnection connection;
        string connectionString;
        string email;
        public Dashboard(string text, string name, string connectionTEXT)
        {
            email = text;
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionTEXT);
            InitializeComponent();
            label2.Text = name;
            try
            {
                User_Controls.ViewAll viewAll = new User_Controls.ViewAll(email, connectionString);
                panel3.Controls.Clear();
                viewAll.Dock = DockStyle.Fill;
                panel3.Controls.Add(viewAll);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (addNewButton.BackColor == Color.FromArgb(129, 0, 52))
            {

            }
            else
            {
                addNewButton.BackColor = Color.FromArgb(135, 67, 29);
                viewAllButton.BackColor = Color.FromArgb(41, 0, 1);
                editAccountButton.BackColor = Color.FromArgb(41, 0, 1);

                User_Controls.AddNewDiary addnewDiary = new User_Controls.AddNewDiary(email, connectionString);
                addnewDiary.Dock = DockStyle.Fill;
                panel3.Controls.Clear();

                panel3.Controls.Add(addnewDiary);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewAllButton.BackColor = Color.FromArgb(135, 67, 29);
            addNewButton.BackColor = Color.FromArgb(41, 0, 1);
            editAccountButton.BackColor = Color.FromArgb(41, 0, 1);

            //if (CheckForInternetConnection())
            //{
            //    upload(email);
            //}
            try
            {
                User_Controls.ViewAll viewAll = new User_Controls.ViewAll(email, connectionString);
                panel3.Controls.Clear();
                viewAll.Dock = DockStyle.Fill;
                panel3.Controls.Add(viewAll);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //if (CheckForInternetConnection())
            //{
            //    upload(email);
            //}
        }
        void delete()
        {
            string query = "DELETE FROM Diary WHERE Email = \"" + email + "\"";
            connection.Close();
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            connection.Close();
        }
        void upload(string email)
        {
            delete();
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
                                content += lines[line] + "\n";
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
            else
            {
                MessageBox.Show("No internet Connection to upload");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editAccountButton.BackColor = Color.FromArgb(135, 67, 29);
            addNewButton.BackColor = Color.FromArgb(41, 0, 1);
            viewAllButton.BackColor = Color.FromArgb(41, 0, 1);
            

            panel3.Controls.Clear();
            User_Controls.EditAccount editAccount = new User_Controls.EditAccount(email, connectionString);
            editAccount.Dock = DockStyle.Fill;
            panel3.Controls.Add(editAccount);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button7_Click(object sender, EventArgs e)
        {
            download();
        }

        void download()
        {
            if (CheckForInternetConnection())
            {
                string query = "Select title, year(date), date, startTime, finishTime, Content from Diary Where Email =\"" + email + "\"";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Close();
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (Directory.Exists("MyDiarys"))
                    Directory.Delete("MyDiarys", true);

                while (reader.Read())
                {
                    string title = reader.GetString(0);
                    string yearDate = reader.GetString(1);
                    string date = reader.GetString(2);
                    string startTime = reader.GetString(3);
                    string finishTime = reader.GetString(4);
                    string content = reader.GetString(5);


                    Directory.CreateDirectory("MyDiarys\\" + yearDate);


                    using (StreamWriter write = File.AppendText("MyDiarys\\" + yearDate + "\\" + date + ".txt"))
                    {
                        write.WriteLine(startTime + " --> " + finishTime + "\n" + title + "\n" + content + "\n~~~~~~\n");
                    }
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("No internet connection to douwnload");
            }
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
                return false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                upload(email);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            delete();
        }
    }
}
