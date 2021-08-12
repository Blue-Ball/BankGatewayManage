using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGatewayManage.classes;

namespace ACCOUNT_NS
{
  
    interface Iaccount
    {
        User owner {get;set;}
        ShareType share {get; set;}
        int ID  {get; set;}
        String description { get; set; }

        void printAccount();
    }
}
