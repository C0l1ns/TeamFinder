using System;
using TeamFinder.Models;

namespace TeamFinderDAL.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }
        
        public DateTime Date { get; set; }

        public int LobbyId { get; set; }
        
        public Lobby Lobby { get; set; }

        public int SenderId { get; set; }

        public User Sender { get; set; }

    }
}