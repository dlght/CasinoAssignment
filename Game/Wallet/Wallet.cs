using Game.UI;

namespace Game.Portfolio
{
    public class Wallet
    {
        public decimal Balance { get; private set; }

        public Wallet()
        {
            this.Balance = 0;
        }

        public bool Deposit(decimal amount)
        {
            Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                this.Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
