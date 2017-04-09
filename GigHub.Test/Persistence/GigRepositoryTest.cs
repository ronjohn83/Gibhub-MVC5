using GigHub.Core.Models;
using GigHub.Persistance;
using GigHub.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace GigHub.Test.Persistence
{
    [TestClass]
    public class GigRepositoryTest
    {
        private GigRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockGigs = new Mock<DbSet<Gig>>();
            
            
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Gigs).Returns(mockGigs.Object);

            _repository = new GigRepository(mockContext.Object);
        }
    }
}
