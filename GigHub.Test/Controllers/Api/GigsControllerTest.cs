using FluentAssertions;
using GigHub.API;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;


namespace GigHub.Test.Controllers.Api
{
    [TestClass]
    public class GigsControllerTest
    {
        private GigsController _gigsController;
        private Mock<IGigRepository> _mockRespository;
        private string _userId;

        public GigsControllerTest()
        {
            _mockRespository = new Mock<IGigRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Gigs).Returns(_mockRespository.Object);

            _gigsController = new GigsController(mockUoW.Object);
            _userId = "1";
            _gigsController.MockCurrentUser(_userId, "user1@domain.com");

        }
        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_GigIsCanceled_ShouldReturnNotFound()
        {
            var gig = new Gig();
            gig.Cancel();

            _mockRespository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);

            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_UserCancelingAnotherUsersGig_ShouldReturnUnauthorized()
        {
            var gig = new Gig {ArtistId = _userId + "-"};

            _mockRespository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);

            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<UnauthorizedResult>();

        }

        [TestMethod]
        public void Cancel_ValidRequeset_ShouldReturnOk()
        {
            var gig = new Gig { ArtistId = _userId };

            _mockRespository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);

            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<OkResult>();
        }
        
    }
}
