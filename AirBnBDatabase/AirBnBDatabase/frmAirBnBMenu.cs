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

            //Layout the form for start use//
            btnDistConfirm.Visible = false;
            btnDistCancel.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodCancel.Visible = false;

            btnDistAdd.Visible = false;
            btnDistEdit.Visible = false;
            txtDistrict.Visible = false;

            btnHoodAdd.Visible = false;
            btnHoodEdit.Visible = false;
            txtNBHood.Visible = false;

            btnAddDisCancel.Visible = false;
            btnAddDisConfirm.Visible = false;

            btnAddHoodCancel.Visible = false;
            btnAddHoodConfirm.Visible = false;

            lblAddName.Visible = false;
            lblAddNumber.Visible = false;
            txtAddName.Visible = false;
            txtAddNum.Visible = false;
        }


        private void BtnExitApp_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }



        private void FrmAirBnBMenu_Load_1(object sender, EventArgs e)
        {
            //Force the application to run in maximised mode irrelevant to monitor size//
            WindowState = FormWindowState.Maximized;
        }



        private void BtnRead_Click(object sender, EventArgs e)
        {

            //Read in a .txt file from the browser, input that filename into string. use string variable for streamreader//
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

            //Show the District items in the listbox for District//
            lstDist.Items.Clear();
            for (int i = 0; i < Data.AllDist.Length; i++)
            {
                lstDist.Items.Add(Data.AllDist[i].getInDistName());
            }

        }

        private void lstDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Whenever the user selects a different entity inside the district listbox, use that selectedindex integer to find the correct District[] array and grab the neighbourhoods from that array and display them in the listbox for neighbourhoods//

            if(lstDist.SelectedIndex >= 0 && lstDist.SelectedIndex < lstDist.Items.Count)
            {
                btnDistAdd.Visible = true;
                btnDistEdit.Visible = true;
                
            }

            lstHood.Items.Clear();

            for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood().Length; i++)
            {
                lstHood.Items.Add(Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[i].getNHoodName());
            }
        }

        private void lstHood_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Using a datagrid view for the properties field//

            dgdProp.Rows.Clear();
            dgdProp.Columns.Clear();
            dgdProp.Columns.Add("colPropID", "Property ID");
            dgdProp.Columns.Add("colPropName", "Property Name");

            //Fill the rest of the datagrid window with the property name cell, this way there is no left over space in the DataGrid edges//
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
                txtNBHood.Visible = true;
            }

            //using the District array from the selected index for the District listbox, get all the neighbourhoods, and use the selected index from the neighbourhood listbox to get the length of all the properties//
            for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp().Length; i++)
            {

                //Add rows for all the property information//
                dgdProp.Rows.Add(
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPropID(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPropName(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getHostID(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getHostName(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getNumListProp(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getLattitude(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getLongitude(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getRoomType(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPrice(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getMinNight(),
                   Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp()[i].getPropAvailable()
                   );
            }



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private string editItem;
        private int replaceIndex;       
        private void btnDistEdit_Click(object sender, EventArgs e)
        {
            txtDistrict.Visible = true;
            if (lstDist.SelectedIndex >=0 && lstDist.SelectedIndex < lstDist.Items.Count)
            {
               
                btnDistAdd.Visible = false;
                btnDistConfirm.Visible = true;
                btnDistEdit.Visible = false;
                btnDistCancel.Visible = true;
                editItem = lstDist.Items[lstDist.SelectedIndex].ToString();
                replaceIndex = lstDist.SelectedIndex;
                txtDistrict.Text = editItem;

                btnHoodAdd.Visible = false;
                btnHoodConfirm.Visible = false;
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
            btnDistEdit.Visible = true;
            btnDistCancel.Visible = false;
        }

        private void btnDistCancel_Click_1(object sender, EventArgs e)
        {
            txtDistrict.Clear();
            btnDistAdd.Visible = true;
            btnDistConfirm.Visible = false;
            btnDistEdit.Visible = true;
            btnDistCancel.Visible = false;
            txtDistrict.Visible = false;
            
        }

        private void btnDistAdd_Click(object sender, EventArgs e)
        {
            btnDistAdd.Visible = false;
            btnDistConfirm.Visible = false;
            btnDistEdit.Visible = false;
            btnDistCancel.Visible = false;
            replaceIndex = lstDist.SelectedIndex;
            txtDistrict.Visible = false;
            btnHoodAdd.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodEdit.Visible = false;
            btnHoodCancel.Visible = false;
            txtNBHood.Visible = false;

            btnAddDisConfirm.Visible = true;
            btnAddDisCancel.Visible = true;
            lblAddName.Visible = true;
            lblAddNumber.Visible = true;
            txtAddName.Visible = true;
            txtAddNum.Visible = true;

            lblAddName.Text = "New District Name";
            lblAddNumber.Text = "Number of Neighbourhoods in this District";
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
                btnHoodEdit.Visible = false;
                btnHoodCancel.Visible = true;
                editItem = lstHood.Items[lstHood.SelectedIndex].ToString();
                replaceIndex = lstHood.SelectedIndex;
                txtNBHood.Text = editItem;
                btnDistAdd.Visible = false;
                btnDistConfirm.Visible = false;
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
            btnHoodEdit.Visible = true;
            btnHoodCancel.Visible = false;
        }

        private void btnHoodCancel_Click(object sender, EventArgs e)
        {
            txtNBHood.Clear();
            btnHoodAdd.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodEdit.Visible = false;
            btnHoodCancel.Visible = false;
            txtNBHood.Visible = false;
        }

        private void BtnAddDisConfirm_Click(object sender, EventArgs e)
        {
            lblAddName.Visible = false;
            lblAddNumber.Visible = false;
            txtAddName.Visible = false;
            txtAddNum.Visible = false;
            btnAddDisConfirm.Visible = false;
            btnAddDisCancel.Visible = false;


            if (txtAddName.Text != "" && txtAddNum.Text != "")
            {

                string tempDistName = txtAddName.Text.ToString();
                int numDistHoods = Convert.ToInt32(txtAddNum.Text);


                District tempDist = new District(tempDistName, numDistHoods);
                int distArraySize = Data.AllDist.Length;
                Array.Resize(ref Data.AllDist, distArraySize + 1);
                Data.AllDist[distArraySize] = tempDist;
                lstDist.Items.Clear();
                tempDist.setNumHood(numDistHoods);
                for (int i = (Data.AllDist.Length - 1); i < Data.AllDist.Length; i++)
                {
                    Data.AllDist[distArraySize] = tempDist;
                }
                lstDist.Items.Clear();

                for (int i = 0; i < Data.AllDist.Length; i++)
                {
                    lstDist.Items.Add(Data.AllDist[i].getInDistName());
                }


                for (int i = (tempDist.getNumHood()) - 1; i < tempDist.getNumHood(); i++)
                {
                    lstHood.Items.Add(tempDist.getNumHood());
                }

                lstDist.ClearSelected();
                lstDist.Refresh();
            }
            else
            {
                MessageBox.Show("Please enter in the relevant information into the Textboxes", "One or more field missing!", MessageBoxButtons.OK);
                lblAddName.Visible = true;
                lblAddNumber.Visible = true;
                txtAddName.Visible = true;
                txtAddNum.Visible = true;
                btnAddDisConfirm.Visible = true;
                btnAddDisCancel.Visible = true;

            }
        }

        private void BtnAddDisCancel_Click(object sender, EventArgs e)
        {
            txtDistrict.Clear();
            btnDistAdd.Visible = true;
            btnDistConfirm.Visible = false;
            btnDistEdit.Visible = true;
            btnDistCancel.Visible = false;
            txtDistrict.Visible = false;
            btnAddDisConfirm.Visible = false;
            btnAddDisCancel.Visible = false;
            lblAddName.Visible = false;
            lblAddNumber.Visible = false;
            txtAddName.Visible = false;
            txtAddNum.Visible = false;
        }

        private void BtnAddHoodConfirm_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddHoodCancel_Click(object sender, EventArgs e)
        {

        }
    }
}


                
