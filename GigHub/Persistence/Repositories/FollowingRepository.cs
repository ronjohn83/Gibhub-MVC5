using System.Linq;
using GigHub4.Core.Models;
using GigHub4.Core.Repositories;

namespace GigHub4.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetFollowing(string userId, Gig gig)
        {
            return _context.Followings
                .Any(f => f.FolloweeId == userId && f.FolloweeId == gig.ArtistId);
        }

    }
}