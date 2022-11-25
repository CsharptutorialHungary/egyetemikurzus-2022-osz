namespace OQQA67.GameLogics
{
    internal static class BlackJackGameLogic
    {
        private static void ShuffleCards(List<string> cards)
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

        private static void WriteCards(List<string> cards)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\nYour cards: ");
            cards.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine($"Current points: {GetPoints(cards)}");
        }
        private static int GetPoints(List<string> cards)
        {
            int points = 0;

            Dictionary<string, int> values = new() { { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 },
                                                     { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 },
                                                     { "10", 10 }, { "J", 10 }, { "Q", 10 }, { "K", 10 },
            };

            points = cards.Sum(item => values.ContainsKey(item) ? values[item] : 0);

            int aces = cards.Where(item => item == "A").Count();
            int usedAces = 0;

            for (int i = 0; i < aces; i++)
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
            for (int i = 0; i < usedAces; i++)
            {
                if (points > 21)
                {
                    points -= 10;
                }
            }
            return points;
        }

        public static void Gameplay(Player player)
        {
            if (player.balance == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have any credits! Use '!free'");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~BlackJack~~~~~~~~~~~~~~~~~~");
            int bet = 0;
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Place your bet: ");
                string? line = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;

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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your bet: {bet}");
                    player.balance -= bet;
                    break;
                }
            }

            List<string> basicCards = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<string> cards = new();
            for (int i = 0; i < 4; i++) cards.AddRange(basicCards);
            ShuffleCards(cards);

            List<string> playerCards = new();
            List<string> dealerCards = new();

            var cardQueue = new Queue<string>(cards);

            playerCards.Add(cardQueue.Dequeue());
            playerCards.Add(cardQueue.Dequeue());
            dealerCards.Add(cardQueue.Dequeue());
            dealerCards.Add(cardQueue.Dequeue());

            int playerPoints = GetPoints(playerCards);
            int dealerPoints = GetPoints(dealerCards);

            WriteCards(playerCards);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Dealer cards: {dealerCards.ElementAt(0)}, ?");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nDo you want to double your bet? ('yes' or 'no')");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Answer: ");
                string? answer = Console.ReadLine();
                if (answer == "yes")
                {
                    if (player.balance - bet >= 0)
                    {
                        player.balance -= bet;
                        bet *= 2;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your new bet: {bet}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You dont have enough credits!");
                    }
                    break;
                }
                else if (answer == "no")
                {
                    Console.WriteLine("You didn't double your bet!");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid action!\n");
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nDo you want another card? ('yes' or 'no') ");
                Console.Write("Answer: ");
                string? action = Console.ReadLine();

                if (action == "no")
                {
                    break;
                }
                else if (action == "yes")
                {
                    playerCards.Add(cardQueue.Dequeue());
                    playerPoints = GetPoints(playerCards);
                    WriteCards(playerCards);

                    if (playerPoints >= 21) break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid action!\n");
                }
            }

            while (dealerPoints <= 16)
            {
                dealerCards.Add(cardQueue.Dequeue());
                dealerPoints = GetPoints(dealerCards);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\nDealer cards:");
            dealerCards.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine($"Current points: {dealerPoints}");

            if ((dealerPoints > 21 || playerPoints > dealerPoints) && playerPoints <= 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYou've won!");
                player.balance += bet * 2;

            }
            if (dealerPoints > playerPoints && dealerPoints <= 21 || playerPoints > 21)
            {
                Console.WriteLine("\nYou've lost!");


            }
            if (playerPoints == dealerPoints && playerPoints <= 21)
            {
                Console.WriteLine("\nTie!");
                player.balance += bet;

            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
