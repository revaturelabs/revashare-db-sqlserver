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

      mockSet.Verify(m => m.Add(It.IsAny<Apartment>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void Apartment_Test2()
    {
      var mockSet = new Mock<DbSet<Apartment>>();

      var mockContext = new Mock<RevaShareDBEntities>();
      mockContext.Setup(m => m.Apartments).Returns(mockSet.Object);

      var service = new RevaShareDataService(mockContext.Object);
      var apartment = new Apartment { Name = "Test", ID = 1, Latitude = "34.5", Longitude = "170.1" };
      service.AddApartment(ApartmentMapper.MapToApartmentDAO( apartment));

      mockSet.Verify(m => m.Add(It.IsAny<Apartment>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
  }
}
