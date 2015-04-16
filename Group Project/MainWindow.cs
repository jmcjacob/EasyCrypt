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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Exists the application if the window is closed.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Method for scanning the NFC to continue to the next window.
        private void nfcScan_Click(object sender, EventArgs e)
        {
            try
            {
                // Connects to the database 
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    // Establishes connection with the card reader.
                    Card card = new Card();
                    card.SelectDevice();
                    card.establishContext();

                    // Selects the profile where the UID where the UID is the same as the UID from the database.
                    OleDbCommand command = new OleDbCommand("SELECT Profile FROM Login WHERE UID = \"" + card.searchForTag() + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Continues to the next window and transfers the Profile Name.
                        Encrpt en = new Encrpt();
                        en.profileName = reader.GetString(0);
                        en.setFiles();
                        en.label1.Text = "Hello " + en.profileName;
                        this.Hide();
                        en.Show();
                        connection.Close();
                    }
                    // Else in case the information is wrong.
                    else
                    {
                        connection.Close();
                        MessageBox.Show("Sorry no NFC Tag was found!", "Failed NFC Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            // Exception for if the NFC Reader is not connected.
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Make sure your NFC reader to connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Exception if there are any errors.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Opens the Login window.
        private void Login_Click(object sender, EventArgs e)
        {
            passwordLogin login = new passwordLogin();
            this.Hide();
            login.Show();
        }

        // Opens the Remove Profile window.
        private void remove_Click(object sender, EventArgs e)
        {
            RemoveProfile remove = new RemoveProfile();
            this.Hide();
            remove.Show();
        }

        // Opens the Add Profile window.
        private void AddProfile_Click(object sender, EventArgs e)
        {
            AddProfile add = new AddProfile();
            this.Hide();
            add.Show();
        }
    }
}
