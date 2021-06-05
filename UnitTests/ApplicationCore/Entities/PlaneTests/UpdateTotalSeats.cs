using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.PlaneTests
{
    public class UpdateTotalSeats
    {
        private readonly int _planeCorrectTotalSeats = 5;
        private readonly int _planeZeroTotalSeats = 0;
        private readonly int _planeNegativeTotalSeats = -1;

        public UpdateTotalSeats()
        {
            
        }

        [Fact]
        public void PassesWithCorrectTotalSeats()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            plane.UpdateTotalSeats(_planeCorrectTotalSeats);
            //Assert
            Assert.Equal(plane.TotalSeats, _planeCorrectTotalSeats);
        }
        
        [Fact]
        public void CantSetZeroTotalSeats()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            Action act = () => plane.UpdateTotalSeats(_planeZeroTotalSeats);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("seats", exception.ParamName);
        }
        
        [Fact]
        public void CantSetNegativeTotalSeats()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            Action act = () => plane.UpdateTotalSeats(_planeNegativeTotalSeats);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("seats", exception.ParamName);
        }
    }
}