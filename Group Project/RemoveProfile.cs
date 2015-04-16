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
    public partial class RemoveProfile : Form
    {
        // String to hold UID value obtained from NFC scanner.
        string UID = "";

        public RemoveProfile()
        {
            InitializeComponent();
        }

        // Override method that exists the application on closing.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Method to scan the NFC tag and store UID.
        private void nfcScan_Click(object sender, EventArgs e)
        {
            try
            {
                nfcScan.ForeColor = Color.RoyalBlue;

                // Sets up the Card Reader.
                Card card = new Card();
                card.SelectDevice();
                card.establishContext();

                // Connects to the local database.
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    // Opens the connection and executes SQL command to a data reader.
                    OleDbCommand command = new OleDbCommand("SELECT UID FROM Login WHERE UID = \"" + card.searchForTag() + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Sets UID and closes connection.
                        UID = reader.GetString(0);
                        nfcScan.ForeColor = Color.Green;
                        connection.Close();
                    }
                    else
                    {
                        // Displays error message is NFC Tag dose not exists in the current database.
                        nfcScan.ForeColor = Color.RoyalBlue;
                        connection.Close();
                        MessageBox.Show("Sorry no NFC Tag was found!", "Failed NFC Scan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            // Catches any exception thrown
            catch (ArgumentOutOfRangeException)
            {
                nfcScan.ForeColor = Color.Black;
                MessageBox.Show("Make sure your NFC reader to connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                nfcScan.ForeColor = Color.Black;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to check all inputted values against each other and the database then to delete the entry in the database.
        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the two passwords are the same. 
                if (password.Text == passwordCon.Text)
                {
                    // Connects to the database.
                    using (OleDbConnection connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                    {
                        // Runs the command on the database to a data reader.
                        OleDbCommand command = new OleDbCommand("SELECT userPassword FROM Login WHERE Profile = \"" + profileName.Text + "\";", connect);
                        connect.Open();
                        OleDbDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Checks if the read data is the same as the entered data.
                            if (password.Text == reader.GetString(0))
                            {
                                // Selects the UID where the profile name is the same as the entered one.
                                command = new OleDbCommand("SELECT UID FROM Login WHERE Profile = \"" + profileName.Text + "\";", connect);
                                reader = command.ExecuteReader();
                                if (UID != "" && reader.Read())
                                {
                                    // Checks if the entered UID is equal to the Profile UID.
                                    if (UID == reader.GetString(0))
                                    {
                                        DialogResult result = MessageBox.Show("Are you sure you want to Delete this profile?", "Delete Profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        if (result == DialogResult.Yes)
                                        {
                                            // Deletes the row from the database.
                                            command = new OleDbCommand("DELETE FROM Login WHERE Profile = \"" + profileName.Name + "\";", connect);
                                            command.ExecuteNonQuery();
                                            connect.Close();
                                            MessageBox.Show(profileName.Text + " Deleted!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            nfcScan.ForeColor = Color.RoyalBlue;

                                            UID = "";
                                            profileName.Text = "";
                                            password.Text = "";
                                            passwordCon.Text = "";
                                        }
                                        // Elses that close connection and reset the fields in the window.
                                        else if (result == DialogResult.No)
                                        {
                                            connect.Close();
                                            nfcScan.ForeColor = Color.Black;
                                            UID = "";
                                            password.Text = "";
                                            passwordCon.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error Logging into system!", "Error Finding Profile!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            connect.Close();
                                            nfcScan.ForeColor = Color.Black;
                                            UID = "";
                                            password.Text = "";
                                            passwordCon.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error Logging into system!", "Error Finding Profile!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        nfcScan.ForeColor = Color.Black;
                                        UID = "";
                                        connect.Close();
                                        password.Text = "";
                                        passwordCon.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error Logging into system!", "Error Finding Profile!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    nfcScan.ForeColor = Color.Black;
                                    UID = "";
                                    connect.Close();
                                    password.Text = "";
                                    passwordCon.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error Logging into system!", "Error Finding Profile!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                nfcScan.ForeColor = Color.Black;
                                UID = "";
                                connect.Close();
                                password.Text = "";
                                passwordCon.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error Logging into system!", "Error Finding Profile!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nfcScan.ForeColor = Color.Black;
                            UID = "";
                            connect.Close();
                            password.Text = "";
                            passwordCon.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Passwords Do Not Match!", "Error Finding Profile!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    password.Text = "";
                    passwordCon.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Returns to the main screen of the application.
        private void Back_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }
}
