using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamFinder.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        
        public string Name { get; set; }

        public IList<BoardGame> BoardGames { get; set; }
    }
}