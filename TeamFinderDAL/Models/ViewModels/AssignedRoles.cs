using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamFinderDAL.Enums;

namespace TeamFinderDAL.Models.ViewModels
{
    public class AssignedRoles
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public Roles Roles { get; set; }
    }
}
