namespace PearlBank.Models
{
    public sealed class StudentAccount : Account
    {
        private string schoolName;

        public StudentAccount(string inName, string inAddress, decimal inBalance, string schoolName) : base(inName, inAddress, inBalance)
        {
            this.schoolName = schoolName;
        }

        public override string RudeLetterString()
        {
            return "No parties anymore - you are overdrawn";
        }

        public override string ToString()
        {
            return base.ToString() + " School: " + schoolName;
        }
    }
}
