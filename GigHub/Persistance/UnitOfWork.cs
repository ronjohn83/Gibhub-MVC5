using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistance.Repositories;
using GigHub.Repositories;

namespace GigHub.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; set; }
        public IGenreRepository Genres { get; set; }
        public IFollowingRepository Followings { get; set; }
        public IAttendanceRepository Attendances { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
            Attendances = new AttendanceRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}