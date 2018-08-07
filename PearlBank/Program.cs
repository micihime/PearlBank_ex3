using PearlBank.Models;
using System;

namespace PearlBank
{
    public class Program
    {
        public static void Main()
        {
            Bank ourBank = new Bank();
            Account newAccount = new Account("Rob", "Za 7 horami", 1000000);
            if (ourBank.StoreAccount(newAccount))
                Console.WriteLine("CustomerAccount added to bank");
            BabyAccount newBabyAccount = new BabyAccount("David", "Za 7 horami", 100, "Rob");
            if (ourBank.StoreAccount(newBabyAccount))
                Console.WriteLine("BabyAccount added to bank");
            ourBank.Save("Test.txt");

            Bank loadBank = Bank.Load("Test.txt");
            IAccount storedAccount = loadBank.FindAccount("Rob");
            if (storedAccount != null)
                Console.WriteLine("CustomerAccount found in bank");
            storedAccount = loadBank.FindAccount("David");
            if (storedAccount != null)
                Console.WriteLine("BabyAccount found in bank");
        }
    }
}