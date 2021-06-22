using BookStore_UI.Models;
using System.Threading.Tasks;

namespace BookStore_UI.Contracts
{
    interface IAuthenticationRepository
    {
        public Task<bool> Register(RegistrationModel user);
        public Task<bool> Login(LoginModel user);
        public Task Logout();
    }
}
