using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
    public partial class RevaShareData {
        private DummyEf context;

        public RevaShareData() {
            context = new DummyEf();
        }

        public class Apartment {
            public int Id { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string Name { get; set; }
        }

        public class AspNetUser {
            public string Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public int ApartmentId { get; set; }
            public Apartment Apartment { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        public class Ride {
            public int Id { get; set; }
            public int VehicleId { get; set; }
            public Vehicle Vehicle { get; set; }
            public DateTime StartOfWeekData { get; set; }
            public DateTime DepartureTime { get; set; }
            public bool IsOnTime { get; set; }
            public bool Active { get; set; }
        }

        public class Vehicle {
            public int Id { get; set; }
            public string OwnerId { get; set; }
            public AspNetUser AspNetUser { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string LicensePlate { get; set; }
            public string Color { get; set; }
            public int Capacity { get; set; }
        }

        public class RideRider {
            public int Id { get; set; }
            public int RideId { get; set; }
            public Ride Ride { get; set; }
            public string RiderId { get; set; }
            public bool Accepted { get; set; }
        }

        public class Flag {
            public int Id { get; set; }
            public string DriverId { get; set; }
            public string RiderId { get; set; }
            public string Type { get; set; }
            public string Message { get; set; }
        }

        public class DummyEf {
            public List<Ride> Rides { get; set; }
            public List<AspNetUser> AspNetUsers { get; set; }
            public List<Vehicle> Vehicles { get; set; }
            public List<Apartment> Apartments { get; set; }
            public List<RideRider> RideRiders { get; set; }
            public List<Flag> Flags { get; set; }
        }
    }
}
