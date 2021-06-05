using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.CityTests
{
    public class UpdateName
    {
        private readonly string _cityCorrectName = "CityCorrectName";
        private readonly string _cityTooLongName = new string('a', 51);
        private readonly string _cityEmplyName = "";

        public UpdateName()
        {
            
        }
        
        [Fact]
        public void PassesWithCorrectName()
        {
            //Arrange
            City city = new City();
            //Act
            city.UpdateName(_cityCorrectName);
            //Assert
            Assert.Equal(city.Name, _cityCorrectName);
        }

        [Fact]
        public void CantSetEmptyName()
        {
            //Arrange
            City city = new City();
            //Act
            Action act = () => city.UpdateName(_cityEmplyName);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("name", exception.ParamName);
        }
        
        [Fact]
        public void CantSetTooLongName()
        {
            //Arrange
            City city = new City();
            //Act
            Action act = () => city.UpdateName(_cityTooLongName);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("name", exception.ParamName);
        }
    }
}