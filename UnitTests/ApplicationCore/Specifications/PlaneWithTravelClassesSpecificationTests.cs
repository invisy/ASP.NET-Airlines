using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Specifications;

namespace UnitTests.ApplicationCore.Specifications
{
    public class PlaneWithTravelClassesSpecificationTests
    {
        private readonly int _testPlaneId = 123;
        private readonly int _invalidPlaneId = 888;
        private readonly string _testPlaneName = "Plane";
        private readonly string _testPlaneModel = "MD-01";
        private readonly int _testPlaneTotalSeats = 10;

        [Fact]
        public void MatchesPlaneWithGivenPlaneId()
        {
            var spec = new PlaneWithTravelClassesSpecification(_testPlaneId);

            var result = GetPlaneCollection().AsQueryable().Where(spec.WhereExpressions.FirstOrDefault()).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(_testPlaneId, result.Id);
        }
        
        [Fact]
        public void ReturnsNullIfNotFount()
        {
            var spec = new PlaneWithTravelClassesSpecification(_invalidPlaneId);

            var result = GetPlaneCollection().AsQueryable().Where(spec.WhereExpressions.FirstOrDefault()).FirstOrDefault();

            Assert.Null(result);
        }

        private List<Plane> GetPlaneCollection()
        {
            var plane1Mock = new Mock<Plane>(_testPlaneName, _testPlaneModel, _testPlaneTotalSeats);
            plane1Mock.SetupGet(p => p.Id).Returns(1);
            var plane2Mock = new Mock<Plane>(_testPlaneName, _testPlaneModel, _testPlaneTotalSeats);
            plane2Mock.SetupGet(p => p.Id).Returns(2);
            var plane3Mock = new Mock<Plane>(_testPlaneName, _testPlaneModel, _testPlaneTotalSeats);
            plane3Mock.SetupGet(p => p.Id).Returns(_testPlaneId);

            return new List<Plane>()
            {
                plane1Mock.Object,
                plane2Mock.Object,
                plane3Mock.Object
            };
        }
    }
}