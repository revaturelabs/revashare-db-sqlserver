using Moq;
using RevaShare.DataAccess;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevaShare.Test
{
  public class Mock_Tests
  {
    [Fact]
    public void Apartment_Test1()
    {
      var mockSet = new Mock<DbSet<Apartment>>();

      var mockContext = new Mock<RevaShareDBEntities>();
      mockContext.Setup(m => m.Apartments).Returns(mockSet.Object);

      var service = new RevaShareDataService(mockContext.Object);
      var apartment = new ApartmentDAO { Name="Test", Latitude = "34.5", Longitude = "170.1" };
      service.AddApartment(apartment);

      mockSet.Verify(m => m.Add(It.IsAny<Apartment>()), Times.Never());
      mockContext.Verify(m => m.SaveChanges(), Times.Never());
    }

    [Fact]
    public void Apartment_Test2()
    {
      var mockSet = new Mock<DbSet<Apartment>>();

      var mockContext = new Mock<RevaShareDBEntities>();
      mockContext.Setup(m => m.Apartments).Returns(mockSet.Object);

      var service = new RevaShareDataService(mockContext.Object);
      var apartment = new Apartment { Name = "Test", Latitude = "34.5", Longitude = "170.1" };
      service.AddApartment(ApartmentMapper.MapToApartmentDAO( apartment));

      mockSet.Verify(m => m.Add(It.IsAny<Apartment>()), Times.Never());
      mockContext.Verify(m => m.SaveChanges(), Times.Never());
    }

    [Fact]
    public void GetAllApartments_by_name()
    {
      var data = new List<Apartment>
            {
                new Apartment { Name = "BBB" },
                new Apartment { Name = "ZZZ" },
                new Apartment { Name = "AAA" },
            }.AsQueryable();

      var mockSet = new Mock<DbSet<Apartment>>();
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.Provider).Returns(data.Provider);
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.Expression).Returns(data.Expression);
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.ElementType).Returns(data.ElementType);
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockContext = new Mock<RevaShareDBEntities>();
      mockContext.Setup(c => c.Apartments).Returns(mockSet.Object);

      var service = new RevaShareDataService(mockContext.Object);
      var blogs = service.ListApartments();

      Assert.Equal(4, blogs.Count);
      Assert.Equal("Test", blogs[0].Name);
      Assert.Equal("Test", blogs[1].Name);
      Assert.Equal("Test", blogs[2].Name);
      Assert.Equal("Test", blogs[3].Name);
    }

    [Fact]
    public void Ride_Test1()
    {
      var mockSet = new Mock<DbSet<Ride>>();

      var mockContext = new Mock<RevaShareDBEntities>();
      mockContext.Setup(m => m.Rides).Returns(mockSet.Object);

      var service = new RevaShareDataService(mockContext.Object);
      var apartment = new RideDAO { Vehicle = new VehicleDAO { Owner = new UserDAO { Name = "Ryan5", Email = "test", PhoneNumber = "fake number" }, Make = "Ford", Model = "Pinto", Color = "Orange", LicensePlate = "123-abc", Capacity = 2 }, IsOnTime = true, StartOfWeek = DateTime.Parse("12/12/2016"), DepartureTime = TimeSpan.Parse("09:00")};
      service.AddRide(apartment);

      mockSet.Verify(m => m.Add(It.IsAny<Ride>()), Times.Never());
      mockContext.Verify(m => m.SaveChanges(), Times.Never());
    }
  }
}
