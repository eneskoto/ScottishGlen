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
using BCrypt.Net;

namespace ScottishGlen
{
    public partial class Form1 : Form
    {

        mssql2102993Entities4 scGlenDB = new mssql2102993Entities4();
        //List<scottishGlen> scGlenObj = new List<scottishGlen>();

        private bool switchMode,adminLogged;

        
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
            ipAdressTextBox.Text = myIP;

            //Get System name
            systemNamegen.Text = Environment.OSVersion.ToString();
            systemNameTextBox.Text = Environment.OSVersion.ToString();

            //Get pc model
            modelGen.Text = GetModel();
            modelTextBox.Text = GetModel();

            //Get manufacturer
            manuGen.Text = GetBoardMaker();
            manuTextBox.Text = GetBoardMaker();

            //Get type
            if (Environment.Is64BitOperatingSystem)
            {
                typeGen.Text = "64bit";
                typeTextBox.Text = "64bit";
            }
            else
            {
                typeGen.Text = "32bit";
                typeTextBox.Text = "32bit";
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
            editPanel.Hide();
            switchMode = false;
            addAssetPanel.Visible = true;
            viewHApanel.Visible = false;
            viewSApanel.Visible = false;
            //Get System name
            systemNamegen.Text = Environment.OSVersion.ToString();
            systemNameTextBox.Text = Environment.OSVersion.ToString();

            //Get pc model
            modelGen.Text = GetModel();
            modelTextBox.Text = GetModel();

            //Get manufacturer
            manuGen.Text = GetBoardMaker();
            manuTextBox.Text = GetBoardMaker();


            //Get type
            typeGen.Show();
            typeTextBox.Show();
            
            if (Environment.Is64BitOperatingSystem)
            {
                typeGen.Text = "64bit";
                typeTextBox.Text = "64bit";
            }
            else
            {
                typeGen.Text = "32bit";
                typeTextBox.Text = "32bit";
            }

            //Get IP
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            ipGen.Text = "System IP: " + myIP;
            ipAdressTextBox.Text = myIP;

            ipGen.Show();
            ipAdressTextBox.Show();


            notesTextBox.Show();
            addImaageButton.Show();
            imagePic.Show();

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
            if (adminLogged)
            {
                if (!switchMode)
                {
                    scottishGlen newAsset = new scottishGlen();

                    newAsset.systemName = systemNameTextBox.Text;
                    newAsset.model = modelTextBox.Text;
                    newAsset.manufacturer = manuTextBox.Text;
                    newAsset.type = typeTextBox.Text;
                    newAsset.ipAdress = ipAdressTextBox.Text;
                    newAsset.notes = notesTextBox.Text;

                    if (imagePic.ImageLocation != null)
                    {
                        newAsset.phySticker = ConvertFileToByte(imagePic.ImageLocation);
                    }
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
                else
                {
                    softrec newAsset = new softrec();

                    newAsset.sysName = systemNameTextBox.Text;
                    newAsset.sysVersion = modelTextBox.Text;
                    newAsset.sysManufacturer = manuTextBox.Text;

                    int hardwareID;

                    if (int.TryParse(typeTextBox.Text, out hardwareID) == true)
                    {
                        newAsset.hardwareID = int.Parse(typeTextBox.Text);
                    }
                    else
                    {
                        //Do nothing
                    }
                    scGlenDB.softrecs.Add(newAsset);
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
            }
            else
            {
                MessageBox.Show("You need to be an admin to perform this action!");
            }
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

        private Image ConvertByteToImage(byte[] photo)
        {
            Image newImage;

            newImage = (Bitmap)((new ImageConverter()).ConvertFrom(photo));

            return newImage;
        }

        private void viewAssetBTN_Click(object sender, EventArgs e)
        {
            editPanel.Hide();
            viewSApanel.Visible = false;
            listView1HA.Items.Clear();
            viewHApanel.Visible = true;
            addAssetPanel.Visible = false;

            switchMode = false;
            IQueryable<scottishGlen> allProduct = from p in scGlenDB.scottishGlens
                                                  select p;
            foreach (var pp in allProduct)
            {
                //scGlenObj.Add(pp);
                string id = pp.ID.ToString();
                //listView1HA.Items.Add(id);

                if(pp.phySticker != null)
                {
                    string[] row1 =
                {
                    pp.systemName.ToString(),
                    pp.model.ToString(),
                    pp.manufacturer.ToString(),
                    pp.type.ToString(),
                    pp.ipAdress.ToString(),
                    pp.phySticker.ToString(),
                    pp.notes.ToString()
                };
                    listView1HA.Items.Add(id).SubItems.AddRange(row1);
                }
                else
                {
                    string[] row1 =
                {
                    pp.systemName.ToString(),
                    pp.model.ToString(),
                    pp.manufacturer.ToString(),
                    pp.type.ToString(),
                    pp.ipAdress.ToString(),
                    "empty row",
                    pp.notes.ToString()
                };
                    listView1HA.Items.Add(id).SubItems.AddRange(row1);
                }

                

            }

        }

        private void listView1HA_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }


        private int getClickIndex()
        {
            int index = 0;

            if (listView1HA.SelectedIndices.Count > 0)
            {
                index = (int.Parse(listView1HA.SelectedItems[0].Text));

            }

            return index;
        }
        private int getClickIndexSA()
        {
            int index = 0;

            if (listView1listView1SA.SelectedIndices.Count > 0)
            {
                index = (int.Parse(listView1listView1SA.SelectedItems[0].Text));

            }

            return index;
        }

        private void deleteHAbutton_Click(object sender, EventArgs e)
        {
            if (adminLogged)
            {
                int index = getClickIndex();

                scottishGlen find = (from p in scGlenDB.scottishGlens
                                     where p.ID == index
                                     select p).FirstOrDefault<scottishGlen>();


                scGlenDB.scottishGlens.Remove(find);
                scGlenDB.SaveChanges();


                listView1HA.Items.Clear();
                viewHApanel.Visible = true;
                addAssetPanel.Visible = false;

                IQueryable<scottishGlen> allProduct = from p in scGlenDB.scottishGlens
                                                      select p;
                foreach (var pp in allProduct)
                {
                    //scGlenObj.Add(pp);
                    string id = pp.ID.ToString();
                    //listView1HA.Items.Add(id);
                    string[] row1 =
                    {
                    pp.systemName.ToString(),
                    pp.model.ToString(),
                    pp.manufacturer.ToString(),
                    pp.type.ToString(),
                    pp.ipAdress.ToString(),
                    pp.phySticker.ToString(),
                    pp.notes.ToString()
                };

                    listView1HA.Items.Add(id).SubItems.AddRange(row1);
                }
            }
            else
            {
                MessageBox.Show("You need to be an admin to perform this action!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void editHAbutton_Click(object sender, EventArgs e)
        {
            editPanel.Show();
            editPanel.Location = new System.Drawing.Point(250, 80);
            viewHApanel.Hide();


            editIpIB.Show();
            ediNotesIB.Show();
            editAddImageButton.Show();
            editPictureBox.Show();
            //Setting up data that's already in
            int index = getClickIndex();
            scottishGlen find = (from p in scGlenDB.scottishGlens
                                 where p.ID == index
                                 select p).FirstOrDefault<scottishGlen>();

            if (index > 0)
            {
                editSystemNameIB.Text = find.systemName;
                editModelIB.Text = find.model;
                editManuufacturerIB.Text = find.manufacturer;
                editTypeIB.Text = find.type;
                editIpIB.Text = find.ipAdress;
                ediNotesIB.Text = find.notes;

                if(find.phySticker != null)
                {

                    Image pic = ConvertByteToImage(find.phySticker);
                    editPictureBox.Image = pic;
                }
            }
        }

        private void editSubmitButton_Click(object sender, EventArgs e)
        {
            if (adminLogged)
            {
                if (!switchMode) 
                {
                    //Setting up data that's already in
                    int index = getClickIndex();
                    scottishGlen find = (from p in scGlenDB.scottishGlens
                                         where p.ID == index
                                         select p).FirstOrDefault<scottishGlen>();

                    find.systemName = editSystemNameIB.Text;
                    find.model = editModelIB.Text;
                    find.manufacturer = editManuufacturerIB.Text;
                    find.type = editTypeIB.Text;
                    find.ipAdress = editIpIB.Text;
                    find.notes = ediNotesIB.Text;
                    if (imagePic.ImageLocation != null)
                    {
                        find.phySticker = ConvertFileToByte(editPictureBox.ImageLocation);
                    }
                    


                    scGlenDB.SaveChanges();


                    MessageBox.Show("Asset Updated!");

                    //Update view
                    editPanel.Hide();
                    viewHApanel.Hide();

                    IQueryable<scottishGlen> allProduct = from p in scGlenDB.scottishGlens
                                                          select p;
                    foreach (var pp in allProduct)
                    {
                        //scGlenObj.Add(pp);
                        string id = pp.ID.ToString();
                        //listView1HA.Items.Add(id);

                        if (pp.phySticker != null)
                        {
                            string[] row1 =
                            {
                                pp.systemName.ToString(),
                                pp.model.ToString(),
                                pp.manufacturer.ToString(),
                                pp.type.ToString(),
                                pp.ipAdress.ToString(),
                                pp.phySticker.ToString(),
                                pp.notes.ToString()
                            };

                            listView1HA.Items.Add(id).SubItems.AddRange(row1);
                        }
                        else
                        {
                            string[] row1 =
                            {
                                pp.systemName.ToString(),
                                pp.model.ToString(),
                                pp.manufacturer.ToString(),
                                pp.type.ToString(),
                                pp.ipAdress.ToString(),
                                "Empty Row",
                                pp.notes.ToString()
                            };

                            listView1HA.Items.Add(id).SubItems.AddRange(row1);
                        }

                       
                    }
                }
                else
                {
                    //Setting up data that's already in
                    int index = getClickIndexSA();
                    softrec find = (from p in scGlenDB.softrecs
                                    where p.ID == index
                                         select p).FirstOrDefault<softrec>();

                    find.sysName = editSystemNameIB.Text;
                    find.sysVersion = editModelIB.Text;
                    find.sysManufacturer = editManuufacturerIB.Text;

                    int hardwareID;

                    if (int.TryParse(editTypeIB.Text, out hardwareID) == true)
                    {
                        find.hardwareID = int.Parse(editTypeIB.Text);
                    }
                    else
                    {
                        //Do nothing
                    }
                    scGlenDB.SaveChanges();


                    MessageBox.Show("Asset Updated!");

                    //Update view

                    IQueryable<softrec> allProduct = from p in scGlenDB.softrecs
                                                     select p;
                    foreach (var pp in allProduct)
                    {
                        string id = pp.ID.ToString();

                        string[] row1 =
                        {
                            pp.sysName.ToString(),
                            pp.sysVersion.ToString(),
                            pp.sysManufacturer.ToString(),
                            pp.hardwareID.ToString()
                        };

                        listView1listView1SA.Items.Add(id).SubItems.AddRange(row1);
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to be an admin to perform this action!");
            }
            editPanel.Hide();
            viewHApanel.Show();
        }

        private void editAddImageButton_Click(object sender, EventArgs e)
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
                    editPictureBox.Image = PictureBox1.Image;
                    editPictureBox.ImageLocation = PictureBox1.ImageLocation;
                }
            }
        }

        private void AddAssetBTNsoft_Click(object sender, EventArgs e)
        {
            editPanel.Hide();
            viewSApanel.Visible = false;
            switchMode = true;
            addAssetPanel.Visible = true;
            viewHApanel.Visible = false;

            //Get System name
            systemNamegen.Text = Environment.OSVersion.ToString();
            systemNameTextBox.Text = Environment.OSVersion.ToString();

            //Get OS version
            modelGen.Text = Environment.OSVersion.Version.ToString();
            modelTextBox.Text = Environment.OSVersion.Version.ToString();

            //Get manufacturer
            manuGen.Text = GetBoardMaker();
            manuTextBox.Text = GetBoardMaker();

            //Enter ID connection
            typeTextBox.Text = "Enter Hardware ID for this system";
            

            typeGen.Hide();
            

            //Get IP
            ipGen.Hide();
            ipAdressTextBox.Hide();


            notesTextBox.Hide();
            addImaageButton.Hide();
            imagePic.Hide();
           

        }

        private void viewAssetBTNsoft_Click(object sender, EventArgs e)
        {
            editPanel.Hide();
            listView1listView1SA.Items.Clear();
            viewSApanel.Visible = true;
            viewHApanel.Visible = false;
            addAssetPanel.Visible = false;

            switchMode = true;
            IQueryable<softrec> allProduct = from p in scGlenDB.softrecs
                                                  select p;
            foreach (var pp in allProduct)
            {
                string id = pp.ID.ToString();

                string[] row1 =
                {
                    pp.sysName.ToString(),
                    pp.sysVersion.ToString(),
                    pp.sysManufacturer.ToString(),
                    pp.hardwareID.ToString()
                };

                listView1listView1SA.Items.Add(id).SubItems.AddRange(row1);
            }
        }

        private void editSAbutton_Click(object sender, EventArgs e)
        {
            editPanel.Show();
            editPanel.Location = new Point(250, 80);
            viewSApanel.Hide();

            //Setting up data that's already in
            int index = getClickIndexSA();
            softrec find = (from p in scGlenDB.softrecs
                            where p.ID == index
                                 select p).FirstOrDefault<softrec>();

            if (index > 0)
            {
                editSystemNameIB.Text = find.sysName;
                editModelIB.Text = find.sysVersion;
                editManuufacturerIB.Text = find.sysManufacturer;
                editTypeIB.Text = "" + find.hardwareID;


                editIpIB.Hide();
                ediNotesIB.Hide();
                editAddImageButton.Hide();
                editPictureBox.Hide();
            }

            //MessageBox.Show("Asset Updated!");

        }

        private void deleteSAbutton_Click(object sender, EventArgs e)
        {
            if (adminLogged)
            {
                int index = getClickIndexSA();

                softrec find = (from p in scGlenDB.softrecs
                                where p.ID == index
                                select p).FirstOrDefault<softrec>();


                scGlenDB.softrecs.Remove(find);
                scGlenDB.SaveChanges();


                listView1listView1SA.Items.Clear();
                viewSApanel.Visible = true;
                addAssetPanel.Visible = false;

                IQueryable<softrec> allProduct = from p in scGlenDB.softrecs
                                                 select p;
                foreach (var pp in allProduct)
                {
                    string id = pp.ID.ToString();

                    string[] row1 =
                    {
                    pp.sysName.ToString(),
                    pp.sysVersion.ToString(),
                    pp.sysManufacturer.ToString(),
                    pp.hardwareID.ToString()
                };

                    listView1listView1SA.Items.Add(id).SubItems.AddRange(row1);
                }
            }
            else
            {
                MessageBox.Show("You need to be an admin to perform this action!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            account accountlogin = (from c in scGlenDB.accounts
                                                where c.dbUsername == textBoxLogName.Text
                                                select c).FirstOrDefault<account>();

            //string hashedpass = EncryptPassword(passwordLog.Text);

            if (accountlogin != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(textBoxPswdLog.Text, accountlogin.dbPassword.ToString());

                if (verified)
                {
                    MessageBox.Show("You Have Successfully Logged In!");
                    initialPanel.Hide();
                    if(textBoxLogName.Text == "ADMIN")
                    {
                        adminLogged = true;
                    }
                    else
                    {
                        adminLogged = false;
                    }

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");
                }
            }
            else
            {
                MessageBox.Show("Account does not exist!");
            }
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            initialPanel.Show();
            adminLogged = false;
        }

        private void crAccount_Click(object sender, EventArgs e)
        {
            
            account newAsset = new account();

            newAsset.dbUsername = usernameTB.Text;
            newAsset.dbPassword = BCrypt.Net.BCrypt.HashPassword(pswdTBrepeat.Text);

            if (pswdTB.Text == pswdTBrepeat.Text )
            {
                if (pswdTB.Text.Length < 8)
                {
                    MessageBox.Show("Password needs to be 8 characters or more");
                }
                else
                {
                    scGlenDB.accounts.Add(newAsset);
                    scGlenDB.SaveChanges();


                    MessageBox.Show("Account Created!");
                    initialPanel.Hide();
                }

            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }
    }
}
