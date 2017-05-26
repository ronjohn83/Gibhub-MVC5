using GigHub4.Core;
using GigHub4.Core.Models;
using GigHub4.Core.Repositories;
using GigHub4.Persistence.Repositories;

namespace GigHub4.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public IGigRepository Gigs { get; set; }
        public IGenreRepository Genres { get; set; }
        public IAttendanceRepository Attendance { get; set; }
        public IFollowingRepository Following { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(_context);
            Genres = new GenreRepository(_context);
            Attendance = new AttendanceRepository(_context);
            Following = new FollowingRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}