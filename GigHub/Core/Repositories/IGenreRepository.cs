using System.Collections.Generic;
using GigHub4.Core.Models;

namespace GigHub4.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}