using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistance.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetFollowing(Gig gig, string userId)
        {
            return _context.Followings
                .Any(f => f.FolloweeId == gig.ArtistId && f.FolloweeId == userId);
        }
    }
}