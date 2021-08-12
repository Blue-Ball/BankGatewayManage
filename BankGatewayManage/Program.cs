using ACCOUNT_NS;
using PaymentGatewayManage.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewayManage
{
    class Program
    {
        static string kind_Money = "BankAccount";
        static string kind_Goods = "GoodsAccount";
        static string kind_Shares = "SharesAccount";

        static void Main(string[] args)
        {
            Gateway myGateway = new Gateway();
            

            // add users and create accounts
            User jack = new User("Jack Smile", "js", "123");
            myGateway.CreateAccount(new BankAccount(jack, ShareType.share));
            myGateway.CreateAccount(new GoodsAccount(jack, ShareType.share));
            //myGateway.CreateAccount(new SharesAccount(jack, ShareType.notshare));

            Console.WriteLine();
            User joshi = new User("Joshi kumar", "jk", "123");
            myGateway.CreateAccount(new BankAccount(joshi, ShareType.share));
            //myGateway.CreateAccount(new GoodsAccount(joshi, ShareType.share));
            myGateway.CreateAccount(new SharesAccount(joshi, ShareType.notshare));

            Console.WriteLine();

            Console.WriteLine("--- Connect/Disconnect a user to/from the gateway ---");

            // Gateway Connecting and Account Listing
            Iaccount testAccount = myGateway.Connect("js", "123", kind_Money);
            if (testAccount == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("INR", 0), 12500);
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("USD", 0), 200);
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("INR", 0), 5000);
            myGateway.DepositMoney((BankAccount)testAccount, new Currency("INR", 0), 2550);
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("USD", 0), 250);
            myGateway.DisConnect(testAccount);

            Console.WriteLine();
            testAccount = myGateway.Connect("jk", "123", kind_Money);
            if(testAccount == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("USD", 0), 100);
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("USD", 0), 200);
            myGateway.WithdrawMoney((BankAccount)testAccount, new Currency("EUR", 0), 50);
            myGateway.DepositMoney((BankAccount)testAccount, new Currency("USD", 0), 50);
            myGateway.DisConnect(testAccount);

            Console.WriteLine();
            testAccount = myGateway.Connect("js", "123", kind_Goods);
            if (testAccount == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }
            myGateway.BuyGoods((GoodsAccount)testAccount, new Goods("Shirts", "Pair"), 15);
            myGateway.BuyGoods((GoodsAccount)testAccount, new Goods("Shirts", "Pair"), 25);
            myGateway.SellGoods((GoodsAccount)testAccount, new Goods("Shirts", "Pair"), 10);
            myGateway.DisConnect(testAccount);

            Console.WriteLine();
            testAccount = myGateway.Connect("jk", "123", kind_Shares);
            if (testAccount == null)
            {
                Console.WriteLine("Invalid Account");
                return;
            }
            myGateway.BuyShares((SharesAccount)testAccount, new SharesAccount.c_shares("example1", 50), 10000);
            myGateway.BuyShares((SharesAccount)testAccount, new SharesAccount.c_shares("example1", 50), 65000);
            myGateway.BuyShares((SharesAccount)testAccount, new SharesAccount.c_shares("example1", 50), 10000);
            myGateway.SellShares((SharesAccount)testAccount, new SharesAccount.c_shares("example1", 50), 30000);

            myGateway.BuyBonds((SharesAccount)testAccount, new SharesAccount.c_bonds("example2", 50), 23600);
            myGateway.BuyBonds((SharesAccount)testAccount, new SharesAccount.c_bonds("example2", 50), 65000);
            myGateway.SellBonds((SharesAccount)testAccount, new SharesAccount.c_bonds("example2", 50), 30000);
            myGateway.DisConnect(testAccount);

            Console.WriteLine();
            Console.WriteLine("--- Print account statement for the user ---");

            // List all user accounts
            Iaccount[] allAccounts = myGateway.GetAllAccountList();
            foreach (Iaccount element in allAccounts)
            {
                element.printAccount();
                Console.WriteLine();
            }


            return;
        }
    }
}
