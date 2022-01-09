﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamFinderBL.Interfaces;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Models.ViewModels;

namespace TeamFinderBL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task AssignUserToRoles(AssignedRoles assignedRoles)
        {
            
        }

        public async Task CreateRole(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        public async Task<IEnumerable<string>> GetRolesForCertainUser(User user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task DeleteRole(string roleName)
        {
            await _roleManager.DeleteAsync((await _roleManager.Roles.ToListAsync()).FirstOrDefault(x => x.Name == roleName));
        }
    }
}
