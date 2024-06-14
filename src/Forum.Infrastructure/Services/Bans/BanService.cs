using AutoMapper;
using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Forum.Application.Common.Services.DatabaseService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Forum.Infrastructure.Services.Bans
{
    public class BanService : IBanService
    {
        private readonly IDatabaseService databaseService;
        private readonly IMapper mapper;

        public BanService(IMapper mapper, IDatabaseService databaseService)
        {
            this.mapper = mapper;
            this.databaseService = databaseService;
        }

        public async Task<BanDto?> GetBanById(int banId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Bans.Where(b => b.Id == banId).FirstOrDefaultAsync(cancellationToken);

            return mapper.Map<BanDto>(result);
        }

        public async Task<BanDto?> GetBanByUserId(int userId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Bans.Where(b => b.UserId == userId).FirstOrDefaultAsync(cancellationToken);

            return mapper.Map<BanDto>(result);
        }

        public async Task<IEnumerable<BanDto?>> GetBans(CancellationToken cancellationToken)
        {
            var result = await databaseService.Bans.ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<BanDto?>>(result);
        }

        public async Task<IEnumerable<BanDto?>> GetExpiredBans(CancellationToken cancellationToken)
        {
            var result = await databaseService.Bans.Where(b => b.BanEndDate < DateTime.UtcNow).ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<BanDto?>>(result);
        }
    }
}
