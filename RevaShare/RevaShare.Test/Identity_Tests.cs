using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevaShare.Test
{
   public class Identity_Tests
   {
      //IdentityControlls control = new IdentityControlls();
      RevaShareData Data = new RevaShareData();
      private RevaShareDataService svc = new RevaShareDataService();

      [Fact]
      public void Signup_Test_using_data()
      {
         var expected = true;
         var apt = new Apartment() { Latitude = "1.1", Longitude = "2.2", Name = "abc" };
         var actual = Data.CreateUser(new UserInfo { Email = "a@b.c", Name = "jane bob", Phone = "9876543210", Apartment=apt }, "janebob", "janebob");

         Assert.Equal(expected, actual);
      }

      [Fact]
      public void Signup_Test_using_service()
      {
         var expected = true;
         var apt = new ApartmentDAO() { Latitude = "1.1", Longitude = "2.2", Name = "abc" };
         
         var actual = svc.RegisterUser(new UserDAO { Email = "a@b.c", Name = "john bob", PhoneNumber= "9876543210", Apartment = apt, UserName="johnbob" }, "johnbob", "jimbob");

         Assert.Equal(expected, actual);
      }


      [Fact]
      public void Login_Test()
      {
         var expected = true;
         var actual = Data.TryLogin("Ryan", "ASDasd123");
         Assert.Equal(expected, actual);

         var expected2 = false;
         var actual2 = Data.TryLogin("Ryan", "ASD123");

         Assert.Equal(expected2, actual2);
      }
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
      public void DeleteApartment_Test()
      {
         var apt = new ApartmentDAO { Name = "Townes", Latitude = "3.1", Longitude = "3.2" };         
         var actual = svc.DeleteApartment(apt.Name);
         Assert.True(actual);
      }

      #endregion

      #region Flag Tests
      [Fact]
      public void CreateFlag_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();
         var flag = new FlagDAO();
         var rider = new UserDAO() {UserName="johnbob" };
         var driver = new UserDAO() {UserName="jimbob" };
         flag.Driver = rider;
         flag.Rider = driver;
         flag.Message = "you suck #2";
         flag.Type = "unknown";
         var actual = svc.CreateFlag(flag);
         Assert.True(actual);
      }


      #endregion

      [Fact]
      public void UpgradeToRider_TEST()
      {
         var actual = svc.ApproveUser("kimbob");
         Assert.True(actual);
      }

      [Fact]
      public void UpgradeToDriver_TEST()
      {
         var actual = svc.ApproveDriver("kimbob");
         Assert.True(actual);
      }
   }
}
