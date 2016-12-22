using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using Xunit;
using System.Diagnostics;

namespace RevaShare.Test
{
   class Ride_Tests
   {
      RevaShareData Data = new RevaShareData();
      private RevaShareDataService svc = new RevaShareDataService();

      #region Ride Tests

      [Fact]
      public void AddRideDeleteRide_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();

         TimeSpan testTime = new TimeSpan(8, 30, 00);
         DateTime testStartDate = new DateTime(2016, 11, 22);
         VehicleDAO testVehicle = svc.GetVehicles().ToList().Where(v => v.Owner.UserName == "jimbob").First();
         UserDAO testUser = svc.GetUserByUsername(testVehicle.Owner.UserName);

         RideDAO rideToAdd = new RideDAO { DepartureTime = testTime, IsAmRide = true, StartOfWeek = testStartDate, Vehicle = testVehicle };
         bool resultAddRide = svc.AddRide(rideToAdd);

         RideDAO rideToRemove = svc.GetAllRides().Where(r => r.Vehicle.Owner.UserName == testUser.UserName && r.StartOfWeek == testStartDate).First();
         bool resultDeleteRide = svc.DeleteRide(rideToRemove);

         Assert.True(resultAddRide);
      }

      [Fact]
      public void GetAllRides_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();
         var actual = svc.GetAllRides();

         foreach (RideDAO ride in actual)
         {
            Debug.WriteLine("Driver: " + ride.Vehicle.Owner.Name + ", Car Model: " + ride.Vehicle.Model + ", Departure Time: " + ride.DepartureTime);
         }

         Assert.NotNull(actual);
      }

      [Fact]
      public void ListRidesAtApartment_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();
         ApartmentDAO existingApt = svc.ListApartments().First();

         var actual = svc.ListRidesAtApartment(existingApt.Name);

         foreach (RideDAO ride in actual)
         {
            Debug.WriteLine("Driver: " + ride.Vehicle.Owner.Name + ", Car Model: " + ride.Vehicle.Model + ", Departure Time: " + ride.DepartureTime);
         }

         Assert.NotNull(actual);
      }

      [Fact]
      public void UpdateRide_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();

         DateTime testStartDate = new DateTime(2017, 1, 14);
         VehicleDAO testVehicle = svc.GetVehicles().ToList().Where(v => v.Owner.UserName == "jimbob").First();
         UserDAO testUser = svc.GetUserByUsername(testVehicle.Owner.UserName);

         List<RideDAO> ridesToUpdate = svc.GetAllRides();

         RideDAO rideToUpdate = svc.GetAllRides().Where(r => r.Vehicle.Owner.UserName == testUser.UserName && r.StartOfWeek == testStartDate).First();

         rideToUpdate.DepartureTime = new TimeSpan(7, 45, 00);

         bool actual = svc.UpdateRide(rideToUpdate);

         Assert.True(actual);
      }

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
         Assert.InRange<int>(actual, 0, ride.Vehicle.Capacity - 1);
      }

      #endregion

   }
}
