using Forum.Application.Common.Models;

namespace Forum.Application.Common.Services
{
    public interface IBanService
    {
        Task<BanDto?> GetBanById(int banId, CancellationToken cancellationToken);

        Task<BanDto?> GetBanByUserId(int userId, CancellationToken cancellationToken);

        Task<IEnumerable<BanDto?>> GetBans(CancellationToken cancellationToken);

        Task<IEnumerable<BanDto?>> GetExpiredBans(CancellationToken cancellationToken);
    }
}
