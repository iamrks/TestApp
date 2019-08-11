using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestApp.BusinessLogic.Infrastructure.Interfaces;
using TestApp.Models;

namespace TestApp.Data.Repositories
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        private UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _userManager = ApplicationUserManager.Instance;
        }

        public async Task<IdentityResult> RegisterUser(CreateUserModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
