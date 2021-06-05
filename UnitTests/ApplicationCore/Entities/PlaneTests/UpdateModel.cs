using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.PlaneTests
{
    public class UpdateModel
    {
        private readonly string _planeCorrectModel = "CR-01";
        private readonly string _planeTooLongModel = new string('a', 51);
        private readonly string _planeEmplyModel = "";

        public UpdateModel()
        {
            
        }

        [Fact]
        public void PassesWithCorrectModel()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            plane.UpdateModel(_planeCorrectModel);
            //Assert
            Assert.Equal(plane.Model, _planeCorrectModel);
        }
        
        [Fact]
        public void CantSetEmptyModel()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            Action act = () => plane.UpdateModel(_planeEmplyModel);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("model", exception.ParamName);
        }
        
        [Fact]
        public void CantSetTooLongModel()
        {
            //Arrange
            Plane plane = new Plane();
            //Act
            Action act = () => plane.UpdateModel(_planeTooLongModel);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("model", exception.ParamName);
        }
    }
}