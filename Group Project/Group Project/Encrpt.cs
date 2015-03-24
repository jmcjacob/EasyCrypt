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
using System.Security.Cryptography;

namespace Group_Project
{
    public partial class Encrpt : Form
    {
        public string profileName;
        string extension = ".magic";

        public Encrpt()
        {
            InitializeComponent();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void setFiles()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    OleDbCommand command = new OleDbCommand("SELECT File FROM Files WHERE Profile = \"" + profileName + "\";", connection);
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        decryptPath.Items.Add(row["File"].ToString());
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string key()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        private void findPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                encryptPath.Text = ofd.FileName;
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
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
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

        private void encryptFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Path.GetExtension(encryptPath.Text) == extension)
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                    {
                        OleDbCommand command = new OleDbCommand("SELECT File FROM Files WHERE File = \"" + encryptPath.Text + "\";", connection);
                        connection.Open();
                        OleDbDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show("THIS SHOULDN'T BE ACCESSIBLE!!!", "WTF", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            connection.Close();
                        }
                        else
                        {
                            string temp = key();
                            command = new OleDbCommand("INSERT INTO Files VALUES (\"" + profileName + "\", \"" + encryptPath.Text + "\", \"" + temp + "\");", connection);
                            command.ExecuteNonQuery();
                            MessageBox.Show(encryptPath.Text + " Has Been Added!", "Added File!", MessageBoxButtons.OK, MessageBoxIcon.None);
                            decryptPath.Items.Add(encryptPath.Text);
                            connection.Close();

                            FileStream str = new FileStream(Path.GetFullPath(encryptPath.Text), FileMode.Open);
                            Byte[] newFile = AES_Encrypt(ReadFully(str), Encoding.ASCII.GetBytes(temp));
                            str.Close();
                            FileStream newstr = new FileStream(Path.GetDirectoryName(encryptPath.Text) + "\\" + Path.GetFileNameWithoutExtension(encryptPath.Text) + extension, FileMode.Create);
                            foreach (byte b in newFile)
                            {
                                newstr.WriteByte(b);
                            }
                            newstr.Close();
                            File.Delete(encryptPath.Text);
                            encryptPath.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This file is already encrypted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                encryptPath.Text = "";
            }
        }

        private void decryptFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    OleDbCommand command = new OleDbCommand("SELECT Key FROM Files WHERE File = \"" + decryptPath.SelectedItem.ToString() + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        FileStream str = new FileStream(Path.GetDirectoryName(decryptPath.SelectedItem.ToString()) + "\\" + Path.GetFileNameWithoutExtension(decryptPath.SelectedItem.ToString()) + extension, FileMode.Open);
                        Byte[] newFile = AES_Decrypt(ReadFully(str), Encoding.ASCII.GetBytes(reader.GetString(0)));
                        str.Close();
                        FileStream newstr = new FileStream(Path.GetFullPath(decryptPath.SelectedItem.ToString()), FileMode.Create);
                        foreach(byte b in newFile)
                        {
                            newstr.WriteByte(b);
                        }
                        newstr.Close();
                        File.Delete(Path.GetDirectoryName(decryptPath.SelectedItem.ToString()) + "\\" + Path.GetFileNameWithoutExtension(decryptPath.SelectedItem.ToString()) + extension);
                        command = new OleDbCommand("DELETE FROM Files WHERE File = \"" + decryptPath.SelectedItem.ToString() + "\";", connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("THIS SHOULDN'T BE ACCESSIBLE!!!", "WTF", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
