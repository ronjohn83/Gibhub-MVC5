using System.Collections.Generic;
using GigHub4.Core.Models;

namespace GigHub4.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        bool GetAttending(Gig gig, string userId);
    }
}