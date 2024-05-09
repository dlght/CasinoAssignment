namespace Game.Engine
{
    public class GameEngine
    {
        public static decimal BetMoney(decimal amount)
        {
            var generator = new Random();
            var randomOutcome = generator.Next(101);

            decimal winnings = 0;

            if (randomOutcome <= 50)
            {
                // User loses
                winnings = 0;
            }
            else if (randomOutcome <= 90)
            {
                // User gets 2x the bet
                winnings = amount * 2;
            }
            else if (randomOutcome <= 100)
            {
                // User wins from 2x to 10x the amount bet
                var coefficient = generator.Next(2, 11);
                winnings = amount * coefficient;
            }

            return winnings;
        }
    }
}