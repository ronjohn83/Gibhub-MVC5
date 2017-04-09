using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistance;

namespace GigHub.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotification()
        {
            var userId = User.Identity.GetUserId();

            var notificaitons = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            //Mapper.Map<Notification, NotificationDto>();

            return notificaitons.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Gig = new GigDto
                {
                    Artist = new UserDto
                    {
                        Id = n.Gig.Artist.Id,
                        Name = n.Gig.Artist.Name
                    },
                    DateTime = n.Gig.DateTime,
                    Id = n.Gig.Id,
                    IsCanceled = n.Gig.IsCanceled,
                    Venue = n.Gig.Venue

                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalVenue = n.OriginalVenue,
                Type = n.Type

            });
        }
    }
}
