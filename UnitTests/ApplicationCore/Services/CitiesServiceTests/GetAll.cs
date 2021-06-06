using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Services;
using Moq;
using Xunit;

namespace UnitTests.ApplicationCore.Services.CitiesServiceTests
{
    public class GetAll
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IAsyncRepository<int, City>> _mockCityRepo;
        private readonly Mock<IMapper<City, CityDTO>> _mapper;
        
        public GetAll()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mockCityRepo = new Mock<IAsyncRepository<int, City>>();
            _mapper = new Mock<IMapper<City, CityDTO>>();
        }

        [Fact]
        public void InvokesCityRepositoryListAllAsyncOnce()
        {
            //Arrange
            _mockCityRepo.Setup(x => x.ListAllAsync()).ReturnsAsync(GetCitiesList);
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);

            var cityService = new CitiesService(_mockUow.Object, _mapper.Object);
            //Act
            cityService.GetAll();
            //Assert
            _mockCityRepo.Verify(x => x.ListAllAsync(), Times.Once);
        }
        
        [Fact]
        public void InvokesMapperWithRightParamsOnce()
        {
            //Arrange
            IEnumerable<City> cities = GetCitiesList();
            List<City> citiesList = cities.ToList();
            _mockCityRepo.Setup(x => x.ListAllAsync()).ReturnsAsync(GetCitiesList);
            _mockUow.Setup(x => x.GetRepository<IAsyncRepository<int, City>>()).Returns(_mockCityRepo.Object);
            _mapper.Setup(x => x.Map(cities));

            var cityService = new CitiesService(_mockUow.Object, _mapper.Object);
            //Act
            cityService.GetAll();
            //Assert
            _mapper.Verify(x => x.Map(It.Is<List<City>>(x => 
                    x.Any(y => y.Id == citiesList[0].Id || y.Id == citiesList[1].Id || y.Id == citiesList[2].Id)
            )), Times.Once);
        }

        private IReadOnlyList<City> GetCitiesList()
        {
            var city1 = new Mock<City>("City1");
            city1.SetupGet(p => p.Id).Returns(1);
            var city2 = new Mock<City>("City2");
            city2.SetupGet(p => p.Id).Returns(2);
            var city3 = new Mock<City>("City3");
            city3.SetupGet(p => p.Id).Returns(3);
            
            List<City> cities = new List<City>()
            {
                city1.Object,
                city2.Object,
                city3.Object
            };

            return cities;
        }
    }
}