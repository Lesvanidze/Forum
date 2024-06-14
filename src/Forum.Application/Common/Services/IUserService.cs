using Forum.Application.Common.Models;

namespace Forum.Application.Common.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetUserById(int userId, CancellationToken cancellationToken);

        Task<UserDto?> GetUserByEmail(string email, CancellationToken cancellationToken);

        Task<UserDto?> GetUserByUserName(string userName, CancellationToken cancellationToken);

        Task<IEnumerable<UserDto>> GetAllUsers(CancellationToken cancellationToken);
    }
}
