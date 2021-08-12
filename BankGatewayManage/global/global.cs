using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewayManage.classes
{
    class global
    {
    }
    enum ShareType
    {
        share = 1,
        notshare
    }

        
    public class Currency
    {
        public Currency(string name, float rate)
        {
            sUnitName = name;
            fRating = rate;
        }
        public string sUnitName;
        public float fRating;
    }

    public class Goods
    {
        public Goods(string name, string unit)
        {
            sGoodsName = name;
            sUnit = unit;
        }
        public string sGoodsName;
        public string sUnit;
    }
}
