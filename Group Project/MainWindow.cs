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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
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
                    OleDbCommand command = new OleDbCommand("SELECT Profile FROM Login WHERE UID = \"" + card.searchForTag() + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Encrpt en = new Encrpt();
                        en.profileName = reader.GetString(0);
                        en.setFiles();
                        en.label1.Text = "Hello " + en.profileName;
                        this.Hide();
                        en.Show();
                        connection.Close();
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("Sorry no NFC Tag was found!", "Failed NFC Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void Login_Click(object sender, EventArgs e)
        {
            passwordLogin login = new passwordLogin();
            this.Hide();
            login.Show();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            RemoveProfile remove = new RemoveProfile();
            this.Hide();
            remove.Show();
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            AddProfile add = new AddProfile();
            this.Hide();
            add.Show();
        }
    }
}
