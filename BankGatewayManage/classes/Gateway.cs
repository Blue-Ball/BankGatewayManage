using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNT_NS;

namespace PaymentGatewayManage.classes
{
    class Gateway
    {
        private List<Iaccount> gatewayAccountList = new List<Iaccount>();
        private int _maxID = 1;
        private List<int> connectedIDs = new List<int>();

        public bool CreateAccount(Iaccount userAccount)
        {
            userAccount.ID = _maxID++;
            gatewayAccountList.Add(userAccount);
            userAccount.owner.myAccount.Add(userAccount);

            Console.WriteLine($"GatewayAccount: id:{userAccount.ID}, owner:{userAccount.owner.username}, type:{userAccount.share}, desc:{userAccount.description}");
            return true;
        }

        //if connecting success, return true, or return false
        public Iaccount Connect(string username, string pwd, string kind)
        {
            foreach (Iaccount element in gatewayAccountList)
            {
                if (element.owner.username == username && element.owner.password == pwd && element.GetType().ToString() == "ACCOUNT_NS."+kind)
                {
                    Console.WriteLine($"\tConnected to Gateway: user:{element.owner.fullname}");
                    connectedIDs.Add(element.ID);
                    return element;
                }
            }
            return null;
        }
        public bool DisConnect(Iaccount userAccount)
        {
            Console.WriteLine($"\tDisconnected from Gateway: user:{userAccount.owner.fullname}");
            connectedIDs.Remove(userAccount.ID);
            return true;
        }

        //if connected account, return account list
        //, or return null
        public Iaccount[] GetAllAccountList(Iaccount userAccount)
        {
            //connecting check
            if (!connectedIDs.Exists(element => element == userAccount.ID))
                return null;


            return (Iaccount[])gatewayAccountList.ToArray(); 
        }

        public Iaccount[] GetAllAccountList()
        {
            return (Iaccount[])gatewayAccountList.ToArray(); 
        }

        //if connected account, operate that and return true
        //, or return false
        public bool DepositMoney(BankAccount account, Currency cur, float fAmount) {

            //connecting check
            if (!gatewayAccountList.Exists( element => element.Equals(account)))
                return false;

            // deposit action
            return account.deposit(cur, fAmount);
        }

        //if connected account and balance is sufficiant, operate that and return true
        //, or return false
        public bool WithdrawMoney(BankAccount account, Currency cur, float fAmount) 
        {
            //connecting check
            if (!gatewayAccountList.Exists( element => element.Equals(account)))
                return false;

            // withdraw action
            account.withdraw(cur, fAmount);
            return true;
        }

        public bool BuyGoods(GoodsAccount account, Goods goods, float fAmount)
        {
            //connecting check
            if (!gatewayAccountList.Exists(element => element.Equals(account)))
                return false;

            //buy action
            account.buy(goods, fAmount);
            return true;

        }
        public bool SellGoods(GoodsAccount account, Goods goods, float fAmount)
        {
            //connecting check
            if (!gatewayAccountList.Exists(element => element.Equals(account)))
                return false;

            //sell action
            return account.sell(goods, fAmount);
        }

        public bool BuyShares(SharesAccount account, SharesAccount.c_shares shares, float fAmount)
        {
            //connecting check
            if (!gatewayAccountList.Exists(element => element.Equals(account)))
                return false;

            //buy action
            account.buyShares(shares, fAmount);
            return true;

        }
        public bool SellShares(SharesAccount account, SharesAccount.c_shares shares, float fAmount)
        {
            //connecting check
            if (!gatewayAccountList.Exists(element => element.Equals(account)))
                return false;

            //sell action
            return account.sellShares(shares, fAmount);
        }

        public bool BuyBonds(SharesAccount account, SharesAccount.c_bonds bonds, float fAmount)
        {
            //connecting check
            if (!gatewayAccountList.Exists(element => element.Equals(account)))
                return false;

            //buy action
            account.buyBonds(bonds, fAmount);
            return true;

        }
        public bool SellBonds(SharesAccount account, SharesAccount.c_bonds bonds, float fAmount)
        {
            //connecting check
            if (!gatewayAccountList.Exists(element => element.Equals(account)))
                return false;

            //sell action
            return account.sellBonds(bonds, fAmount);
        }
    }
}
