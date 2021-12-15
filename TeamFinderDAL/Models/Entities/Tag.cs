using System.Collections.Generic;

namespace TeamFinderDAL.Models.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        
        public string Name { get; set; }

        public IList<BoardGame> BoardGames { get; set; }
    }
}