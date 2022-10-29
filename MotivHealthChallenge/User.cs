namespace MotivHealthChallenge
{
    public class User
    {
        public User()
        {
            Username = string.Empty;
            Favorites = new List<Favorite>();
        }
        public User(string username)
        {
            Username = username;
            Favorites = new List<Favorite>();
        }
        public User(string username, List<Favorite> favorites)
        {
            Username = username;
            Favorites = favorites;
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public List<Favorite> Favorites { get; set; }

    }
}
