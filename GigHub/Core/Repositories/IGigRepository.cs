using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        Gig GetGig(int id, string userId);
        void AddGig(Gig gig);
        void Save();
        Gig GetGigWithArtistAndGenre(int id);
    }
}