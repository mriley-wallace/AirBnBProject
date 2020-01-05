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
                lstDist.Items.Add(Data.AllDist[i].getInDistName() + " " + "has a total of " + Data.AllDist[i].getNumHood() + " " + "neighbourhoods.");
            }

        }

        private void lstDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstHood.Items.Clear();

            for (int i = 0; i < Data.AllDist[lstDist.SelectedIndex].getDistAllHood().Length; i++)
            {
                lstHood.Items.Add(Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[i].getNHoodName() + "has a total of " +  Data.AllDist[lstDist.SelectedIndex].getDistAllHood()[i].getNumProp() + " " + "properties.");
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
    }
}


                //for (int i = 0; i < Data.AllHood.Length; i++)
                //{
                //    for (int j = 0; j < Data.AllHood[i].getHoodAllProp().Length; j++)
                //    {
                //        dgdProp.Rows.Add(Data.AllHood[i].getHoodAllProp()[j].getPropID(), Data.AllHood[i].getHoodAllProp()[j].getPropName(), Data.AllHood[i].getHoodAllProp()[j].getHostID(),
                //            Data.AllHood[i].getHoodAllProp()[j].getHostName(), Data.AllHood[i].getHoodAllProp()[j].getNumListProp(), Data.AllHood[i].getHoodAllProp()[j].getLattitude(),
                //            Data.AllHood[i].getHoodAllProp()[j].getLongitude(), Data.AllHood[i].getHoodAllProp()[j].getRoomType(), Data.AllHood[i].getHoodAllProp()[j].getPrice(), Data.AllHood[i].getHoodAllProp()[j].getMinNight(),
                //            Data.AllHood[i].getHoodAllProp()[j].getPropAvailable());
                //    }

//}
