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
using System.Security.Cryptography;

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
                    command = new OleDbCommand("Select Key FROM Files WHERE file = \"" + textBox1.Text + "\";", connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        FileStream str = new FileStream(textBox1.Text, FileMode.OpenOrCreate);
                        Byte[] newfile = AES_Encrypt(ReadFully(str), Encoding.ASCII.GetBytes(reader.GetString(0)));
                        //File.Delete(textBox1.Text);
                        FileStream newstr = new FileStream(textBox1.Text + "en", FileMode.Create);
                        foreach (byte b in newfile)
                        {
                            newstr.WriteByte(b);
                        }
                        connection.Close();
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                        textBox1.Text = "";
                        connection.Close();
                    }
                }
            }
        }

        private string key()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Decrpt
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

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
    }
}


