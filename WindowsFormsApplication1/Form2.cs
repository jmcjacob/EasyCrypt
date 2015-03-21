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
        public List<string> encyptedFiles = new List<string>();

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
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Object[] values = new Object[reader.FieldCount];
                    for (int i = 0; i <= reader.GetValues(values); i++)
                    {
                        encyptedFiles.Add(values[i].ToString());
                        Debug.WriteLine(values[i]);
                        

                    }
                    connection.Close();
                }
                else
                {
                    Debug.WriteLine("NOPE");
                }
            }
            comboBox1.DataSource = encyptedFiles;
            //.DataSource = encyptedFiles;
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
    }
}
