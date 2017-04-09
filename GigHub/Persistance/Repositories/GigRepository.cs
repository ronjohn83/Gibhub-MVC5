using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly IApplicationDbContext _context;

        public GigRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public IEnumerable<Gig> GetUpcomingGigsByArtist(string userId)
        {
            return _context.Gigs
                .Where(g =>
                    g.ArtistId == userId &&
                    g.DateTime > DateTime.Now &&
                    g.IsCanceled == false)
                .Include(g => g.Genre)
                .ToList();
        }


    


        public Gig GetGig(int id, string userId)
        {
            return _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
        }

        public void AddGig(Gig gig)
        {
            _context.Gigs.Add(gig);
        }

        public void Save()
        {
            //_context.SaveChanges();
        }

        public Gig GetGigWithArtistAndGenre(int id)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == id);
        }



     
    }
}