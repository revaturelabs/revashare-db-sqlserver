using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
    public partial class RevaShareData {

        public bool CreateRide(Ride ride) {
            ride.Active = true;
            context.Rides.Add(ride);
            return context.SaveChanges() > 0;
        }

        public Ride GetRide(string userId, DateTime startOfWeek, bool isAm) {
            return context.Rides.FirstOrDefault(r => r.Vehicle.OwnerID == userId && r.StartOfWeekDate == startOfWeek && r.Active && r.IsAmRide==isAm);
        }

        public List<Ride> ListAllRides()
        {
            return context.Rides.Where(r => r.Active == true).ToList();
        }

        public List<Ride> ListRidesAtApartment(string name) {
            return context.Rides.Where(r => r.Vehicle.UserInfo.Apartment.Name == name && r.Active).ToList();
        }

        public bool UpdateRide(Ride ride) {
            var result = context.Rides.SingleOrDefault(x => x.ID == ride.ID);

            if (result != null) {
                if (ride.ID != 0)
                    result.ID = ride.ID;

                if (ride.VehicleID != 0)
                    result.VehicleID = ride.VehicleID;

                if (ride.StartOfWeekDate != null)
                    result.StartOfWeekDate = ride.StartOfWeekDate;

                if (ride.DepartureTime != null)
                    result.DepartureTime = ride.DepartureTime;

                result.IsOnTime = ride.IsOnTime;

                result.Active = ride.Active;
            }

            context.SaveChanges();
            return true;
        }

        public bool DeleteRide(Ride ride) {
            ride.Active = false;
            return context.SaveChanges() > 0;
        }
    }
}
