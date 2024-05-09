namespace Game.UI
{
    public class UserAction
    {
        public OperationEnum Operation { get; private set; }
        public decimal? Amount { get; private set; }
        public bool ContinueToPlay => Operation != OperationEnum.exit;

        // Rounds to two decimal places for better visibility on the operation -- can be extracted in config for global use and/or changed
        private const int ROUND_DECIMAL_PLACES = 2; 

        private UserAction() { }

        public UserAction(string input)
        {
            string[] inputParts = input.Split(' ');

            if (!Enum.TryParse(inputParts[0], true, out OperationEnum operation))
            {
                Operation = OperationEnum.unrecognized;
                return;
            }

            Operation = operation;

            if (operation == OperationEnum.exit)
            {
                return;
            }
            else if (inputParts.Length == 2)
            {
                if (decimal.TryParse(inputParts[1], out decimal amount))
                {
                    if (operation == OperationEnum.bet 
                        && amount > 0 
                        && amount <= 10)
                    {
                        Amount = Math.Round(amount, ROUND_DECIMAL_PLACES);
                    }
                    else if (operation == OperationEnum.deposit 
                        || operation == OperationEnum.withdraw
                        && amount > 0)
                    {
                        Amount = Math.Round(amount, ROUND_DECIMAL_PLACES);
                    }
                    else
                    {
                        Operation = OperationEnum.invalidamount;
                    }
                }
                else
                {
                    Operation = OperationEnum.invalidamount;
                }
            }
            else
            {
                Operation = OperationEnum.unrecognized;
            }
        }
    }
}
