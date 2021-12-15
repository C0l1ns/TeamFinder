using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamFinderDAL.Models.Entities;

namespace TeamFinder.Models.ViewModels
{
    public class LobbyVM
    {
        public Lobby Lobby { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}