using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirBnBDatabase
{
    class District
    {
        private string districtName;
        private int numHood;
        private Neighbourhood[] distAllHood;
       


        public District(string inDistName, int inNumHood, Neighbourhood[] inAllHood)
        {
            districtName = inDistName;
            numHood = inNumHood;
            distAllHood = inAllHood;
           
        }

        public District(string inDistName, int inNumHood)
        {
            districtName = inDistName;
            numHood = inNumHood;
            

        }


        // Getters //


        public string getInDistName()
        {
            return districtName;
        }

        public int getNumHood()
        {
            return numHood;
        }

        public Neighbourhood[] getDistAllHood()
        {
            return distAllHood;
        }



        // Setters //


        public void setNHoodName(string theHoodName)
        {
            districtName = theHoodName;
        }

        public void setNumHood(int theNumHood)
        {
            try
            {
                numHood = Convert.ToInt32(theNumHood);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR:" + e.Message + "Please enter a valid number.");
            }
        }

        public void setHoodAllProp(Neighbourhood[] theAllHood)
        {
            distAllHood = theAllHood;
        }

        public void setDistName(string inDistName)
        {
            districtName = inDistName;
        }
    }
}