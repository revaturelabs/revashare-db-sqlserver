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
      public void Login_Test_positive()
      {
         var actual = svc.Login("jimbob", "jimbob");
         Assert.NotNull(actual);

         
      }
      [Fact]
      public void Login_Test_negative()
      {
         var actual = svc.Login("Ryan", "ASD123");
         Assert.Null(actual);
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
         var rider = svc.GetUserByUsername("kimbob");
         var driver = svc.GetUserByUsername("jimbob");
         flag.Driver = driver;
         flag.Rider = rider;
         flag.Message = "test message";
         flag.Type = "unknown";
         var actual = svc.CreateFlag(flag);
         Assert.True(actual);
      }

      [Fact]
      public void UpdateFlag_Test()
      {
         var flag = svc.GetAllFlags().FirstOrDefault();
         flag.Type = "this is the new type";
         var actual = svc.UpdateFlag(flag);
         Assert.True(actual);
      }

      [Fact]
      public void MarkFlagAsRead_Test()
      {
         var flag = svc.GetAllFlags().FirstOrDefault();
         var actual = svc.MarkFlagAsRead(flag);
         Assert.True(actual);
      }

      #endregion

      [Fact]
      public void UpgradeToRider_TEST()
      {
         var actual = svc.ApproveRider("kimbob");
         Assert.True(actual);
      }

      [Fact]
      public void UpgradeToDriver_TEST()
      {
         var actual = svc.ApproveDriver("kimbob");
         Assert.True(actual);
      }

      #region Vehicle tests

      [Fact]
      public void AddVehicle_Test()
      {
         var owner = svc.GetAllUsers().FirstOrDefault();
         var vehicle = new VehicleDAO() { Capacity=4, Color="orange", LicensePlate="qwe-ewq", Make="test make2", Model="test model2", Owner=owner};
         var actual = svc.AddVehicle(vehicle);
         Assert.True(actual);
      }

      [Fact]
      public void GetVehicles_Test()
      {
         var actual = svc.GetVehicles();
         Assert.NotEmpty(actual);
      }

      [Fact]
      public void UpdateVehicle_Test()
      {
         var car = svc.GetVehicles().Where(m => m.Color.Equals("orange")).FirstOrDefault();
         car.Color = "yellow";
         var actual = svc.UpdateVehicle(car);
         Assert.True(actual);
      }

      [Fact]
      public void DeleteVehicle_Test()
      {
         var car = svc.GetVehicles().Where(m => m.Color.Equals("yellow")).FirstOrDefault();

         var actual = svc.DeleteVehicle(car);
         Assert.True(actual);
      }

      #endregion

      [Fact]
      public void GetRidesByLocationAM_Test()
      {
         var actual = svc.ListRidesAtApartmentAM("abc");
         Assert.NotNull(actual);
      }

      [Fact]
      public void GetRidesByLocationPM_Test()
      {
         var actual = svc.ListRidesAtApartmentPM("abc");
         Assert.Empty(actual);
      }

      [Fact]
      public void availableSeats_TEST()
      {
         var ride = svc.ListRidesAtApartment("abc").FirstOrDefault();
         var actual = svc.GetOpenSeats(ride);
         Assert.InRange<int>(actual,0,ride.Vehicle.Capacity-1);
      }

      [Fact]
      public void GetRiders_Tests()
      {
         var ride = svc.ListRidesAtApartment("abc").FirstOrDefault();
         var actual = svc.getRidersInRide(ride);
         Assert.NotNull(actual);
      }
   }
}
