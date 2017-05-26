using System.Collections.Generic;
using GigHub4.Core.Models;

namespace GigHub4.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetGigUserAttending(string userId);
        Gig GetGigWithAttendies(int id);
        IEnumerable<Gig> GetUpcomingGigsForArtist(string userId);
        Gig GetGig(int id);
        Gig GetGigWithArtist(int id);
        void Add(Gig gig);
    }
}