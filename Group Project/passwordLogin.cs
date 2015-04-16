using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Group_Project
{
    public partial class passwordLogin : Form
    {
        public passwordLogin()
        {
            InitializeComponent();
        }

        // Exits the application when the form is closed.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Method for when the login button is clicked that looks at the entered data and checks continues the application to the next window.
        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Connects to the database.
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    // Selects the password from the database where the profile name is equal to the entered profile name.
                    OleDbCommand command = new OleDbCommand("SELECT userPassword FROM Login WHERE Profile = \"" + textBox1.Text + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Checks if the entered password is equal to the password.
                        if (reader.GetString(0) == textBox2.Text)
                        {
                            // Opens the next window carrying the profile name.
                            Encrpt en = new Encrpt();
                            en.profileName = textBox1.Text;
                            en.setFiles();
                            en.label1.Text = "Hello " + en.profileName;
                            this.Hide();
                            en.Show();
                            connection.Close();
                            connection.Close();
                        }
                        // Elses in case details are wrong.
                        else
                        {
                            MessageBox.Show("Sorry there was an error logging in!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            connection.Close();
                            textBox2.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry there was an error logging in!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        connection.Close();
                        textBox2.Text = "";
                    }
                }
            }
            // Exception in case any problems occur.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Takes the application back to the previous window.
        private void back_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
