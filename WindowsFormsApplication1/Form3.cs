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
using System.Diagnostics;
using System.Data.OleDb;

namespace GroupProject
{
    public partial class Form3 : Form
    {
        int retCode;
        int hCard;
        int hContext;
        int Protocol;
        public bool connActive = false;
        string readername = "ACS ACR122 0";
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public Card.SCARD_READERSTATE RdrState;
        public Card.SCARD_IO_REQUEST pioSendRequest;

        public Form3()
        {
            InitializeComponent();
        }

        public void SelectDevice()
        {
            List<string> availableReaders = this.ListReaders();
            this.RdrState = new Card.SCARD_READERSTATE();
            readername = availableReaders[0].ToString();//selecting first device
            this.RdrState.RdrName = readername;
        }

        public List<string> ListReaders()
        {
            int ReaderCount = 0;
            List<string> AvailableReaderList = new List<string>();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            retCode = Card.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show(Card.GetScardErrMsg(retCode));
                //connActive = false;
            }

            byte[] ReadersList = new byte[ReaderCount];

            //Get the list of reader present again but this time add sReaderGroup, retData as 2rd & 3rd parameter respectively.
            retCode = Card.SCardListReaders(hContext, null, ReadersList, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show(Card.GetScardErrMsg(retCode));
            }

            string rName = "";
            int indx = 0;
            if (ReaderCount > 0)
            {
                // Convert reader buffer to string
                while (ReadersList[indx] != 0)
                {
                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }
                    //Add reader name to list
                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;
                }
            }
            return AvailableReaderList;
        }

        internal void establishContext()
        {
            retCode = Card.SCardEstablishContext(Card.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Check your device and please restart again", "Reader not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connActive = false;
                return;
            }
        }

        public bool connectCard()
        {
            connActive = true;

            retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED,
                      Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != Card.SCARD_S_SUCCESS)
            {
                MessageBox.Show(Card.GetScardErrMsg(retCode), "Card not available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connActive = false;
                return false;
            }
            return true;
        }

        private string getcardUID()
        {
            string cardUID = "";
            byte[] receivedUID = new byte[256];
            Card.SCARD_IO_REQUEST request = new Card.SCARD_IO_REQUEST();
            request.dwProtocol = Card.SCARD_PROTOCOL_T1;
            request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Card.SCARD_IO_REQUEST));
            byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //get UID command      for Mifare cards
            int outBytes = receivedUID.Length;
            int status = Card.SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);

            if (status != Card.SCARD_S_SUCCESS)
            {
                cardUID = "Error";
            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToLower();
            }

            return cardUID;
        }

        public string searchForTag()
        {
            while (true)
            {
                retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED, Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);
                if (retCode == Card.SCARD_S_SUCCESS)
                {
                    string UID = getcardUID();
                    Debug.WriteLine("UID: " + UID);
                    return UID;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectDevice();
            establishContext();
            string UID = searchForTag();
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;"))
            {
                OleDbCommand command = new OleDbCommand("SELECT UID FROM Login WHERE UID = \"" + UID + "\";", connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Tag already assigned to a profile!");
                }
                else
                {
                    textBox1.Text = UID;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;"))
                {
                    OleDbCommand command1 = new OleDbCommand("SELECT Profile FROM Login WHERE Profile = \"" + textBox2.Text + "\";", connection);
                    connection.Open();
                    OleDbDataReader reader1 = command1.ExecuteReader();
                    if (reader1.Read())
                    {
                        MessageBox.Show("Profile Name already exsits!");
                            textBox2.Text = "";
                    }
                    else
                    {
                        OleDbCommand command2 = new OleDbCommand("SELECT Password FROM Login WHERE Password = \"" + textBox3.Text + "\";", connection);
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        if (reader2.Read())
                        {
                            MessageBox.Show("Password already exsists!");
                            textBox3.Text = "";
                            textBox4.Text = "";
                        }
                        else
                        {
                            if (textBox1.Text != "")
                            {
                                OleDbCommand command3 = new OleDbCommand("INSERT INTO Login VALUES (\"" + textBox2.Text + "\", \"" + textBox1.Text + "\", \"" + textBox3.Text + "\", \"" + newKey() + "\");", connection);
                                command3.ExecuteNonQuery();
                                MessageBox.Show(textBox2.Text + " Added!");
                                Application.Restart();
                            }
                            else
                            {
                                MessageBox.Show("You need an NFC Tag!");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
            }
        }

        string newKey()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
