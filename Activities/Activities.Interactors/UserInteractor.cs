using Activities.Abstractions;
using Activities.Entities;

namespace Activities.Interactors
{
    public class UserInteractor(IUserRepository repository) : IUserInputPort
    {

        public Task<Users> GetUsersAsync()
        {
            return repository.GetUsersAsync();

        }
    }
}
