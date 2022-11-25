namespace OQQA67.Interfaces
{
    internal interface IMenuCommands
    {
        public string Name { get; }
        public void Execute(Player player);
    }
}
