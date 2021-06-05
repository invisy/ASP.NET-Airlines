using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.PlaneTests
{
    public class UpdateName
    {
        private readonly string _planeCorrectName = "PlaneCorrectName";
        private readonly string _planeTooLongName = new string('a', 51);
        private readonly string _planeEmplyName = "";

        public UpdateName()
        {
            
        }

        [Fact]
        public void PassesWithCorrectName()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            plane.UpdateName(_planeCorrectName);
            //Assert
            Assert.Equal(plane.Name, _planeCorrectName);
        }
        
        [Fact]
        public void CantSetEmptyName()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            Action act = () => plane.UpdateName(_planeEmplyName);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("name", exception.ParamName);
        }
        
        [Fact]
        public void CantSetTooLongName()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            Action act = () => plane.UpdateName(_planeTooLongName);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("name", exception.ParamName);
        }
    }
}