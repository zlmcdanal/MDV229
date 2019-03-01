using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class ViewByDate
    {
        string _specificActivCat;
        string _specificActivDesc;
        double _specificActivTime;

        public ViewByDate(string SpecificActivCat, string SpecificActivDesc, double SpecificActivTime)
        {
            _specificActivCat = SpecificActivCat;
            _specificActivDesc = SpecificActivDesc;
            _specificActivTime = SpecificActivTime;
        }

        public override string ToString()
        {
            string retVal = "";
            
            retVal += string.Format("{0, -30} {1,-30} {2, -5}", _specificActivCat, _specificActivDesc, _specificActivTime);
            
            return retVal;
        }
    }
}
