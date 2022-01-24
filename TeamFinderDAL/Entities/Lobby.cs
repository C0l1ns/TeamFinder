using System;
using System.Collections.Generic;
using TeamFinder.Models;

namespace TeamFinderDAL.Entities
{
    public class Lobby : IEntity
    {
        public int Id { get; set; }

        public string About { get; set; }
        
        public DateTime GameDate { get; set; }

        public string GameLocation { get; set; }
        
        public byte MinNumberOfPlayers { get; set; }
        
        public byte MaxNumberOfPlayers { get; set; }
        
        public List<User> ConnectedUsers { get; set; }

        public string HostId { get; set; }

        public User Host { get; set; }
        
        public int HostedGameId { get; set; }

        public BoardGame HostedGame { get; set; }

        public IList<Message> Messages { get; set; }
    }
}