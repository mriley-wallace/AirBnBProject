using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirBnBDatabase
{
    class Neighbourhood
    {
        private string nHoodName;
        private int numProp;
        private Property[] hoodAllProp;


        public Neighbourhood (string inHoodName, int inNumProp, Property[] inAllProp)
        {
            nHoodName = inHoodName;
            numProp = inNumProp;
            hoodAllProp = inAllProp;
        }

        public Neighbourhood(string inHoodName, int inNumProp)
        {
            nHoodName = inHoodName;
            numProp = inNumProp;
           
        }

        public Neighbourhood(string inHoodName)
        {
            nHoodName = inHoodName;
        }

        // Getters //

        public string getNHoodName()
        {
            return nHoodName;
        }

        public int getNumProp()
        {
            return numProp;
        }

        public Property[] getHoodAllProp()
        {
            return hoodAllProp;
        }


        // Setters //

        public void setNHoodName (string theHoodName)
        {
            nHoodName = theHoodName;
        }

        public void setNumProp (int theNumProp)
        {
            try
            {
                numProp = Convert.ToInt32(theNumProp);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please enter a valid number.");
            }
        }

        public void setHoodAllProp (Property theAllProp, int theNumProp)
        {
            hoodAllProp[theNumProp] = theAllProp;
        }
        public void setHoodAllProp(Property[] theAllProp)
        {
            hoodAllProp = theAllProp;
        }

        public void addProp(Property inProp)
        {
            Array.Resize(ref hoodAllProp, hoodAllProp.Length + 1);
            hoodAllProp[hoodAllProp.Length - 1] = inProp;
        }

    }
}
