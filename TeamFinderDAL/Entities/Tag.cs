using System.Collections.Generic;

namespace TeamFinderDAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public IList<BoardGame> BoardGames { get; set; }
    }
}