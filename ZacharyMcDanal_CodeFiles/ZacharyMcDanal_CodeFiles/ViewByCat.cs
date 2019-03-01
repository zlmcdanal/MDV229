using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodeFiles
{
    class ViewByCat
    {
        DateTime _specificDate;
        string _specificActivDesc;
        double _specificActivTime;

        public ViewByCat(DateTime SpecificDate, string SpecificActivDesc, double SpecificActivTime)
        {
            _specificDate = SpecificDate;
            _specificActivDesc = SpecificActivDesc;
            _specificActivTime = SpecificActivTime;
        }

        public override string ToString()
        {
            string retVal = "";

            retVal += string.Format("{0, -30} {1,-30} {2, -5}", _specificDate.ToString("dd MMMM yyyy"), _specificActivDesc, _specificActivTime);

            return retVal;
        }
    }
}
