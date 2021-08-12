using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNT_NS;
using PaymentGatewayManage.classes;

namespace ACCOUNT_NS
{
    class BankAccount : Iaccount
    {
        public string accountType = "Bank";
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
        
        public class Money
        {
            public Money(Currency cur, float quantity)
            {
                oCurrency = cur;
                fBalance = quantity;
            }
            public Currency oCurrency;
            public float fBalance;
        }

        private List<Money> MoneySiteList = new List<Money>();

        public BankAccount(User usr, ShareType shr)
        {
            owner = usr;
            share = shr;
            description = "Bank Account";
            //ID = accountId;
        }
        public void withdraw(Currency oCurrency, float fAmount)
        {
            foreach (Money site in MoneySiteList)
            {
                if (site.oCurrency.sUnitName == oCurrency.sUnitName)
                {
                    site.fBalance += fAmount;
                    Console.WriteLine($"Withdraw: Account:{this.owner.fullname}, Currency:{oCurrency.sUnitName}, Amount:{fAmount}, Balance:{site.fBalance}");
                    return;
                }
            }
            MoneySiteList.Add(new Money(oCurrency, fAmount));
            Console.WriteLine($"Withdraw: Account:{this.owner.fullname}, Currency:{oCurrency.sUnitName}, Amount:{fAmount}, Balance:{fAmount}");
            return;
        }
        public bool deposit(Currency oCurrency, float fAmount)
        {
            foreach (Money site in MoneySiteList)
            {
                if (site.oCurrency.sUnitName == oCurrency.sUnitName)
                {
                    if(site.fBalance >= fAmount)
                    {
                        site.fBalance -= fAmount;
                        Console.WriteLine($"Deposit: Account:{this.owner.fullname}, Currency:{oCurrency.sUnitName}, Amount:{fAmount}, Balance:{site.fBalance}");
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool transfer(float fAmount, BankAccount oOther)
        {
            //some operations at here
            // ...
            return true;
        }

        public void printAccount()
        {
            Console.WriteLine($"ID:{ID}, owner:{owner.fullname}, Account:{description}");
            foreach (Money site in MoneySiteList)
            {
                Console.WriteLine($"\t Currency:{site.oCurrency.sUnitName}, Balance:{site.fBalance}");
            }
        }
    }
}
