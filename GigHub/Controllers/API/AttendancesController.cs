using System.Linq;
using System.Web.Http;
using GigHub4.Core.Models;
using GigHub4.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub4.Controllers.API
{
    [Authorize]
    [Route("api/attendances")]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();    
        }

        [HttpPost()]
        public IHttpActionResult Attend(Attendance dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exist)
                return BadRequest("Attendee already exist.");

            var attend = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = User.Identity.GetUserId()
            };

            _context.Attendances.Add(attend);
            _context.SaveChanges();

            return Ok();
        }
    }
}
