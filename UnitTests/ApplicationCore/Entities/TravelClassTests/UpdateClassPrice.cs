using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.TravelClassTests
{
    public class UpdateClassPrice
    {
        private readonly int _travelClassCorrectClassPrice = 5;
        private readonly int _travelClassNegativeClassPrice = -1;

        public UpdateClassPrice()
        {
            
        }

        [Fact]
        public void PassesWithCorrectClassPrice()
        {
            //Arrange
            TravelClass travelClass = new TravelClass();
            //Act
            travelClass.UpdateClassPrice(_travelClassCorrectClassPrice);
            //Assert
            Assert.Equal(travelClass.ClassPrice, _travelClassCorrectClassPrice);
        }
        
        [Fact]
        public void CantSetNegativeClassPrice()
        {
            //Arrange
            TravelClass travelClass = new TravelClass();
            //Act
            Action act = () => travelClass.UpdateClassPrice(_travelClassNegativeClassPrice);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("price", exception.ParamName);
        }
    }
}