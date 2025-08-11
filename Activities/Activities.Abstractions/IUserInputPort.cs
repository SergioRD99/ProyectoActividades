using Activities.Entities;

namespace Activities.Abstractions;

public interface IUserInputPort
{
    Task<Users> GetUsersAsync();
}