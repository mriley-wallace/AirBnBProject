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
            LayoutStart();
        }
        public int districtIndex;
        public int neighbourhoodIndex;
        public string emptyText = "";
        public int propertyIndex;
        public string SavePath;


        private void BtnExitApp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    SavePath = fileDialog.FileName;
                    this.BringToFront();
                }
                else
                {
                    System.Environment.Exit(1);
                }
            }
            using (StreamWriter SaveNew = new StreamWriter(SavePath))
            {
                for (int i = 0; i < Data.AllDist.Length; i++)
                {
                    SaveNew.WriteLine(Data.AllDist[i].getInDistName());
                    SaveNew.WriteLine(Data.AllDist[i].getNumHood());
                    if (Data.AllDist[i].getDistAllHood().Length != 0)
                    {
                        for (int j = 0; j < Data.AllDist[i].getDistAllHood().Length; j++)
                        {
                            SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getNHoodName());
                            SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getNumProp());
                            if (Data.AllDist[i].getDistAllHood()[j].getHoodAllProp().Length != 0)
                            {
                                for (int k = 0; k < Data.AllDist[i].getDistAllHood()[j].getHoodAllProp().Length; k++)
                                {
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getPropID());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getPropName());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getHostID());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getHostName());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getNumListProp());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getLattitude());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getLongitude());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getRoomType());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getPrice());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getMinNight());
                                    SaveNew.WriteLine(Data.AllDist[i].getDistAllHood()[j].getHoodAllProp()[k].getPropAvailable());


                                }
                            }
                        }
                    }
                }
            }

            
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

            if (lstDist.SelectedIndex >= 0 && lstDist.SelectedIndex < lstDist.Items.Count)
            {
                btnDistAdd.Visible = true;
                btnDistEdit.Visible = true;
                btnHoodAdd.Visible = true;
                btnHoodEdit.Visible = true;
                districtIndex = lstDist.SelectedIndex;

            }

            lstHood.Items.Clear();
            try
            {

                for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood().Length; i++)
                {

                    lstHood.Items.Add(Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[i].getNHoodName());
                }
            }
            catch (Exception)
            {
                lstDist.SelectedIndex = 0;
            }

        }



        private void lstHood_SelectedIndexChanged(object sender, EventArgs e)
        {

            neighbourhoodIndex = lstHood.SelectedIndex;

            DataGridDataEntry();

            if (lstHood.SelectedIndex >= 0)
            {
                btnHoodAdd.Visible = true;
                btnHoodEdit.Visible = true;
            }

            //using the District array from the selected index for the District listbox, get all the neighbourhoods, and use the selected index from the neighbourhood listbox to get the length of all the properties//

            try
            {
                for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[lstHood.SelectedIndex].getHoodAllProp().Length; i++)
                {

                    //Add rows for all the property information//
                    DataGridField(i);
                }
            }
            catch (Exception)
            {
                lstHood.SelectedIndex = 0;
                txtNBHood.Visible = false;
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
            if (lstDist.SelectedIndex >= 0 && lstDist.SelectedIndex < lstDist.Items.Count)
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
            District dist = Data.AllDist[districtIndex];
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
            ClearAllTextBoxes(emptyText);
        }

        private void btnDistCancel_Click_1(object sender, EventArgs e)
        {
            ClearAllTextBoxes(emptyText);
            LayoutStart();

        }

        private void btnDistAdd_Click(object sender, EventArgs e)
        {
            btnDistAdd.Visible = false;
            btnDistConfirm.Visible = false;
            btnDistEdit.Visible = false;
            btnDistCancel.Visible = false;
            replaceIndex = districtIndex;
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
            btnDistAdd.Visible = false;
            btnDistConfirm.Visible = false;
            btnDistEdit.Visible = false;
            btnDistCancel.Visible = false;
            replaceIndex = neighbourhoodIndex;
            txtDistrict.Visible = false;
            btnHoodAdd.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodEdit.Visible = false;
            btnHoodCancel.Visible = false;
            txtNBHood.Visible = false;

            btnAddDisConfirm.Visible = false;
            btnAddDisCancel.Visible = false;
            btnAddHoodConfirm.Visible = true;
            btnAddHoodCancel.Visible = true;
            lblAddName.Visible = true;
            lblAddNumber.Visible = true;
            txtAddName.Visible = true;
            txtAddNum.Visible = true;

            lblAddName.Text = "New Neighbourhood Name";
            lblAddNumber.Text = "Number of Properties in this District";
        }

        private void btnHoodEdit_Click(object sender, EventArgs e)
        {
          
            if (lstHood.SelectedIndex >= 0 && lstHood.SelectedIndex < lstHood.Items.Count)
            {
                txtNBHood.Visible = true;
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
            //instead of using a for loop, here it is a foreach loop. at the beginning, they were all foreach and as errors progressed, the others were changed to for loops, and 
            // this one still worked, so it was never changed.

            editItem = txtNBHood.Text;
            Neighbourhood newhood = Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex];
            newhood.setNHoodName(editItem);
            lstHood.Items.Clear();
            txtNBHood.Clear();

            foreach (Neighbourhood newHoods in Data.AllDist[districtIndex].getDistAllHood())
            {
                lstHood.Items.Add(newHoods.getNHoodName());
            }
            btnHoodConfirm.Visible = false;
            btnHoodCancel.Visible = false;
            ClearAllTextBoxes(emptyText);
        }

        private void btnHoodCancel_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(emptyText);
            LayoutStart();
        }

        private void BtnAddDisConfirm_Click(object sender, EventArgs e)
        {
            lblAddName.Visible = false;
            lblAddNumber.Visible = false;
            txtAddName.Visible = false;
            txtAddNum.Visible = false;
            btnAddDisConfirm.Visible = false;
            btnAddDisCancel.Visible = false;
            btnAddHoodConfirm.Visible = false;
            btnAddHoodCancel.Visible = false;

            //when adding a new district, resize it by 1 to make sure it fits, then pass through a new neighbourhood array into that. Then the for loops simply add the appropriate
            //district and neighbourhoods from this new edited list, back into their appropriate list boxes.


            if (txtAddName.Text != "" && txtAddNum.Text != "")
            {

                string tempDistName = txtAddName.Text.ToString();
                int numDistHoods = Convert.ToInt32(txtAddNum.Text);


                District tempDist = new District(tempDistName, numDistHoods);
                int distArraySize = Data.AllDist.Length;
                Array.Resize(ref Data.AllDist, distArraySize + 1);
                Data.AllDist[distArraySize] = tempDist;
                tempDist.setHoodAllProp(new Neighbourhood[0]);

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
            ClearAllTextBoxes(emptyText);
        }

        private void BtnAddDisCancel_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(emptyText);
            LayoutStart();


        }

        private void BtnAddHoodConfirm_Click(object sender, EventArgs e)
        {
            lblAddName.Visible = false;
            lblAddNumber.Visible = false;
            txtAddName.Visible = false;
            txtAddNum.Visible = false;
            btnAddDisConfirm.Visible = false;
            btnAddDisCancel.Visible = false;
            btnAddHoodConfirm.Visible = false;
            btnAddHoodCancel.Visible = false;

            replaceIndex = lstHood.SelectedIndex;

            //To add the new neighbourhood, create the appropriate arrays that follow the current index we are in, and make sure to resize the district to allow a new neighbourhood array
            //inside. After that, the for loop will go through the number of properties declared in that neighbourhood array, and add in all the data into the datagrid.
            //in the try, if there is no property data added yet,it will simply catch it and create a new empty line in the datagrid, ready for a new property to be added.

            if (txtAddName.Text != "" && txtAddNum.Text != "")
            {

                string tempHoodName = txtAddName.Text.ToString();
                int numHoodAllProps = Convert.ToInt32(txtAddNum.Text);


                Neighbourhood tempNeighbourhood = new Neighbourhood(tempHoodName);
                int hoodArraySize = Data.AllDist[districtIndex].getDistAllHood().Length;
                Neighbourhood[] tempNBHood = Data.AllDist[districtIndex].getDistAllHood();
                Array.Resize(ref tempNBHood, hoodArraySize + 1);
                tempNBHood[hoodArraySize] = tempNeighbourhood;

                Data.AllDist[districtIndex].setHoodAllProp(tempNBHood);
                tempNeighbourhood.setHoodAllProp(new Property[0]);

                lstHood.Refresh();
                lstHood.Items.Clear();
                for (int i = (tempNeighbourhood.getNumProp()) - 1; i < tempNeighbourhood.getNumProp(); i++)
                {
                    DataGridDataEntry();
                    try
                    {
                        DataGridField(i);
                    }
                    catch (Exception)
                    {
                        dgdProp.Rows.Add("", "", "", "", "", "", "", "", "", "", "");
                    }
                }
                lstHood.Refresh();
                dgdProp.Refresh();


            }
            else
            {
                MessageBox.Show("Please enter in the relevant information into the Textboxes", "One or more field missing!", MessageBoxButtons.OK);
                lblAddName.Visible = true;
                lblAddNumber.Visible = true;
                txtAddName.Visible = true;
                txtAddNum.Visible = true;
                btnAddDisConfirm.Visible = false;
                btnAddDisCancel.Visible = false;
                btnAddHoodConfirm.Visible = true;
                btnAddHoodCancel.Visible = true;

            }
            ClearAllTextBoxes(emptyText);
        }

        private void BtnAddHoodCancel_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(emptyText);
            LayoutStart();
        }

        public void DataGridField(int i)
        {
            //method to add in all the datagrid items that passes through the i integer for the for loops.

            dgdProp.Rows.Add(
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getPropID(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getPropName(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getHostID(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getHostName(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getNumListProp(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getLattitude(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getLongitude(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getRoomType(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getPrice(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getMinNight(),
                           Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].getHoodAllProp()[i].getPropAvailable()
                           );
        }
        public void DataGridDataEntry()
        {
            //Using a datagrid view for the properties field//

            dgdProp.Rows.Clear();
            dgdProp.Columns.Clear();
            dgdProp.Columns.Add("colPropID", "Property ID");
            dgdProp.Columns.Add("colPropName", "Property Name");
            dgdProp.Columns.Add("colHostID", "ID of Host");
            dgdProp.Columns.Add("colHostName", "Name of Host");
            dgdProp.Columns.Add("colNumList", "Number of Properties");
            dgdProp.Columns.Add("colLat", "Latitude");
            dgdProp.Columns.Add("colLong", "Longitude");
            dgdProp.Columns.Add("colRoomType", "Room Type");
            dgdProp.Columns.Add("colPrice", "Price per Night");
            dgdProp.Columns.Add("colMinNight", "Minimum Nights");
            dgdProp.Columns.Add("colAvailable", "Days Available (Out of 365)");
        }

        public void LayoutStart()
        {

            //Default layout settings 


            btnDistConfirm.Visible = false;
            btnDistCancel.Visible = false;
            btnHoodConfirm.Visible = false;
            btnHoodCancel.Visible = false;

            btnDistAdd.Visible = true;
            btnDistEdit.Visible = true;
            txtDistrict.Visible = false;

            btnHoodAdd.Visible = true;
            btnHoodEdit.Visible = true;
            txtNBHood.Visible = false;

            btnAddDisCancel.Visible = false;
            btnAddDisConfirm.Visible = false;

            btnAddHoodCancel.Visible = false;
            btnAddHoodConfirm.Visible = false;

            lblAddName.Visible = false;
            lblAddNumber.Visible = false;
            txtAddName.Visible = false;
            txtAddNum.Visible = false;

            lblPropID.Visible = false;
            lblPropName.Visible = false;
            lblHostID.Visible = false;
            lblHostName.Visible = false;
            lblNumListProp.Visible = false;
            lblLattitude.Visible = false;
            lblLongitude.Visible = false;
            lblRoomType.Visible = false;
            lblPrice.Visible = false;
            lblMinNight.Visible = false;
            lblPropAvailable.Visible = false;

            txtPropID.Visible = false;
            txtPropName.Visible = false;
            txtHostID.Visible = false;
            txtHostName.Visible = false;
            txtNumListProp.Visible = false;
            txtLattitude.Visible = false;
            txtLongitude.Visible = false;
            txtRoomType.Visible = false;
            txtPrice.Visible = false;
            txtMinNight.Visible = false;
            txtAvailable.Visible = false;

            btnAddPropConfirm.Visible = false;
            btnAddPropCancel.Visible = false;
            btnEditPropConfirm.Visible = false;
            btnEditProperty.Visible = true;


        }

        public void ClearAllTextBoxes(string empty)
        {

            //Just my method to make sure all fields are empty whenever a confirm or cancel button is clicked.

            txtAddName.Text = empty;
            txtAddNum.Text = empty;
            txtDistrict.Text = empty;
            txtNBHood.Text = empty;
            txtPropID.Text = empty;
            txtPropName.Text = empty;
            txtHostID.Text = empty;
            txtHostName.Text = empty;
            txtNumListProp.Text = empty;
            txtLattitude.Text = empty;
            txtLongitude.Text = empty;
            txtRoomType.Text = empty;
            txtPrice.Text = empty;
            txtMinNight.Text = empty;
            txtAvailable.Text = empty;

        }
        private void BtnAddProperty_Click(object sender, EventArgs e)
        {
            lblPropID.Visible = true;
            lblPropName.Visible = true;
            lblHostID.Visible = true;
            lblHostName.Visible = true;
            lblNumListProp.Visible = true;
            lblLattitude.Visible = true;
            lblLongitude.Visible = true;
            lblRoomType.Visible = true;
            lblPrice.Visible = true;
            lblMinNight.Visible = true;
            lblPropAvailable.Visible = true;

            txtPropID.Visible = true;
            txtPropName.Visible = true;
            txtHostID.Visible = true;
            txtHostName.Visible = true;
            txtNumListProp.Visible = true;
            txtLattitude.Visible = true;
            txtLongitude.Visible = true;
            txtRoomType.Visible = true;
            txtPrice.Visible = true;
            txtMinNight.Visible = true;
            txtAvailable.Visible = true;

            btnAddPropConfirm.Visible = true;
            btnAddPropCancel.Visible = true;
            btnEditProperty.Visible = false;
        }

        private void BtnEditProperty_Click(object sender, EventArgs e)
        {
            lblPropID.Visible = true;
            lblPropName.Visible = true;
            lblHostID.Visible = true;
            lblHostName.Visible = true;
            lblNumListProp.Visible = true;
            lblLattitude.Visible = true;
            lblLongitude.Visible = true;
            lblRoomType.Visible = true;
            lblPrice.Visible = true;
            lblMinNight.Visible = true;
            lblPropAvailable.Visible = true;

            txtPropID.Visible = true;
            txtPropName.Visible = true;
            txtHostID.Visible = true;
            txtHostName.Visible = true;
            txtNumListProp.Visible = true;
            txtLattitude.Visible = true;
            txtLongitude.Visible = true;
            txtRoomType.Visible = true;
            txtPrice.Visible = true;
            txtMinNight.Visible = true;
            txtAvailable.Visible = true;

            btnEditPropConfirm.Visible = true;
            btnAddPropCancel.Visible = true;
            btnEditProperty.Visible = false;

            District temp = Data.AllDist[districtIndex];
            Neighbourhood hoodtemp = temp.getDistAllHood()[neighbourhoodIndex];
            Property proptemp = hoodtemp.getHoodAllProp()[propertyIndex];

            //Using the correct path to our array we are currently focusing on (as seen above), try to put all the data into the textboxes. The catch doesn't really give any indication as to what went wrong though

            try
            {

                txtPropID.Text = proptemp.getPropID();
                txtPropName.Text = proptemp.getPropName();
                txtHostID.Text = proptemp.getHostID().ToString();
                txtHostName.Text = proptemp.getHostName();
                txtNumListProp.Text = proptemp.getNumListProp().ToString();
                txtLattitude.Text = proptemp.getLattitude().ToString();
                txtLongitude.Text = proptemp.getLongitude().ToString();
                txtRoomType.Text = proptemp.getRoomType();
                txtPrice.Text = proptemp.getPrice().ToString();
                txtMinNight.Text = proptemp.getMinNight().ToString();
                txtAvailable.Text = proptemp.getPropAvailable().ToString();
            } catch (Exception)
            {
                ClearAllTextBoxes(emptyText);
            }



        }

        private void BtnAddPropConfirm_Click(object sender, EventArgs e)

        //making sure that all the appropriate fields have data entered, so no cell is left null upon addition,
        //we make a temporary property array and pass in all of the text boxes and convert to appropriate types based on the constructor class
        //then using the static array, at the point we are at now (using the selected indexes) we use the addProp method and pass through the information and update the datagird//

        {
            if (txtPropID.Text != "" && txtPropName.Text != "" && txtHostID.Text != "" && txtHostName.Text != "" && txtNumListProp.Text != "" &&
                         txtLattitude.Text != "" && txtLongitude.Text != "" && txtRoomType.Text != "" && txtPrice.Text != "" && txtMinNight.Text != "" &&
                         txtAvailable.Text != "")
            {
                    Property proptemp = new Property(txtPropID.Text, txtPropName.Text, Convert.ToInt32(txtHostID.Text), txtHostName.Text, Convert.ToInt32(txtNumListProp.Text),
                Convert.ToDouble(txtLattitude.Text), Convert.ToDouble(txtLongitude.Text), txtRoomType.Text, 
                Convert.ToDouble(txtPrice.Text), Convert.ToInt32(txtMinNight.Text),
                Convert.ToInt32(txtAvailable.Text));

                    Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].addProp(proptemp);


                    LayoutStart();
                    ClearAllTextBoxes(emptyText);              
            }
            else
            {
                MessageBox.Show("Please make sure all of the fields are filled in!", "One or more field missing!", MessageBoxButtons.OK);
            }

        }

        private void BtnAddPropCancel_Click(object sender, EventArgs e)
        {

            LayoutStart();
            ClearAllTextBoxes(emptyText);
        }

        private void BtnEditPropConfirm_Click(object sender, EventArgs e)
        {

           
            //making sure that all the appropriate fields have data entered, so no cell is left null upon editing,
            //we make a temporary property array and pass in all of the text boxes and convert to appropriate types based on the constructor class
            //then using the static array, at the point we are at now (using the selected indexes) we use the setter and pass through the information and update the datagird//

            if (txtPropID.Text != "" && txtPropName.Text != "" && txtHostID.Text != "" && txtHostName.Text != "" &&  txtNumListProp.Text != "" &&
                txtLattitude.Text != "" && txtLongitude.Text != "" && txtRoomType.Text != "" && txtPrice.Text != "" &&  txtMinNight.Text != "" &&
                txtAvailable.Text != "")
            {              
                Property tempProp = new Property(txtPropID.Text, txtPropName.Text, Convert.ToInt32(txtHostID.Text), txtHostName.Text, Convert.ToInt32(txtNumListProp.Text),
                    Convert.ToDouble(txtLattitude.Text), Convert.ToDouble(txtLongitude.Text), txtRoomType.Text, Convert.ToDouble(txtPrice.Text), Convert.ToInt32(txtMinNight.Text), 
                    Convert.ToInt32(txtAvailable.Text));
                Data.AllDist[districtIndex].getDistAllHood()[neighbourhoodIndex].setHoodAllProp(tempProp, propertyIndex);

                LayoutStart();
                ClearAllTextBoxes(emptyText);
                dgdProp.Update();
                dgdProp.Refresh();

            }
            else
            {
                MessageBox.Show("Please make sure all of the fields are filled in!", "One or more field missing!", MessageBoxButtons.OK);
            }

        }

        private void DgdProp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            propertyIndex = e.RowIndex;




        }
    }
}



                
