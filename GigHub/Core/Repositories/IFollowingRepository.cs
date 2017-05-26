using GigHub4.Core.Models;

namespace GigHub4.Core.Repositories
{
    public interface IFollowingRepository
    {
        bool GetFollowing(string userId, Gig gig);
    }
}