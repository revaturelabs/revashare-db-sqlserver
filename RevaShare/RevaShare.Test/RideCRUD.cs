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
    public class RideCRUD
    {
        /*
            Need to use Jason's methods for getting first vehicle for creating ride.

        */

        [Fact]
        public void AddRideRemoveRide_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();

            TimeSpan testTime = new TimeSpan(8, 30, 00);
            DateTime testStartDate = new DateTime(2016, 12, 22);
            UserDAO testUser = svc.GetUserByUsername("jimbob");
            VehicleDAO testVehicle = new VehicleDAO { Owner = testUser, Capacity = 4, Color = "purple", LicensePlate = "zxc-vbn", Make = "test make", Model = "test model" };

            RideDAO testRide = new RideDAO { DepartureTime = testTime, IsAmRide = true, StartOfWeek =  testStartDate, Vehicle = testVehicle };

            bool actual = svc.AddRide(testRide);

            Assert.True(actual);
        }

        [Fact]
        public void RemoveRide_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();

            TimeSpan testTime = new TimeSpan(8, 30, 00);
            DateTime testStartDate = new DateTime(2016, 12, 22);
            UserDAO testUser = svc.GetUserByUsername("jimbob");
            VehicleDAO testVehicle = new VehicleDAO { Owner = testUser, Capacity = 4, Color = "white", LicensePlate = "zxc-vbn", Make = "test make", Model = "test model" };

            RideDAO testRide = new RideDAO { DepartureTime = testTime, IsAmRide = true, StartOfWeek = testStartDate, Vehicle = testVehicle };

            bool actual = svc.DeleteRide(testRide);

            Assert.True(actual);
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
    }
}
