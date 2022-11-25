using OQQA67.GameLogics;
using OQQA67.Interfaces;

namespace OQQA67.Commands
{
    internal sealed class PlayCommand : IMenuCommands
    {
        public string Name => "!play";

        public void Execute(Player player)
        {

            BlackJackGameLogic.Gameplay(player);

        }
    }
}
