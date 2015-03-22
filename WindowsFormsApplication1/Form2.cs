using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace GroupProject
{
    public partial class Form2 : Form
    {
        public string profileName;

        public Form2()
        {
            InitializeComponent();
            label1.Text = "Hello " + profileName;
        }

        // THIS NEEDS WORK
        public void setFiles()
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;"))
            {
                OleDbCommand command = new OleDbCommand("SELECT File FROM Files WHERE Profile = \"" + profileName + "\";", connection);
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    comboBox1.Items.Add(row["File"].ToString());
                }
                connection.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;"))
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand("SELECT File FROM Files WHERE File = \"" + textBox1.Text + "\";", connection);
                OleDbDataReader reader = command1.ExecuteReader();
                if (reader.Read())
                {
                    // Error Box should go here that makes sence.
                    MessageBox.Show("Hmmm");
                    textBox1.Text = "";
                }
                else
                {
                    OleDbCommand command = new OleDbCommand("INSERT INTO Files VALUES (\"" + profileName + "\", \"" + textBox1.Text + "\", \"" + key() + "\");", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(textBox1.Text + " Has been Added!");
                    comboBox1.Items.Add(textBox1.Text);
                    connection.Close();
                    textBox1.Text = "";
                }
            }
        }

        private string key()
        {
            return "Key";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Stuff happens
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;"))
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Files WHERE File = \"" + comboBox1.Text + "\";", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            comboBox1.Items.Remove(comboBox1.Text);
            MessageBox.Show(comboBox1.Text + " Decrpted");
        }
    }
}
