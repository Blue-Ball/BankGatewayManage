using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNT_NS;
using PaymentGatewayManage.classes;

namespace ACCOUNT_NS
{
    class GoodsAccount : Iaccount
    {
        public string accountType = "Goods";
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

        public GoodsAccount(User usr, ShareType shr)
        {
            owner = usr;
            share = shr;
            description = "Goods Account";
        }

        public class GoodsItem
        {
            public GoodsItem(Goods goods, float fAmount)
            {
                oGoods = goods;
                fBalance = fAmount;
            }
            public Goods oGoods;
            public float  fBalance;

        }

        private List<GoodsItem> GoodsPackList = new List<GoodsItem>();
        public void buy(Goods oGoods, float fAmount)
        {
            foreach (GoodsItem goods in GoodsPackList)
            {
                if (goods.oGoods.sGoodsName == oGoods.sGoodsName)
                {
                    goods.fBalance += fAmount;
                    Console.WriteLine($"BuyGoods: Account:{this.owner.fullname}, Goods:{oGoods.sGoodsName}, Unit:{oGoods.sUnit}, Amount:{fAmount}, Remain:{goods.fBalance}");
                    return;
                }
            }
            Console.WriteLine($"BuyGoods: Account:{this.owner.fullname}, Goods:{oGoods.sGoodsName}, Unit:{oGoods.sUnit}, Amount:{fAmount}, Remain:{fAmount}");
            GoodsPackList.Add(new GoodsItem(oGoods, fAmount));
            return;
        }
        public bool sell(Goods oGoods, float fAmount)
        {
            foreach (GoodsItem goods in GoodsPackList)
            {
                if (goods.oGoods.sGoodsName == oGoods.sGoodsName)
                {
                    if (goods.fBalance >= fAmount)
                    {
                        goods.fBalance -= fAmount;
                        Console.WriteLine($"SellGoods: Account:{this.owner.fullname}, Goods:{oGoods.sGoodsName}, Unit:{oGoods.sUnit}, Amount:{fAmount}, Remain:{goods.fBalance}");
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public void printAccount()
        {
            Console.WriteLine($"ID:{ID}, owner:{owner.fullname}, Account:{description}");
            foreach (GoodsItem goods in GoodsPackList)
            {
                Console.WriteLine($"\t Goods:{goods.oGoods.sGoodsName}, Unit:{goods.oGoods.sUnit}, Amount:{goods.fBalance}");
            }
        }

    }
}
