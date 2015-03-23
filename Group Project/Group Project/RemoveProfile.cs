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
        string UID = "";

        public RemoveProfile()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void nfcScan_Click(object sender, EventArgs e)
        {
            try
            {
                nfcScan.ForeColor = Color.RoyalBlue;
                Card card = new Card();
                card.SelectDevice();
                card.establishContext();
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    OleDbCommand command = new OleDbCommand("SELECT UID FROM Login WHERE UID = \"" + card.searchForTag() + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        UID = reader.GetString(0);
                        nfcScan.ForeColor = Color.Green;
                        connection.Close();
                    }
                    else
                    {
                        nfcScan.ForeColor = Color.Black;
                        connection.Close();
                        MessageBox.Show("Sorry no NFC Tag was found!", "Failed NFC Scan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
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

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (password.Text == passwordCon.Text)
                {
                    using (OleDbConnection connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                    {
                        OleDbCommand command = new OleDbCommand("SELECT Password FROM Login WHERE Profile = \"" + profileName.Text + "\";", connect);
                        connect.Open();
                        OleDbDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            if (password.Text == reader.GetString(0))
                            {
                                command = new OleDbCommand("SELECT UID FROM Login WHERE Profile = \"" + profileName.Text + "\";", connect);
                                reader = command.ExecuteReader();
                                if (UID != "" && reader.Read())
                                {
                                    if (UID == reader.GetString(0))
                                    {
                                        var result = MessageBox.Show("Are you sure you want to Delete this profile?", "Delete Profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        if (result == DialogResult.Yes)
                                        {
                                            command = new OleDbCommand("DELETE FROM Login WHERE Profile = \"" + profileName.Name + "\";", connect);
                                            command.ExecuteNonQuery();
                                            connect.Close();
                                            nfcScan.ForeColor = Color.Black;

                                            UID = "";
                                            profileName.Text = "";
                                            password.Text = "";
                                            passwordCon.Text = "";
                                        }
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
                                            MessageBox.Show("Error Logging into system!", "Error Finding Profie!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            connect.Close();
                                            nfcScan.ForeColor = Color.Black;
                                            UID = "";
                                            password.Text = "";
                                            passwordCon.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error Logging into system!", "Error Finding Profie!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        nfcScan.ForeColor = Color.Black;
                                        UID = "";
                                        connect.Close();
                                        password.Text = "";
                                        passwordCon.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error Logging into system!", "Error Finding Profie!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    nfcScan.ForeColor = Color.Black;
                                    UID = "";
                                    connect.Close();
                                    password.Text = "";
                                    passwordCon.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error Logging into system!", "Error Finding Profie!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                nfcScan.ForeColor = Color.Black;
                                UID = "";
                                connect.Close();
                                password.Text = "";
                                passwordCon.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error Logging into system!", "Error Finding Profie!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void Back_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }
}
