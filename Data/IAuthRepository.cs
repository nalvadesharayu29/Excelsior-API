using System.Threading.Tasks;
using Excelsior.API.Models;

namespace Excelsior.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string panNO, string password);
        Task<bool> UserExist(string panNo);
    }
}