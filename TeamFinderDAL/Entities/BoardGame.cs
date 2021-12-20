using System.Collections.Generic;
using TeamFinder.Models;

namespace TeamFinderDAL.Entities
{
    public class BoardGame : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public byte Difficulty { get; set; }
        
        public IList<Tag> Tags { get; set; }

        public IList<User> FavoredByUsers { get; set; }
    }
}