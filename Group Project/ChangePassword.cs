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
using System.Diagnostics;

namespace Group_Project
{
    public partial class ChangePassword : Form
    {
        // Variable holding Profile Name.
        public string profileName = "";

        public ChangePassword()
        {
            InitializeComponent();
        }

        // Method for button click confirming change password.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Checks if passwords are the same.
                if (newPassword.Text == confimPassword.Text)
                {
                    // Checks boundaries of the password.
                    if (newPassword.Text.Length > 2 && newPassword.Text.Length < 16)
                    {
                        // Connects to the database.
                        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                        {
                            // Selects the password from the database.
                            OleDbCommand command = new OleDbCommand("SELECT userPassword FROM Login WHERE Profile = \"" + profileName + "\";", connection);
                            connection.Open();
                            OleDbDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                // Sees if the password is equal to the entered password.
                                if (currentPassword.Text == reader.GetString(0))
                                {
                                    // Sets the new password to the database.
                                    command = new OleDbCommand("UPDATE Login SET userPassword = \"" + newPassword.Text + "\" WHERE Profile = \"" + profileName + "\";", connection);
                                    command.ExecuteNonQuery();
                                    connection.Close();
                                    MessageBox.Show("Updated Password for " + profileName + "!", "Update", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    this.Close();

                                }
                                // Elses in case of wrong data.
                                else
                                {
                                    MessageBox.Show("Error Updating Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    newPassword.Text = "";
                                    currentPassword.Text = "";
                                    confimPassword.Text = "";
                                    connection.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error Updating Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                newPassword.Text = "";
                                currentPassword.Text = "";
                                confimPassword.Text = "";
                                connection.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password needs to between 3 and 15 characters long!", "Error Updating Password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        newPassword.Text = "";
                        currentPassword.Text = "";
                        confimPassword.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Passwords Do Not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newPassword.Text = "";
                    confimPassword.Text = "";
                }
            }
            // Catches any exceptions from the application.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
