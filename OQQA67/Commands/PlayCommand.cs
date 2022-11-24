using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        private int GetPoints(List<string> cards)
        {
            int points = 0;

            Dictionary<string, int> values = new() { { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 },
                                                     { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 },
                                                     { "10", 10 }, { "J", 10 }, { "Q", 10 }, { "K", 10 },
            };

            points = cards.Sum(item => values.ContainsKey(item) ? values[item] : 0);

            int aces = cards.Where(item => item == "A").Count();
            int usedAces = 0;

            for(int i=0; i<aces; i++)
            {
                if (points + 11 <= 21)
                {
                    points += 11;
                    usedAces++;
                }
                else
                {
                    points++;
                }
            }
            for(int i = 0; i < usedAces;i++)
            {
                if (points > 21)
                {
                    points -= 10;
                }
            }
            return points;
        }
        public void Execute(Player player)
        {
            if (player.balance == 0)
            {
                Console.WriteLine("You don't have any credits! Use '!free'");
                return;
            }

            bool checker = false;
            bool losePlayer = false;
            bool loseDealer = false;

            int bet = 0;
            while (!checker)
            {
                Console.WriteLine();
                Console.Write("Place your bet: ");
                string? line = Console.ReadLine();
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

            Console.WriteLine();
            Console.WriteLine($"Current points: {GetPoints(playerCards)}");
            Console.WriteLine("Actions: '!stop', '!double', '!card'");
            while (play)
            {
                Console.Write("Action: ");
                string? action = Console.ReadLine();
                if(action == "!stop")
                {
                    play = false;
                }
                else if(action == "!double")
                {
                    Console.WriteLine($"New bet: {bet}");
                    player.balance -= bet;
                    bet *= 2;

                }
                else if(action == "!card")
                {
                    playerCards.Add(cardQueue.Dequeue());
                }
                else
                {
                    Console.WriteLine("Invalid action!");
                }
            }

        }
    }
}
