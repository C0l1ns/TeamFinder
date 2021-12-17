using System.Collections.Generic;

namespace TeamFinderDAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string DisplayUsername { get; set; }
        
        public string About { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IList<Lobby> ConnectedLobbies { get; set; }
        
        public IList<BoardGame> FavoriteGames { get; set; }
        
        public IList<User> Friends { get; set; }

        public IList<User> FriendOf { get; set; }
    }
}