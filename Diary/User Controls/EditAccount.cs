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

namespace Diary.User_Controls
{
    public partial class EditAccount : UserControl
    {
        MySqlConnection connection;
        string connectionString;
        string email;
        public EditAccount(string Email, string connectionTEXT)
        {
            email = Email;
            connectionString = connectionTEXT;
            connection = new MySqlConnection(connectionString);
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                string query = "DELETE FROM Diary where email = \"" + email + "\"; Delete from user where email =\"" + email + "\"";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Close();
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.Change_Information change_Information = new Forms.Change_Information(email, connectionString);
            change_Information.ShowDialog();
        }
    }
}
