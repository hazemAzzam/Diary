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
namespace Diary.User_Controls
{
    public partial class AddNewDiary : UserControl
    {
        MySqlConnection connection; 
        string email;
        string connectionString;
        string startTime;
        public AddNewDiary(string text, string connectionTEXT)
        {
            email = text;
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionString);
            startTime = DateTime.Now.ToString("HH:mm:ss");
            InitializeComponent();
        }

        private void AddNewDiary_Load(object sender, EventArgs e)
        {

        }
        string pharse(string text)
        {
            string temp = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\"')
                    temp += '\\';
                temp += text[i];
            }
            return temp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            string finishTime = DateTime.Now.ToString("HH:mm:ss");
            string title = titleTXT.Text;
            string content = contentTXT.Text;
            content = pharse(content);
            if (CheckForInternetConnection() && connectionString != "")
            {
                string query = "insert into Diary(date, startTime, finishTime, title, content, email) VALUES (\"" + date + "\", \"" + startTime + "\", \"" + finishTime + "\", \"" + title + "\", \"" + content + "\", \"" + email + "\")";

                connection.Close();
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            else
            { 
                string yearDate = DateTime.UtcNow.ToString("yyyy");
                Directory.CreateDirectory("MyDiarys\\" + yearDate);
                using (StreamWriter write = File.AppendText("MyDiarys\\" + yearDate + "\\" + date + ".txt"))
                {
                    write.WriteLine(startTime + " --> " + finishTime + "\n" + title + "\n" + content + "\n~~~~~~\n");
                }
            }
            MessageBox.Show("Added");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (titleTXT.Text == "ضع عنوان")
                titleTXT.Text = "";
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (contentTXT.Text == "اكتب هنا")
                contentTXT.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                contentTXT.RightToLeft = RightToLeft.No;
                titleTXT.RightToLeft = RightToLeft.No;
            }
            else
            {
                contentTXT.RightToLeft = RightToLeft.Yes;
                titleTXT.RightToLeft = RightToLeft.Yes;
            }
        }
    }
}
