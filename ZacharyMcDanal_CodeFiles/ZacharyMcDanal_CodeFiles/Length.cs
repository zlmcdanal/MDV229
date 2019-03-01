using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class Length
    {
        int _lengthID;
        string _length;

        public Length(int LengthID, string Length)
        {
            _lengthID = LengthID;
            _length = Length;
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("[" + _lengthID + "] " + _length);

            return retVal;
        }
    }
}
