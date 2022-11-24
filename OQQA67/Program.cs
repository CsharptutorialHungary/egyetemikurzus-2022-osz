﻿using System.Reflection;

namespace OQQA67
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Amazing BlackJack game");
            Console.ForegroundColor = ConsoleColor.Magenta;

            List<Player> ? players = PlayerLoaderSaver.LoadUsers();
            
            Player? player=null;

            var loader = new CommandLoader();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Username: ");
                string? name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name) && name.Length >= 4)
                {
                    foreach(var play in players)
                    {
                        if(play.Name == name)
                        {
                            player = play;
                        }
                    }
                    if(player == null)
                    {
                        player = new Player() { Name = name };
                        players.Add(player);
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username must contain at least 4 letters!");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nActions: '!free', '!balance', '!play', '!exit'");
            try
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nAction: ");
                    string? command = Console.ReadLine();
                    
                    if (!string.IsNullOrEmpty(command)
                        && loader.Commands.ContainsKey(command))
                    {
                        loader.Commands[command].Execute(player);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid action!");
                    }
                    PlayerLoaderSaver.SaveUsers(players);
                    await Task.Delay(200);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
            }

           
            
        }
    }
}