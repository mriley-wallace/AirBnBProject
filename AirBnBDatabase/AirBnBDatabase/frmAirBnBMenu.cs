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

namespace AirBnBDatabase
{
    public partial class frmAirBnBMenu : Form
    {
        public frmAirBnBMenu()
        {
            InitializeComponent();
            btnDistConfirm.Visible = false;
            btnDistCancel.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodCancel.Visible = false;

            btnDistAdd.Visible = false;
            btnDistEdit.Visible = false;
            btnDistDelete.Visible = false;
            txtDistrict.Visible = false;

            btnHoodAdd.Visible = false;
            btnHoodEdit.Visible = false;
            btnHoodDelete.Visible = false;
            txtNBHood.Visible = false;
        }


        private void BtnExitApp_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }



        private void FrmAirBnBMenu_Load_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }



        private void BtnRead_Click(object sender, EventArgs e)
        {
            DialogResult fileResult = getFile.ShowDialog();
            string fileName = getFile.FileName;

            using (StreamReader AirBnBReader = new StreamReader(fileName))
            {
                while (!AirBnBReader.EndOfStream)
                {
                    string tempDistName = AirBnBReader.ReadLine();
                    string tempDistHoods = AirBnBReader.ReadLine();


                    int numDistHoods = Convert.ToInt32(tempDistHoods);
                    Neighbourhood[] tempHoodArray = new Neighbourhood[numDistHoods];


                    for (int i = 0; i < numDistHoods; i++)
                    {
                        string tempHoodName = AirBnBReader.ReadLine();
                        string tempHoodProp = AirBnBReader.ReadLine();



                        int numHoodProp = Convert.ToInt32(tempHoodProp);
                        Property[] tempPropArray = new Property[numHoodProp];
                        //Neighbourhood tempHoodArray2 = new Neighbourhood(tempHoodName, Convert.ToInt32(tempHoodProp), tempPropArray);

                        for (int j = 0; j < numHoodProp; j++)
                        {
                            string tempPropID = AirBnBReader.ReadLine();
                            string tempPropName = AirBnBReader.ReadLine();
                            string tempHostID = AirBnBReader.ReadLine();
                            string tempHostName = AirBnBReader.ReadLine();
                            string tempNumList = AirBnBReader.ReadLine();
                            string tempLat = AirBnBReader.ReadLine();
                            string tempLong = AirBnBReader.ReadLine();
                            string tempRoomType = AirBnBReader.ReadLine();
                            string tempPrice = AirBnBReader.ReadLine();
                            string tempMinNight = AirBnBReader.ReadLine();
                            string tempPropAvailable = AirBnBReader.ReadLine();

                            Property tempPropArray2 = new Property(tempPropID, tempPropName, Convert.ToInt32(tempHostID), tempHostName, Convert.ToInt32(tempNumList), Convert.ToDouble(tempLat), Convert.ToDouble(tempLong), tempRoomType, Convert.ToDouble(tempPrice), Convert.ToInt32(tempMinNight), Convert.ToInt32(tempPropAvailable));
                            tempPropArray[j] = tempPropArray2;




                        }
                        Neighbourhood tempHood = new Neighbourhood(tempHoodName, numHoodProp, tempPropArray);
                        tempHoodArray[i] = tempHood;



                    }
                    District tempDist = new District(tempDistName, numDistHoods, tempHoodArray);
                    int distArraySize = Data.AllDist.Length;
                    Array.Resize(ref Data.AllDist, distArraySize + 1);
                    Data.AllDist[distArraySize] = tempDist;

                }

                AirBnBReader.Close();
            }


            lstDist.Items.Clear();
            for (int i = 0; i < Data.AllDist.Length; i++)
            {
                lstDist.Items.Add(Data.AllDist[i].getInDistName());
            }

        }

        private void lstDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstDist.SelectedIndex >= 0)
            {
                btnDistAdd.Visible = true;
                btnDistEdit.Visible = true;
                btnDistDelete.Visible = true;
                txtDistrict.Visible = true;
            }

            lstHood.Items.Clear();

            for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood().Length; i++)
            {
                lstHood.Items.Add(Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[i].getNHoodName());
            }
        }

        private void lstHood_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgdProp.Rows.Clear();
            dgdProp.Columns.Clear();
            dgdProp.Columns.Add("colPropID", "Property ID");
            dgdProp.Columns.Add("colPropName", "Property Name");
            dgdProp.Columns[columnName:"colPropName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgdProp.Columns.Add("colHostID", "ID of Host");
            dgdProp.Columns.Add("colHostName", "Name of Host");
            dgdProp.Columns.Add("colNumList", "Number of Properties");
            dgdProp.Columns.Add("colLat", "Latitude");
            dgdProp.Columns.Add("colLong", "Longitude");
            dgdProp.Columns.Add("colRoomType", "Room Type");
            dgdProp.Columns.Add("colPrice", "Price per Night");
            dgdProp.Columns.Add("colMinNight", "Minimum Nights");
            dgdProp.Columns.Add("colAvailable", "Days Available (Out of 365)");

            if (lstHood.SelectedIndex >= 0)
            {
                btnHoodAdd.Visible = true;
                btnHoodEdit.Visible = true;
                btnHoodDelete.Visible = true;
                txtNBHood.Visible = true;
            }

            for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp().Length; i++)
            {
                dgdProp.Rows.Add(Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPropID(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPropName(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getHostID(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getHostName(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getNumListProp(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getLattitude(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getLongitude(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getRoomType(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPrice(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getMinNight(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPropAvailable());
            }



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private string editItem;
        private int replaceIndex;


        private void btnDistEdit_Click(object sender, EventArgs e)
        {
            
            if (lstDist.SelectedIndex >=0 && lstDist.SelectedIndex < lstDist.Items.Count)
            {
                btnDistAdd.Visible = false;
                btnDistConfirm.Visible = true;
                btnDistDelete.Visible = false;
                btnDistEdit.Visible = false;
                btnDistCancel.Visible = true;
                editItem = lstDist.Items[lstDist.SelectedIndex].ToString();
                replaceIndex = lstDist.SelectedIndex;
                txtDistrict.Text = editItem;

                btnHoodAdd.Visible = false;
                btnHoodConfirm.Visible = false;
                btnHoodDelete.Visible = false;
                btnHoodEdit.Visible = false;
                btnHoodCancel.Visible = false;
                txtNBHood.Visible = false;


            } else
            {
                MessageBox.Show("Please select an Item from the District List!", "No Selection", MessageBoxButtons.OK);
            }
        }

        private void txtDistrict_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnDistConfirm_Click_1(object sender, EventArgs e)
        {
            editItem = txtDistrict.Text;
            District dist = Data.AllDist[replaceIndex];
            dist.setDistName(editItem);
            lstDist.Items.Clear();
            txtDistrict.Clear();

            foreach (District newVersion in Data.AllDist)
            {
                lstDist.Items.Add(newVersion.getInDistName());
            }
            btnDistAdd.Visible = true;
            btnDistConfirm.Visible = false;
            btnDistDelete.Visible = true;
            btnDistEdit.Visible = true;
            btnDistCancel.Visible = false;
        }

        private void btnDistCancel_Click_1(object sender, EventArgs e)
        {
            txtDistrict.Clear();
            btnDistAdd.Visible = false;
            btnDistConfirm.Visible = false;
            btnDistDelete.Visible = false;
            btnDistEdit.Visible = false;
            btnDistCancel.Visible = false;
            txtDistrict.Visible = false;
            
        }

        private void btnDistAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDistDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnHoodAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnHoodEdit_Click(object sender, EventArgs e)
        {
           
            if (lstHood.SelectedIndex >= 0 && lstHood.SelectedIndex < lstHood.Items.Count)
            {
                btnHoodAdd.Visible = false;
                btnHoodConfirm.Visible = true;
                btnHoodDelete.Visible = false;
                btnHoodEdit.Visible = false;
                btnHoodCancel.Visible = true;
                editItem = lstHood.Items[lstHood.SelectedIndex].ToString();
                replaceIndex = lstHood.SelectedIndex;
                txtNBHood.Text = editItem;
                btnDistAdd.Visible = false;
                btnDistConfirm.Visible = false;
                btnDistDelete.Visible = false;
                btnDistEdit.Visible = false;
                btnDistCancel.Visible = false;
                txtDistrict.Visible = false;


            }
            else
            {
                MessageBox.Show("Please select an Item from the Neighbourhood List!", "No Selection", MessageBoxButtons.OK);
            }
        }

        private void btnHoodDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnHoodConfirm_Click(object sender, EventArgs e)
        {
            editItem = txtNBHood.Text;
            Neighbourhood newhood = Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[replaceIndex];
            newhood.setNHoodName(editItem);
            lstHood.Items.Clear();
            txtNBHood.Clear();

            foreach (Neighbourhood newHoods in Data.AllDist[lstDist.SelectedIndex].getDistAllHood())
            {
                lstHood.Items.Add(newHoods.getNHoodName());
            }
            btnHoodAdd.Visible = true;
            btnHoodConfirm.Visible = false;
            btnHoodDelete.Visible = true;
            btnHoodEdit.Visible = true;
            btnHoodCancel.Visible = false;
        }

        private void btnHoodCancel_Click(object sender, EventArgs e)
        {
            txtNBHood.Clear();
            btnHoodAdd.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodDelete.Visible = false;
            btnHoodEdit.Visible = false;
            btnHoodCancel.Visible = false;
            txtNBHood.Visible = false;
        }
    }
}


                
