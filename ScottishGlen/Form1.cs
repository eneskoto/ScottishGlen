using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Management;
namespace ScottishGlen
{
    public partial class Form1 : Form
    {

        mssql2102993Entities scGlenDB = new mssql2102993Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get IP
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            ipGen.Text = "System IP: " + myIP;
            
            //Get System name
            systemNamegen.Text = Environment.OSVersion.ToString();

            //Get pc model
            modelGen.Text = GetModel();

            //Get manufacturer
            manuGen.Text = GetBoardMaker();

            //Get type
            if (Environment.Is64BitOperatingSystem)
            {
                typeGen.Text = "64bit";
            }
            else
            {
                typeGen.Text = "32bit";
            }


        }
        public static string GetBoardMaker()
        {

            ManagementObjectSearcher finder = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in finder.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }

                catch { }

            }

            return "Board Maker: Unknown";

        }
        public static string GetModel()
        {

            ManagementObjectSearcher finder = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in finder.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();

                }

                catch { }

            }

            return "Product: Unknown";

        }
        private void initialTitle_Click(object sender, EventArgs e)
        {

        }

        private void addAssetBTN_Click(object sender, EventArgs e)
        {
            addAssetPanel.Visible = true;
        }

        private void addImaageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "png files (*.png)|*.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PictureBox PictureBox1 = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    PictureBox1.Image = new Bitmap(dlg.FileName);
                    PictureBox1.ImageLocation = dlg.FileName;
                    imagePic.Image = PictureBox1.Image;
                    imagePic.ImageLocation = PictureBox1.ImageLocation;
                }
            }
            //openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void submitNewAssetForm_Click(object sender, EventArgs e)
        {
            scottishGlen newAsset = new scottishGlen();

            newAsset.systemName = systemNameTextBox.Text;
            newAsset.model = modelTextBox.Text;
            newAsset.manufacturer = manuTextBox.Text;
            newAsset.type = typeTextBox.Text;
            newAsset.ipAdress = ipAdressTextBox.Text;
            newAsset.notes = notesTextBox.Text;

            newAsset.phySticker = ConvertFileToByte(imagePic.ImageLocation);
            scGlenDB.scottishGlens.Add(newAsset);

            scGlenDB.SaveChanges();


            MessageBox.Show("Asset added!");

            systemNameTextBox.Text = "System Name";
            modelTextBox.Text = "Model";
            manuTextBox.Text = "Manufacturer";
            typeTextBox.Text = "Type";
            ipAdressTextBox.Text = "IP Address";
            notesTextBox.Text = "Notes";
            imagePic.Image = null;

        }

        private byte[] ConvertFileToByte(string sPath)
        {
            byte[] data = null;
            FileInfo finfo = new FileInfo(sPath);
            long numBytes = finfo.Length;
            FileStream fstream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

    }
}
