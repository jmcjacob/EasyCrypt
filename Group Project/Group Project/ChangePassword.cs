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
        public string profileName = "";

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (newPassword.Text == confimPassword.Text)
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    OleDbCommand command = new OleDbCommand("SELECT Password FROM Login WHERE Profile = \"" + profileName + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (currentPassword.Text == reader.GetString(0))
                        {
                            try
                            {
                                string temp;
                                temp = "ABC";
                                command = new OleDbCommand("UPDATE Login SET UID = \"" + temp + "\" WHERE Profile = \"" + profileName + "\";", connection);
                                command.ExecuteNonQuery();

                                //  Debug.WriteLine("UPDATE Login SET Password = \"" + newPassword.Text + "\" WHERE Profile = \"" + profileName + "\";", connection);
                                //string temp2 = newPassword.Text.ToString();
                                string temp2 = "qqq";

                                command = new OleDbCommand("UPDATE test SET Password_AA = \"" + temp2 + "\" WHERE Profile = \"" + profileName + "\";", connection);
                                //command.CommandText = "UPDATE Login(Password) VALUES (@ln, @fn, @add, @cit) WHERE Profile='" + profileName + "' AND FirstName='" + firstName + "'";
                                command.ExecuteNonQuery();
                                connection.Close();
                                MessageBox.Show("Updated Password for " + profileName + "!", "Update", MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Passwords Do Not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newPassword.Text = "";
                confimPassword.Text = "";
            }
        }
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
    }
}
