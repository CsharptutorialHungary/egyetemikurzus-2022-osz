using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQQA67.Commands
{
    internal sealed class PlayCommand : IBlackJackCommands
    {
        public string Name => "!play"; 
        private void ShuffleCards(List<string> cards)
        {
            Random rng = new Random();
            int numbers = cards.Count;
            while (numbers > 1)
            {
                numbers--;
                int randomIndex = rng.Next(numbers + 1);
                string value = cards[randomIndex];
                cards[randomIndex] = cards[numbers];
                cards[numbers] = value;
            }
        }

        public void Execute(Player player)
        {
            if (player.balance == 0)
            {
                Console.WriteLine("You don't have any credits! Use '!free'");
                return;
            }

            bool checker = false;
            while (!checker)
            {
                Console.WriteLine();
                Console.Write("Place your bet: ");
                string? line = Console.ReadLine();
                int bet;
                if (!int.TryParse(line, out bet))
                {
                    Console.WriteLine("You must enter an integer!");
                }
                else if (bet > player.balance)
                {
                    Console.WriteLine("You don't have enough credits!");
                }
                else
                {
                    Console.WriteLine($"Your bet: {bet}");
                    player.balance -= bet;
                    checker = true;
                }
            }

            List<string> basicCards = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<string> cards = new();
            for(int i=0;i<4;i++) cards.AddRange(basicCards);
            ShuffleCards(cards);

            List<string> playerCards = new();
            List<string> dealerCards = new();

            Console.WriteLine("Lets play!");
            var cardQueue = new Queue<string>(cards);
            bool play = true;
            
            playerCards.Add(cardQueue.Dequeue());
            playerCards.Add(cardQueue.Dequeue());
            dealerCards.Add(cardQueue.Dequeue());
            dealerCards.Add(cardQueue.Dequeue());

            Console.WriteLine($"Your cards: {playerCards.ElementAt(0)}, {playerCards.ElementAt(1)}");
            Console.WriteLine($"Dealer cards: {dealerCards.ElementAt(0)}, ?");
            

        }
    }
}
