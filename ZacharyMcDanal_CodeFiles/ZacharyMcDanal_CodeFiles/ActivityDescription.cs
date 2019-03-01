using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class ActivityDescription
    {
        int _idDesc;
        string _activityDesc;


        public ActivityDescription(int IDDesc, string ActivityDesc)
        {
            _idDesc = IDDesc;
            _activityDesc = ActivityDesc;
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("[" + _idDesc + "] " + _activityDesc);

            return retVal;
        }
    }
}
