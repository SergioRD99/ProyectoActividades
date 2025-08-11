using Activities.Abstractions;
using Activities.Entities;

namespace Activities.Repository
{
    internal class UserRepository : IUserRepository
    {
        public Task<Users> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
