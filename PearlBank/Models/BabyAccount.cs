namespace PearlBank.Models
{
    public sealed class BabyAccount : Account
    {
        #region Private Frields
        
        private string parentName;
        #endregion

        #region Properties

        public string ParentName { get; }
        #endregion

        #region Constructors

        public BabyAccount(string inName, string inAddress, decimal inBalance, string parentName) : base(inName, inAddress, inBalance)
        {
            this.parentName = parentName;
        }

        public BabyAccount(System.IO.TextReader textIn) : base(textIn)
        {
            parentName = textIn.ReadLine();
        }
        #endregion

        #region Methods

        #region overriden from Account

        public override bool WithdrawFunds(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }

            return base.WithdrawFunds(amount);
        }

        public override string RudeLetterString()
        {
            return "Tell daddy you are overdrawn";
        }

        public override void Save(System.IO.TextWriter textOut)
        {
            base.Save(textOut);
            textOut.WriteLine(parentName);
        }
        #endregion

        #region overriden from object

        public override string ToString()
        {
            return base.ToString() + " Parent: " + parentName;
        }
        #endregion

        #endregion
    }
}
