using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNT_NS;

namespace PaymentGatewayManage.classes
{
    class User
    {
        public User(string name, string loginId, string pwd)
        { 
            fullname = name;
            username = loginId;
            password = pwd;

            Console.WriteLine($"USER: username:{username}, password:{password}, fullname:{fullname}");
        }
        public string fullname;
        public string username;
        public string password;
        public List<Iaccount> myAccount = new List<Iaccount>();
    }
}
