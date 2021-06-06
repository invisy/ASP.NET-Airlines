using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Services;
using Moq;
using Xunit;

namespace UnitTests.ApplicationCore.Services.CitiesServiceTests
{
    public class CreateCity
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IAsyncRepository<int, City>> _mockCityRepo;
        private readonly Mock<IMapper<City, CityDTO>> _mapper;
        private readonly string _cityName = "CityName";

        public CreateCity()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mockCityRepo = new Mock<IAsyncRepository<int, City>>();
            _mapper = new Mock<IMapper<City, CityDTO>>();
        }

        [Fact]
        public async Task InvokesCityRepositoryAddAsyncOnce()
        {
            //Arrange
            _mockCityRepo.Setup(x => x.AddAsync(It.IsAny<City>()));
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);

            var cityService = new CitiesService(_mockUow.Object, null);
            var cityDto = new CityDTO() { Name = _cityName};
            //Act
            await cityService.Create(cityDto);
            //Assert
            _mockCityRepo.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Once);
        }
        
        [Fact]
        public async Task InvokesUowSaveChangesOnce()
        {
            //Arrange
            _mockCityRepo.Setup(x => x.AddAsync(It.IsAny<City>()));
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);
            _mockUow.Setup(x => x.SaveChanges());

            var cityService = new CitiesService(_mockUow.Object, null);
            var cityDto = new CityDTO() { Name = _cityName};
            //Act
            await cityService.Create(cityDto);
            //Assert
            _mockUow.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}