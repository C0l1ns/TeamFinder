using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamFinder.Models;

namespace TeamFinder.Models
{
    public class Lobby
    {
        public int LobbyId { get; set; }
        
        public string LobbyName { get; set; }
        
        public string About { get; set; }
        
        public DateTime GameDate { get; set; }

        public string GameLocation { get; set; }
        
        public IList<User> ConnectedUsers { get; set; }

        public int HostId { get; set; }

        public User Host { get; set; }
        
        public int HostedGameId { get; set; }

        public BoardGame HostedGame { get; set; }

        public IList<Message> Messages { get; set; }
    }
}