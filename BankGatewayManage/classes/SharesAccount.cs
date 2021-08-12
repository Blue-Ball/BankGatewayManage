using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNT_NS;
using PaymentGatewayManage.classes;

namespace ACCOUNT_NS
{
    class SharesAccount : Iaccount
    {
        public string accountType = "Shares And Bonds";
        private User _owner;
        public User owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        private ShareType _share;
        public ShareType share
        {
            get { return _share; }
            set { _share = value; }
        }
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _description;
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }
        public class c_shares
        {
            public c_shares(string _sShareName, float _fShareholderPercentage)
            {
                sShareName = _sShareName;
                fShareholderPercentage = _fShareholderPercentage;
            }
            public string sShareName;
            public float fShareholderPercentage;
        }
        public class c_bonds
        {
            public c_bonds(string _sBonsName, float _fBonsPrice)
            {
                sBonsName = _sBonsName;
                fBonsPrice = _fBonsPrice;
            }
            public string sBonsName;
            public float fBonsPrice;
        }
        public class SharesPack
        {
            public c_shares oShare;
            public float fBalance;
            public SharesPack(c_shares item, float quentity)
            {
                oShare = item;
                fBalance = quentity;
            }
        }
        public class BondsPack
        {
            public c_bonds oBonds;
            public float fBalance;
            public BondsPack(c_bonds item, float quentity)
            {
                oBonds = item;
                fBalance = quentity;
            }

        }

        public List<SharesPack> SharesList = new List<SharesPack>();
        public List<BondsPack> BondsList = new List<BondsPack>();
        public SharesAccount(User usr, ShareType shr)
        {
            owner = usr;
            share = shr;
            description = "Shares Account";
        }
        public void buyShares(c_shares item, float fCount)
        {
            foreach (SharesPack sharesItem in SharesList)
            {
                if (sharesItem.oShare.sShareName == item.sShareName)
                {
                    sharesItem.fBalance += fCount;
                    Console.WriteLine($"BuyShares: Account:{this.owner.fullname}, Shares:{item.sShareName}, Count:{fCount}, Remain:{sharesItem.fBalance}");
                    return;
                }
            }
            Console.WriteLine($"BuyShares: Account:{this.owner.fullname}, Shares:{item.sShareName}, Count:{fCount}, Remain:{fCount}");
            SharesList.Add( new SharesPack(item, fCount));
            return;
        }
        public void buyBonds(c_bonds item, float fCount)
        {
            foreach (BondsPack bondsItem in BondsList)
            {
                if (bondsItem.oBonds.sBonsName == item.sBonsName)
                {
                    bondsItem.fBalance += fCount;
                    Console.WriteLine($"BuyBonds: Account:{this.owner.fullname}, Bonds:{item.sBonsName}, Count:{fCount}, Remain:{bondsItem.fBalance}");
                    return;
                }
            }
            Console.WriteLine($"BuyBonds: Account:{this.owner.fullname}, Bonds:{item.sBonsName}, Count:{fCount}, Remain:{fCount}");
            BondsList.Add(new BondsPack(item, fCount));
            return;
        }

        public bool sellShares(c_shares item, float fCount)
        {
            foreach (SharesPack sharesItem in SharesList)
            {
                if (sharesItem.oShare.sShareName == item.sShareName)
                {
                    if (sharesItem.fBalance >= fCount)
                    {
                        sharesItem.fBalance -= fCount;
                        Console.WriteLine($"SellShares: Account:{this.owner.fullname}, Shares:{item.sShareName}, Count:{fCount}, Remain:{sharesItem.fBalance}");
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool sellBonds(c_bonds item, float fCount)
        {
            foreach (BondsPack bondsItem in BondsList)
            {
                if (bondsItem.oBonds.sBonsName == item.sBonsName)
                {
                    if (bondsItem.fBalance >= fCount)
                    {
                        bondsItem.fBalance -= fCount;
                        Console.WriteLine($"SellBonds: Account:{this.owner.fullname}, Bonds:{item.sBonsName}, Count:{fCount}, Remain:{bondsItem.fBalance}");
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool transfer(float iCount, SharesAccount oOther)
        {
            // some operations at here
            // ...

            return true;
        }

        public void printAccount()
        {
            Console.WriteLine($"ID:{ID}, owner:{owner.fullname}, Account:{description}");
            foreach (SharesPack sharesItem in SharesList)
            {
                Console.WriteLine($"\t Share:{sharesItem.oShare.sShareName}, Amount:{sharesItem.fBalance}");
            }
            foreach (BondsPack bondsItem in BondsList)
            {
                Console.WriteLine($"\t Bond:{bondsItem.oBonds.sBonsName}, Amount:{bondsItem.fBalance}");
            }
        }
    }
}
