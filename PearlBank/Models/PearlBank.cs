using System.Collections.Generic;

namespace PearlBank.Models
{
    public class Bank : IBank, ISave
    {
        Dictionary<string, IAccount> accountDictionary = new Dictionary<string, IAccount>();

        public IAccount FindAccount(string name)
        {
            if (accountDictionary.ContainsKey(name))
                return accountDictionary[name];
            else
                return null;
        }

        public bool StoreAccount(IAccount account)
        {
            if (accountDictionary.ContainsKey(account.GetName()))
                return false;
            accountDictionary.Add(account.GetName(), account);
            return true;
        }

        public bool Save(string filename)
        {
            System.IO.TextWriter textOut = null;
            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch { return false; }
            finally
            {
                if (textOut != null)
                {
                    textOut.Close();
                }
            }
            return true;
        }

        public void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(accountDictionary.Count);
            foreach (Account account in accountDictionary.Values)
            {
                textOut.WriteLine(account.GetType().Name);
                account.Save(textOut);
            }
        }

        public static Bank Load(string fileName)
        {
            System.IO.TextReader textIn = null;
        //    return Load(textIn);
        //}
        //public static Bank Load(System.IO.TextReader textIn)
        //{
            Bank result = new Bank();
            string countString = textIn.ReadLine();
            int count = int.Parse(countString);
            for (int i = 0; i < count; i++)
            {
                string className = textIn.ReadLine();
                IAccount account = AccountFactory.MakeAccount(className, textIn);
                result.accountDictionary.Add(account.GetName(), account);
            }
            return result;
        }
    }
}
