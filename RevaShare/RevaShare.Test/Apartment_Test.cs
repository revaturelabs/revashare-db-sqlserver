using RevaShare.DataClient.Models;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevaShare.Test
{
   class Apartment_Test
   {
      RevaShareData Data = new RevaShareData();
      private RevaShareDataService svc = new RevaShareDataService();

      #region ApartmentService Tests

      [Fact]
      public void CreateApartment_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();
         var expected = true;
         var actual = svc.AddApartment(new ApartmentDAO { Name = "Townes", Latitude = "31", Longitude = "32" });

         Assert.Equal(expected, actual);
      }

      [Fact]
      public void UpdateApartment_Test()
      {
         var apt = new ApartmentDAO { Name = "Townes", Latitude = "31", Longitude = "32" };
         apt.Latitude = "3.1";
         apt.Longitude = "3.2";
         var actual = svc.UpdateApartment(apt);
         Assert.True(actual);
      }

      [Fact]
      public void GetApartment_Test()
      {
         var actual = svc.ListApartments();
         Assert.NotEmpty(actual);
      }
      [Fact]
      public void GetApartmentByName_Test()
      {
         var apt = svc.ListApartments().FirstOrDefault();
         var actual = svc.GetApartmentByName(apt.Name);
         Assert.NotNull(actual);
      }

      [Fact]
      public void DeleteApartment_Test()
      {
         var apt = new ApartmentDAO { Name = "Townes", Latitude = "3.1", Longitude = "3.2" };
         var actual = svc.DeleteApartment(apt.Name);
         Assert.True(actual);
      }

      #endregion

   }
}
