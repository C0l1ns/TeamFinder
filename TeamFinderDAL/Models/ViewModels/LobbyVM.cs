using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamFinderDAL.Entities;

namespace TeamFinder.Models.ViewModels
{
    public class LobbyVM
    {
        public Lobby Lobby { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}