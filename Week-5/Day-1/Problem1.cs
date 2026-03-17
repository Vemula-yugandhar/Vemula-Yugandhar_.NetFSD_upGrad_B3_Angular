namespace Oops_Concepts
{
    public class BankAccount
    {
        private string _AccountHolderName;
        private long _AccountNumber;
        private decimal _Balance;

      

        public long AccountNumber
        {
            get { return _AccountNumber; }
            set { _AccountNumber = value; }
        }
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        public BankAccount(string accountHolderName, long accountNumber, decimal balance)
        {
            if (string.IsNullOrEmpty(accountHolderName))
            {
                throw new ArgumentNullException("Account holder name cannot be empty");
            }

            if (balance < 1000)
            {
                throw new ArgumentOutOfRangeException("Balance should be greater than 1000");
            }

            _AccountHolderName = accountHolderName;
            _AccountNumber = accountNumber;
            _Balance = balance;
        }

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Deposit Amount should be greater than 0");
            }
            _Balance += amount;
            Console.WriteLine($"{amount} is deposited to your account. current balance = {_Balance}");
        }

        public void WithDraw(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Withdraw Amount should be greater than 0");
            }
            if (amount > _Balance)
            {
                throw new Exception("Insufficient Balance");
            }
            _Balance -= amount;
            Console.WriteLine($"{amount} withdrawn from  your account. current balance = {_Balance}");

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("Yugandhar", 38946389, 15000);

            bankAccount.Deposit(1000);

            //bankAccount.WithDraw(-1000); //Error

            bankAccount.WithDraw(4000);
        }
    }
}
