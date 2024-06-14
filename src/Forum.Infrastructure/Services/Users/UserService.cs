using AutoMapper;
using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Forum.Application.Common.Services.DatabaseService;
using System.Data.Entity;

namespace Forum.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly IDatabaseService databaseService;
        private readonly IMapper mapper;

        public UserService(IDatabaseService databaseService, IMapper mapper)
        {
            this.databaseService = databaseService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto?>> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await databaseService.Users.ToListAsync();
            return mapper.Map<IEnumerable<UserDto?>>(result);
        }

        public async Task<UserDto?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var result =await databaseService.Users.Where(u => u.Email == email).FirstOrDefaultAsync(cancellationToken);
            return mapper.Map<UserDto?>(result);

        }

        public async Task<UserDto?> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Users.Where(u => u.Id == userId).FirstOrDefaultAsync(cancellationToken);
            return mapper.Map<UserDto>(result);
        }

        public async Task<UserDto?> GetUserByUserName(string userName, CancellationToken cancellationToken)
        {
            var result = await databaseService.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync(cancellationToken);

            return mapper.Map<UserDto>(result);
        }
    }
}
