using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.BusinessLogic.Infrastructure.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(CreateUserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
