using Activities.Entities;

namespace Activities.Abstractions;

public interface IUserRepository
{
    Task<Users> GetUsersAsync();

}