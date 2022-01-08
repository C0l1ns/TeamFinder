using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Models.ViewModels;

namespace TeamFinderBL.Interfaces
{
    public interface IAccountService
    {
        Task AssignUserToRoles(AssignedRoles assignedRoles);
        Task CreateRole(string roleName);
        Task DeleteRole(string roleName);
        Task<IEnumerable<IdentityRole>> GetRoles();
        Task<IEnumerable<string>> GetRolesForCertainUser(User user);
    }
}