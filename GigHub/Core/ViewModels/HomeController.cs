using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Persistance;
using GigHub.Persistance.Repositories;
using Microsoft.AspNet.Identity;

namespace GigHub.Core.ViewModels
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;
        private readonly AttendanceRepository _attendanceRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _attendanceRepository = new AttendanceRepository(_context);
        }

         public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled );

            var userId = User.Identity.GetUserId();
            var attendances = _attendanceRepository.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpComingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                Attendances = attendances
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}