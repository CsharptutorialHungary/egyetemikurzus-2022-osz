using System.Xml.Serialization;

namespace ZWPARW.Object
{
    [Serializable]
    public class Users
    {
        public HashSet<User> Felhasznalok = new HashSet<User>();

    }
    public record User
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Password { get; init; }

        public string Rank { get; init; }

        public User(int id, string name, string password, string rank)
        {
            Id = id;
            Name = name;
            Password = password;
            Rank = rank;
        }
        public User() { }
    }
}
