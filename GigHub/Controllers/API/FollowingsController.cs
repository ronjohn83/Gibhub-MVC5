using System.Linq;
using System.Web.Http;
using GigHub4.Core.Dtos;
using GigHub4.Core.Models;
using GigHub4.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub4.Controllers.API
{
    [Authorize]
    [Route("api/followings")]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost()]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId);

            if (exist)
                return BadRequest("Following already exist");

            var following = new Following
            {
                FolloweeId = userId,
                FollowerId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();

        }
    }
}
