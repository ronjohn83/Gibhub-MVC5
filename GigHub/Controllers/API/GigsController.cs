﻿using GigHub4.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub4.Controllers.API
{
    [System.Web.Http.Authorize]
    //[Route("api/gigs")]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetGigWithArtist(id);

            if (gig == null || gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId == userId)
                return Unauthorized();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
