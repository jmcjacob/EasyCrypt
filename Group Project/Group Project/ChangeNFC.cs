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
    public partial class ChangeNFC : Form
    {
        public string profileName = "";

        public ChangeNFC()
        {
            InitializeComponent();
        }

        private void nfcScan_Click(object sender, EventArgs e)
        {
            try
            {
                Card card = new Card();
                card.SelectDevice();
                card.establishContext();
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    string temp = card.searchForTag();
                    OleDbCommand command = new OleDbCommand("SELECT UID FROM Login WHERE UID = \"" + temp + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        connection.Close();
                        MessageBox.Show("Sorry that NFC Tag is already in use!", "Failed NFC Register!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        command = new OleDbCommand("UPDATE Login SET UID =\"" + temp + "\" WHERE Profile = \"" + profileName + "\";", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Updated NFC Tag for " + profileName + "!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.None);
                        connection.Close();
                        this.Close();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Make sure your NFC reader to connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
