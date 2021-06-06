using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Exceptions;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Services;
using Moq;
using Xunit;

namespace UnitTests.ApplicationCore.Services.CitiesServiceTests
{
    public class Update
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IAsyncRepository<int, City>> _mockCityRepo;
        private readonly Mock<IMapper<City, CityDTO>> _mapper;
        
        public Update()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mockCityRepo = new Mock<IAsyncRepository<int, City>>();
            _mapper = new Mock<IMapper<City, CityDTO>>();
        }

        [Fact]
        public void InvokesCityRepositoryGetByIdAsyncOnce()
        {
            City city = new City("City1");
            //Arrange
            _mockCityRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(city);
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);

            var cityService = new CitiesService(_mockUow.Object, _mapper.Object);
            //Act
            cityService.GetById(1);
            //Assert
            _mockCityRepo.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
        
        [Fact]
        public void InvokesCityRepositoryUpdateAsyncOnce()
        {
            City city = new City("City1");
            CityDTO dto = new CityDTO() { Name = "City" } ;
            //Arrange
            _mockCityRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(city);
            _mockCityRepo.Setup(x => x.UpdateAsync(It.IsAny<City>()));
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);

            var cityService = new CitiesService(_mockUow.Object, _mapper.Object);
            //Act
            cityService.Update(dto);
            //Assert
            _mockCityRepo.Verify(x => x.UpdateAsync(It.IsAny<City>()), Times.Once);
        }

        [Fact]
        public void ThrowsExceptionIfNotFound()
        {
            //Arrange
            
            _mockCityRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((City)null);
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);

            var cityService = new CitiesService(_mockUow.Object, _mapper.Object);
            //Act
            Func<Task> act = async () => await cityService.Update(new CityDTO());
            //Assert
            Task<EntityNotFoundException> exception =  Assert.ThrowsAsync<EntityNotFoundException>(act);
            Assert.Equal(nameof(City), exception.Result.Message);
        }
    }
}