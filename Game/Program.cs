using Game.Engine;
using Game.Portfolio;
using Game.UI;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet();

            while (true)
            {
                Console.WriteLine("Please, submit action:");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid input. Operation is required.");
                    continue;
                }

                if (!ProcessInput(input, wallet))
                {
                    break;
                }
            }

            Console.WriteLine("Thank you for playing! Hope to see you again soon.");
        }

        static bool ProcessInput(string input, Wallet wallet)
        {
            var userAction = new UserAction(input);

            switch (userAction.Operation)
            {
                case OperationEnum.exit:
                    return false;
                case OperationEnum.unrecognized:
                    Console.WriteLine("Unrecognized command!");
                    break;
                case OperationEnum.invalidamount:
                    Console.WriteLine("Invalid amount! Please bet between amount between 0-10 $.");
                    break;
                case OperationEnum.deposit:
                    ProcessDeposit(userAction, wallet);
                    break;
                case OperationEnum.withdraw:
                    ProcessWithdraw(userAction, wallet);
                    break;
                case OperationEnum.bet:
                    ProcessBet(userAction, wallet);
                    break;
                default:
                    Console.WriteLine("Unrecognized command!");
                    break;
            }

            return userAction.ContinueToPlay;
        }

        private static void ProcessDeposit(UserAction userAction, Wallet wallet)
        {
            bool isDepositSuccessful = wallet.Deposit(userAction.Amount.Value);
            if (isDepositSuccessful)
            {
                Console.WriteLine($"Your deposit of ${userAction.Amount.Value} was successful. Your current balance is: {wallet.Balance}");
            }
        }

        private static void ProcessWithdraw(UserAction userAction, Wallet wallet)
        {
            bool isWithdrawSuccessful = wallet.Withdraw(userAction.Amount.Value);
            if (isWithdrawSuccessful)
            {
                Console.WriteLine($"Your withdrawal of ${userAction.Amount.Value} was successful. Your current balance is: {wallet.Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        private static void ProcessBet(UserAction userAction, Wallet wallet)
        {
            if (!userAction.Amount.HasValue 
                || wallet.Balance < userAction.Amount)
            {
                Console.WriteLine($"Insufficient funds. The current balance is: ${wallet.Balance} and the bet was: ${userAction.Amount}.");
                return;
            }

            wallet.Withdraw(userAction.Amount.Value);
            decimal winnings = GameEngine.BetMoney(userAction.Amount.Value);

            if (winnings > 0)
            {
                wallet.Deposit(winnings);
                Console.WriteLine($"Congratulations! You won {winnings}$. Your current balance is: ${wallet.Balance}");
            }
            else
            {
                Console.WriteLine($"No luck this time. Your current balance is: ${wallet.Balance}");
            }
        }
    }
}