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
        // Variables to be used in the application.
        public string profileName;
        string extension = ".easycrypt";

        public Encrpt()
        {
            InitializeComponent();
        }

        // Exits the application on window close.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Finds all the encrypted files for the profile and adds them to a drop down list.
        public void setFiles()
        {
            try
            {
                // Connects to the database.
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.accdb;Jet OLEDB:Database Password=01827711125;"))
                {
                    // Finds all files associated with the Profile.
                    OleDbCommand command = new OleDbCommand("SELECT File FROM Files WHERE Profile = \"" + profileName + "\";", connection);
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    // Goes through each file and adds it to the drop down list.
                    foreach (DataRow row in table.Rows)
                    {
                        decryptPath.Items.Add(row["File"].ToString());
                    }
                    connection.Close();
                }
            }
            // Catches any exceptions that method may throw.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method for generating a random string used as keys for encrypted files.
        private string key()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        // Opens a window to locate files and add them to the field.
        private void findPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                encryptPath.Text = ofd.FileName;
            }
        }

        // Method that will encrypt arrays of bytes based off another array of passwords bytes.
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
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

        // Method that will decrypt arrays of bytes based off another array of passwords bytes.
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
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

        // Method that reads File stream and returns an array of bytes.
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                // Creates a Memory Stream and writes the file to it.
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                // Converts the Memory stream into a byte array.
                return ms.ToArray();
            }
        }

        // Method to encrypt Files.
        private void encryptFile_Click(object sender, EventArgs e)
        {
            try
            {
                //
                if (Path.GetExtension(encryptPath.Text) != extension)
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
                            MessageBox.Show(encryptPath.Text + " Has Been Encrypted!", "Encrypted File!", MessageBoxButtons.OK, MessageBoxIcon.None);
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
                        MessageBox.Show(encryptPath.Text + " Has Been Decrypted!", "Decrypted File!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        command = new OleDbCommand("DELETE FROM Files WHERE File = \"" + decryptPath.SelectedItem.ToString() + "\";", connection);
                        command.ExecuteNonQuery();
                        decryptPath.Items.Remove(decryptPath.SelectedItem.ToString());
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

        // Goes back to the previous window.
        private void LogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // Opens the Change NFC window.
        private void changeNFC_Click(object sender, EventArgs e)
        {
            ChangeNFC nfc = new ChangeNFC();
            nfc.profileName = profileName;
            nfc.Show();
        }

        // Opens the Change Password window.
        private void changePassword_Click(object sender, EventArgs e)
        {
            ChangePassword pass = new ChangePassword();
            pass.profileName = profileName;
            pass.Show();
        }
    }
}
