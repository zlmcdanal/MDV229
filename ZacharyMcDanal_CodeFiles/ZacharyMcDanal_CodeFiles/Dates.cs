using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class Dates
    {
        int _calDateID;
        DateTime _calDate;


        public Dates(int CalDateID, DateTime CalDate)
        {
            _calDateID = CalDateID;
            _calDate = CalDate;
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("[" + _calDateID + "] " + _calDate.ToString("dd MMMM yyyy"));

            return retVal;
        }
    }
}
