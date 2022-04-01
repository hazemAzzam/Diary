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
using System.IO;


namespace Diary.User_Controls
{
    public partial class ViewAll : UserControl
    {
        MySqlConnection connection;
        string connectionString;
        string email;

        int panelHeight = 0;
        public ViewAll(string text, string  connectionTEXT)
        {
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionString);
            email = text;
            InitializeComponent();
            try
            {
                load_information();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            panel4.MouseWheel += panel4_Scroll;
        }


        void load_information()
        {
            if (CheckForInternetConnection())
            {
                string query = "select * from (Diary d natural join User) where email = \"" + email + "\"";
                connection.Close();
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    printDiary(counter, reader.GetInt32(1), reader.GetString(5), reader.GetString(2));
                    counter++;
                    panelHeight += 75;
                }
            }
            else
            {
                try
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
                                    int counter = 0;
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
                                    line++;
                                    line++;
                                    printOfflineDiary(counter, title, date.Replace(".txt", ""), startTime, finishTime, content);
                                    counter++;
                                    content = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You had not save any diarys!!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                
            }
            
        }
        private void ViewAll_Load(object sender, EventArgs e)
        {
            
        }
        private void OnClick(object sender, EventArgs e)
        {
            myObj button = sender as myObj;
            Forms.ShowDiary showDiary = new Forms.ShowDiary(button.DiaryID, email, connectionString, "", "", "", "", "");
            showDiary.ShowDialog();
        }
        private void OnOfflineClick(object sender, EventArgs e)
        {
            myOfflineObj button = sender as myOfflineObj;
            Forms.ShowDiary showDiary = new Forms.ShowDiary(0, "", "", button.title, button.startTime, button.finishTime, button.content, button.Date);
            showDiary.ShowDialog();
        }
        private void panel4_Scroll(object sender, MouseEventArgs e)
        {
            int mousedeltaval = e.Delta / 120;
            if (mousedeltaval == 1) //mousewheel up move
            {
                mouseDown();
            }
            if (mousedeltaval == -1) //mousewheel down move
            {
                mouseUp();
            }
        }
        public class myObj : Panel
        {
            public int DiaryID { get; set; }
            public string Date { get; set; }
            public string title { get; set; }
            
            public void draw()
            {
                Label textDate = new Label();
                Label textTitle = new Label();

                textDate.Text = Date;
                textDate.Location = new Point(50, 23);
                textDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textDate.Size = new Size(163, 29);
                textDate.Dock = DockStyle.Left;
                

                textTitle.Text = title;
                textTitle.Location = new Point(this.Width - 50, 23);
                textTitle.Size = new Size(195, 29);
                textTitle.RightToLeft = RightToLeft.Yes;
                //textTitle.Anchor = AnchorStyles.Top;
                //textTitle.Anchor = AnchorStyles.Bottom;
                textTitle.Anchor = AnchorStyles.Right;
                textTitle.Dock = DockStyle.Right;

                this.BackColor = Color.FromArgb(29, 33, 37);
                this.Size = new Size(709, 75);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Anchor = AnchorStyles.Left;
                this.Anchor = AnchorStyles.Right;
                this.Anchor = AnchorStyles.Top;
                this.Dock = DockStyle.Top;
                this.Controls.Add(textDate);
                this.Controls.Add(textTitle);
            }
        }

        public class myOfflineObj : myObj
        {
            public string content { get; set; }
            public string startTime { get; set; }
            public string finishTime { get; set; }

            
        }
        private void changeHover(object sender, EventArgs e)
        {
            myObj myObj = sender as myObj;
            myObj.BackColor = Color.FromArgb(47, 54, 61);
        }
        private void changeHoverLeaver(object sender, EventArgs e)
        {
            myObj myObj = sender as myObj;
            myObj.BackColor = Color.FromArgb(29, 33, 37);
        }

        private void offlineChangeHover(object sender, EventArgs e)
        {
            myOfflineObj myObj = sender as myOfflineObj;
            myObj.BackColor = Color.FromArgb(200, 121, 65);
        }
        private void offlineChangeHoverLeaver(object sender, EventArgs e)
        {
            myOfflineObj myObj = sender as myOfflineObj;
            myObj.BackColor = Color.FromArgb(135, 67, 29);
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

        void printDiary(int counter, int DiaryID, string title, string Date)
        {
            myObj button = new myObj();
            //button.Text = text;
            button.Width = 500;
            button.Height = 62;
            button.Anchor = AnchorStyles.Left;
            button.Anchor = AnchorStyles.Top;
            //button.FlatStyle = FlatStyle.Flat;
            button.BorderStyle = BorderStyle.None;
            button.Location = new Point(17, button.Height * counter);
            button.Click += OnClick;
            button.MouseHover += changeHover;
            button.MouseLeave += changeHoverLeaver;
            
            button.DiaryID = DiaryID;
            button.title = title;
            button.Date = Date;
            panel4.Controls.Add(button);
            counter++;
            button.draw();
        }

        void printOfflineDiary(int counter, string title, string Date, string startTime, string finishTime, string content)
        {
            try
            {
                myOfflineObj button = new myOfflineObj();
                //button.Text = text;
                button.startTime = startTime;
                button.finishTime = finishTime;
                button.content = content;
                button.Width = 500;
                button.Height = 62;
                button.Anchor = AnchorStyles.Left;
                button.Anchor = AnchorStyles.Top;
                //button.FlatStyle = FlatStyle.Flat;
                button.BorderStyle = BorderStyle.None;
                button.Location = new Point(17, button.Height * counter);
                button.Click += OnOfflineClick;
                button.MouseHover += offlineChangeHover;
                button.MouseLeave += offlineChangeHoverLeaver;

                button.title = title;
                button.Date = Date;
                panel4.Controls.Add(button);
                counter++;
                button.draw();
            }
            catch(Exception r)
            {
                MessageBox.Show(r.ToString());
            }
        }

        int distance = 75;
        void mouseUp()
        {
            if (panel4.Bottom <= this.Bottom)
            {

            }
            else
            {
                panel4.Top -= distance;
            }
        }
        void mouseDown()
        {
            if (panel4.Top == this.Top)
            {

            }
            else
            {
                //panel4.Height -= distance;
                panel4.Top += distance;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mouseUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height += distance;
            panel4.Top += distance;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mouseDown();
        }

        private void ViewAll_Resize(object sender, EventArgs e)
        {
            panel4.Width = this.Width;
            panel4.Height = panelHeight;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
