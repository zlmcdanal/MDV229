using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class Date
    {
        int _calDateID;
        string _calDate;


        public Date(int CalDateID, string CalDate)
        {
            _calDateID = CalDateID;
            _calDate = CalDate;
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("[" + _calDateID + "] " + _calDate);

            return retVal;
        }
    }
}
