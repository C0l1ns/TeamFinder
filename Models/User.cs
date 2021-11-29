using System.ComponentModel.DataAnnotations;

namespace TeamFinder.Models
{
    public class User
    {
        [Key] public int Id { get; set; }


        public string Username { get; set; }
    }
}