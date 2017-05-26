using System.Collections.Generic;
using System.Linq;
using GigHub4.Core.Models;
using GigHub4.Core.Repositories;

namespace GigHub4.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

    }
}