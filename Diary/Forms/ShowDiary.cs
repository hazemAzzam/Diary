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
    public partial class ShowDiary : Form
    {
        MySqlConnection connection;
        string connectionString;
        string date;
        string title;
        string contentOffline;
        string startTime;
        string finishTime;
        string email;
        int DiaryID;

        public ShowDiary(int ID, string Email, string connectionTEXT, string Title, string StartTime, string FinishTime, string Content, string Date)
        {
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionTEXT);
            email = Email;
            DiaryID = ID;
            title = Title;
            startTime = StartTime;
            finishTime = FinishTime;
            contentOffline = Content;
            date = Date;
            InitializeComponent();

        }


        private void ShowDiary_Load(object sender, EventArgs e)
        {
            if (CheckForInternetConnection() && connectionString != "")
            {
                string query = "SELECT * FROM Diary WHERE email = \"" + email + "\" AND ID = " + DiaryID + " order by Date desc";
                connection.Close();
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dateLBL.Text = reader.GetString(1);
                    startTimeLBL.Text = reader.GetString(2);
                    finishTimeLBL.Text = reader.GetString(3);
                    titleLBL.Text = reader.GetString(4);
                    contentTEXT.Text = reader.GetString(5);
                }
                connection.Close();
            }
            else
            {
                dateLBL.Text = date;
                startTimeLBL.Text = startTime;
                finishTimeLBL.Text = finishTime;
                titleLBL.Text = title;
                contentTEXT.Text = contentOffline;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                string query = "Delete from Diary where id = " + DiaryID + " and email = \"" + email + "\"";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            else
            {
                MessageBox.Show("You can't delete until you connect to internet!!");
            }
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                return false;
            }
        }
        void update()
        {
            string title = titleLBL.Text;
            string content = contentTEXT.Text;
            string query = "UPDATE Diary SET Title=\"" + title + "\", Content = \"" + content + "\" where email = \"" + email + "\" and ID = " + DiaryID;
            connection.Close();
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MessageBox.Show("Done");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            contentTEXT.SelectionStart += 30;
            contentTEXT.ScrollToCaret();
        }

        private void contentTEXT_TextChanged(object sender, EventArgs e)
        {
            saveButton.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
