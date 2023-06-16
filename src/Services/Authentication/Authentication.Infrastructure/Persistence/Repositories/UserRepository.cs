using Authentication.Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Persistence.Repositories
{
  

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
          
        }
        public Task<IdentityResult> CreateAsync(IdentityUser user, string password)
            => _userManager.CreateAsync(user, password);

        public Task<IdentityUser> FindByIdAsync(string userId)
            => _userManager.FindByIdAsync(userId);
        public Task<IdentityUser> FindByNameAsync(string userName)
          => _userManager.FindByNameAsync(userName);

        public Task<IdentityResult> UpdateAsync(IdentityUser user)
           => _userManager.UpdateAsync(user);

        public async Task<IList<string>> GetRolesAsync(IdentityUser user)
            => await _userManager.GetRolesAsync(user);

        public async Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role)
            => await _userManager.AddToRoleAsync(user, role);
        public async Task<IdentityResult> AddToRoleAsync(IdentityUser user, IEnumerable<string> roles)
           => await _userManager.AddToRolesAsync(user, roles);
        public async Task<IdentityResult> AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims)
            => await _userManager.AddClaimsAsync(user, claims);

        public async Task<IdentityResult> AddClaimAsync(IdentityUser user, Claim claim)
         => await _userManager.AddClaimAsync(user, claim);

        public async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
         => await _userManager.GetClaimsAsync(user);

        public async Task<SignInResult> CheckPasswordSignInAsync(IdentityUser user, string password)
           => await _signInManager.CheckPasswordSignInAsync(user, password,false);



    }
}
