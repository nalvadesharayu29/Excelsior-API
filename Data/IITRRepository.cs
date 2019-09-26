using System.Threading.Tasks;
using Excelsior.API.Models;

namespace Excelsior.API.Data
{
    public interface IITRRepository
    {
         Task<User> AddUserDetails(User user);
    }
}