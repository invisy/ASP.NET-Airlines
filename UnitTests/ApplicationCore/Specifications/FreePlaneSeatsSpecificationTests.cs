using System.Collections.Generic;
using System.Linq;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Specifications;
using Moq;
using Xunit;

namespace UnitTests.ApplicationCore.Specifications
{
    public class PlaneSeatsSpecificationTests
    {
        private readonly int _expectedPlaneSeatId = 256;
        private readonly int _invalidId = 888;
        private readonly int _flightInstanceId = 123;
        private readonly int _travelClassId = 321;
        private readonly string _number = "A1";

        [Fact]
        public void MatchesPlaneSeatsWithGivenFlightInstanceIdAndTravelClassId()
        {
            var spec = new FreePlaneSeatsSpecification(_flightInstanceId, _travelClassId);

            var result = GetPlanePlaceCollection().AsQueryable().Where(spec.WhereExpressions.FirstOrDefault()).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(_expectedPlaneSeatId, result.Id);
        }
        
        [Fact]
        public void ReturnsNullIfNotFount()
        {
            var spec = new FreePlaneSeatsSpecification(_invalidId, _invalidId);

            var result = GetPlanePlaceCollection().AsQueryable().Where(spec.WhereExpressions.FirstOrDefault()).FirstOrDefault();

            Assert.Null(result);
        }

        private List<PlaneSeat> GetPlanePlaceCollection()
        {
            var planePlace1Mock = new Mock<PlaneSeat>(_number, _travelClassId+1000);
            planePlace1Mock.SetupGet(p => p.Id).Returns(1);
            var planePlace2Mock = new Mock<PlaneSeat>(_number, _travelClassId);
            planePlace2Mock.SetupGet(p => p.Id).Returns(_expectedPlaneSeatId);
            planePlace2Mock.SetupGet(p => p.FlightInstanceId).Returns(_flightInstanceId);
            var planePlace3Mock = new Mock<PlaneSeat>(_number, _travelClassId+2000);
            planePlace3Mock.SetupGet(p => p.Id).Returns(3);

            return new List<PlaneSeat>()
            {
                planePlace1Mock.Object,
                planePlace2Mock.Object,
                planePlace3Mock.Object
            };
        }
    }
}