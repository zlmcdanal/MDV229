using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class ViewByDesc
    {
        DateTime _specificDate;
        string _specificActivCat;
        double _specificActivTime;

        public ViewByDesc(DateTime SpecificDate, string SpecificActivCat, double SpecificActivTime)
        {
            _specificDate = SpecificDate;
            _specificActivCat = SpecificActivCat;
            _specificActivTime = SpecificActivTime;
        }

        public override string ToString()
        {
            string retVal = "";

            retVal += string.Format("{0, -30} {1,-30} {2, -5}", _specificDate.ToString("dd MMMM yyyy"), _specificActivCat, _specificActivTime);

            return retVal;
        }
    }
}
