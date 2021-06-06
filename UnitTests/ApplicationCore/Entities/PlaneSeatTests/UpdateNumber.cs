using System;
using Airlines.ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.PlaneSeatTests
{
    public class UpdateNumber
    {
        private readonly string _planeCorrectNumber = new string('a', 5);
        private readonly string _planeTooLongNumber = new string('a', 11);
        private readonly string _planeEmplyNumber = "";

        public UpdateNumber()
        {
            
        }

        [Fact]
        public void PassesWithCorrectNumber()
        {
            //Arrange
            PlaneSeat planeSeat = new PlaneSeat();
            //Act
            planeSeat.UpdateNumber(_planeCorrectNumber);
            //Assert
            Assert.Equal(planeSeat.Number, _planeCorrectNumber);
        }
        
        [Fact]
        public void CantSetEmptyNumber()
        {
            //Arrange
            PlaneSeat planeSeat = new PlaneSeat();
            //Act
            Action act = () => planeSeat.UpdateNumber(_planeEmplyNumber);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("number", exception.ParamName);
        }
        
        [Fact]
        public void CantSetTooLongNumber()
        {
            //Arrange
            PlaneSeat planeSeat = new PlaneSeat();
            //Act
            Action act = () => planeSeat.UpdateNumber(_planeTooLongNumber);
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("number", exception.ParamName);
        }
    }
}