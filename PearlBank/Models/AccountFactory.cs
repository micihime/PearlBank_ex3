namespace PearlBank.Models
{
    public class AccountFactory
    {
        public static IAccount MakeAccount(string name, System.IO.TextReader textIn)
        {
            switch (name)
            {
                case "Account": return new Account(textIn);
                case "BabyAccount": return new BabyAccount(textIn);
                default: return null;
            }
        }
    }
}
