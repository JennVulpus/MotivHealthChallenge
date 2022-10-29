using System.Text.Json.Serialization;

namespace MotivHealthChallenge
{
    public class Favorite
    {
        
        //public Favorite(string name, int userId)
        //{
        //    Name = name;
        //    UserId = userId;
        //}
        //public Favorite(int id, string name, int userId)
        //{
        //    Id = id;
        //    Name = name;
        //    UserId = userId;
        //}

        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public int? UserId { get; set; }

    }
}
