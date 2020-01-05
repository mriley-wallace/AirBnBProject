using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirBnBDatabase
{
    class Property
    {

        // Add data types in consistency to avoid multiple conversions //
       private string propID, propName, hostName, roomType;
       private double lattitude, longitude, price;
       private int hostID, numListProp, minNight, propAvailable;

        public Property(string inPropID, string inPropName, int inHostID, string inHostName, int inNumList, 
            double inLat, double inLong, string inRoomType, double inPrice, int inMinNight, int inPropAvailable)
        {
            propID = inPropID;
            propName = inPropName;
            setHostID(inHostID); // Uses the setter for one-time conversion to correct format and a format catcher if it can't //
            hostName = inHostName;
            setNumListProp(inNumList);
            setLattitude(inLat);
            setLongitude(inLong);
            roomType = inRoomType;
            setPrice(inPrice);
            setMinNight(inMinNight);
            setPropAvailable(inPropAvailable);

        }

        // Getters //
        public string getPropID()
        {
            return propID;
        }
        public string getPropName()
        {
            return propName;
        }
        public int getHostID()
        {
            return hostID;
        }
        public string getHostName()
        {
            return hostName;
        }
        public int getNumListProp()
        {
            return numListProp;
        }
        public double getLattitude()
        {
            return lattitude;
        }
        public double getLongitude()
        {
            return longitude;
        }
        public string getRoomType()
        {
            return roomType;
        }
        public double getPrice()
        {
            return price;
        }
        public int getMinNight()
        {
            return minNight;
        }

        public int getPropAvailable()
        {
            return propAvailable;
        }

        // Setters //
        public void setPropID (string thePropID)
        {
            propID = thePropID;
        }
        public void setPropName (string thePropName)
        {
            propName = thePropName;
        }
        public void setHostID(int theHostID)
        {
            try
            {
                hostID = Convert.ToInt32(theHostID);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid numerical Host ID");
            }
        }
        public void setHostName (string theHostName)
            {
            hostName = theHostName;
            }
        public void setNumListProp (int theNumListProp)
        {
            try
            {
                numListProp = Convert.ToInt32(theNumListProp);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid numerical value");
            }
        }
        public void setLattitude (double theLattitude)
        {
            try
            {
                lattitude = Convert.ToDouble(theLattitude);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid numerical value for the Lattitude");
            }
        }
        public void setLongitude (double theLongitude)
        {
            try
            {
                longitude = Convert.ToDouble(theLongitude);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid numerical value for the longitude");
            }
        }
        public void setRoomType(string theRoomType)
        {
            roomType = theRoomType;
        }
        public void setPrice (double thePrice)
        {
            try
            {
                price = Convert.ToDouble(thePrice);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid price (without any special characters except a decimal point)");
            }
        }
        public void setMinNight(int theMinNight)
        {
            try
            {
                minNight = Convert.ToInt32(theMinNight);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid number of nights to stay.");
            }
        }

        public void setPropAvailable (int thePropAvailable)
        {
            try
            {
                propAvailable = Convert.ToInt32(thePropAvailable);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please input a valid number of available days (up to 365).");
            }
        }


    }
}








// Extra brownie points if you get this far down and read this :-) //