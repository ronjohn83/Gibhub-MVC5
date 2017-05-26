using GigHub4.Core.Repositories;

namespace GigHub4.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; set; }
        IGenreRepository Genres { get; set; }
        IAttendanceRepository Attendance { get; set; }
        IFollowingRepository Following { get; set; }
        void Complete();
    }
}