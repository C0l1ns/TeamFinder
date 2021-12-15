using System.Collections.Generic;
using TeamFinder.Models;

namespace TeamFinderDAL.Entities
{
    public class BoardGame
    {
        public int BGameId { get; set; }

        public string BGameName { get; set; }
        
        public byte Difficulty { get; set; }
        
        public IList<Tag> Tags { get; set; }

        public IList<User> FavoredByUsers { get; set; }
    }
}