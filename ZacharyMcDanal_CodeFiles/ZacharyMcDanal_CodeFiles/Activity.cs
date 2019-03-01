using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class Activity
    {
        int _id;
        string _activity;
        

        public Activity(int ID, string Activity)
        {
            _id = ID;
            _activity = Activity;
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("[" + _id + "] " + _activity);

            return retVal;
        }
    }
}
