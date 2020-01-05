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

            using (StreamReader AirBnBReader = new StreamReader(@"miniAirBnB.txt"))
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
                        Neighbourhood tempHoodArray2 = new Neighbourhood(tempHoodName, Convert.ToInt32(tempHoodProp), tempPropArray);

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
                            int propArraySize = Data.AllProp.Length;
                            Array.Resize(ref Data.AllProp, propArraySize + 1);
                            Data.AllProp[propArraySize] = tempPropArray2;
                        

                            
                        }
                        Neighbourhood tempHood = new Neighbourhood(tempHoodName, numHoodProp, Data.AllProp);
                        int hoodArraySize = Data.AllHood.Length;
                        Array.Resize(ref Data.AllHood, hoodArraySize + 1);
                        Data.AllHood[hoodArraySize] = tempHood;

                    }
                    District tempDist = new District(tempDistName, numDistHoods, Data.AllHood);
                    int distArraySize = Data.AllDist.Length;
                    Array.Resize(ref Data.AllDist, distArraySize + 1);
                    Data.AllDist[distArraySize] = tempDist;

                }
                 
                AirBnBReader.Close();
            }
        }



        private void BtnRead_Click(object sender, EventArgs e)
        {
            lstDist.Items.Clear();
            foreach (District a in Data.AllDist)
            {
                lstDist.Items.Add(a.getInDistName() + " " + "has a total of " + a.getNumHood() + " " + "neighbourhoods.");
            }

            if (lstDist.SelectedIndex != -1)
            {
                //lstHood.Items.Clear();
                int seldist = lstDist.SelectedIndex;

                District tempdist = Data.AllDist[seldist];
                int numHood = tempdist.getNumHood();

                Data.AllHood = tempdist.getDistAllHood();
                foreach (Neighbourhood b in Data.AllHood)
                {
                    lstHood.Items.Add(b.getNHoodName() + " " + "has a total of " + b.getNumProp() + " " + "properties.");
                }
                if (numHood != 0)
                {

                   
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

                    for (int i = 0; i < Data.AllHood.Length; i++)
                    {
                        for (int j = 0; j < Data.AllHood[i].getHoodAllProp().Length; j++)
                        {
                            dgdProp.Rows.Add(Data.AllHood[i].getHoodAllProp()[j].getPropID(), Data.AllHood[i].getHoodAllProp()[j].getPropName(), Data.AllHood[i].getHoodAllProp()[j].getHostID(),
                                Data.AllHood[i].getHoodAllProp()[j].getHostName(), Data.AllHood[i].getHoodAllProp()[j].getNumListProp(), Data.AllHood[i].getHoodAllProp()[j].getLattitude(),
                                Data.AllHood[i].getHoodAllProp()[j].getLongitude(), Data.AllHood[i].getHoodAllProp()[j].getRoomType(), Data.AllHood[i].getHoodAllProp()[j].getPrice(), Data.AllHood[i].getHoodAllProp()[j].getMinNight(),
                                Data.AllHood[i].getHoodAllProp()[j].getPropAvailable());
                        }

                    }
                }
            }


           
            //foreach (Property c in Data.AllProp)
            //    lstProperty.Items.Add(c.getPropID() + "" + c.getPropName() + "" + c.getHostID() + "" + c.getHostName() + "" + c.getNumListProp() + "" + c.getLattitude() + "" + c.getLongitude() +
            //        "" + c.getRoomType() + "" + "£" + c.getPrice() + "" + c.getMinNight() + "" + c.getPropAvailable());

        }
    }

}
