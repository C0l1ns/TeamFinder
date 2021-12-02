using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamFinder.Models
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