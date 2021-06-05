using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.TravelClassTests
{
    public class UpdateName
    {
        private readonly string _travelClassCorrectName = "TravelClassCorrectName";
        private readonly string _planeTooLongName = new string('a', 51);
        private readonly string _planeEmplyName = "";

        public UpdateName()
        {
            
        }

        [Fact]
        public void PassesWithCorrectName()
        {
            //Arrange
            TravelClass travelClass = new TravelClass();
            //Act
            travelClass.UpdateName(_travelClassCorrectName);
            //Assert
            Assert.Equal(travelClass.Name, _travelClassCorrectName);
        }
        
        [Fact]
        public void CantSetEmptyName()
        {
            //Arrange
            TravelClass travelClass = new TravelClass();
            //Act
            Action act = () => travelClass.UpdateName(_planeEmplyName);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("name", exception.ParamName);
        }
        
        [Fact]
        public void CantSetTooLongName()
        {
            //Arrange
            TravelClass travelClass = new TravelClass();
            //Act
            Action act = () => travelClass.UpdateName(_planeTooLongName);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("name", exception.ParamName);
        }
    }
}