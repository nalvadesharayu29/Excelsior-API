using System.Threading.Tasks;
using Excelsior.API.Models;

namespace Excelsior.API.Data
{
    public class ITRRepository : IITRRepository
    {
        private readonly DataContext _context;

        public ITRRepository(DataContext context)
        {
            _context=context;
        }

        public Task<User> AddUserDetails(User user)
        {
            return null;
        }
    }
}