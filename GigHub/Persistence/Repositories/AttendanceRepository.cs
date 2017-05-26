using System;
using System.Collections.Generic;
using System.Linq;
using GigHub4.Core.Models;
using GigHub4.Core.Repositories;

namespace GigHub4.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList();
        }


        public bool GetAttending(Gig gig, string userId)
        {
            return _context.Attendances
                .Any(a => a.GigId == gig.Id && a.AttendeeId == userId);
        }

    }
}