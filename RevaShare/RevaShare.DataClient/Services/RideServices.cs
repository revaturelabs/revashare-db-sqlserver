using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient {
    public partial class RevaShareDataService {
        public bool AddRide(RideDAO ride) {
            return data.CreateRide(RideMapper.MapToRide(ride));
        }

        public bool UpdateRide(RideDAO ride) {
            return data.UpdateRide(RideMapper.MapToRide(ride));
        }

        public bool DeleteRide(RideDAO ride) {
            return data.DeleteRide(RideMapper.MapToRide(ride));
        }

        public int GetOpenSeats(string username, DateTime startOfWeekDate) {
            string userId = data.GetUserId(username);
            Ride ride = data.GetRide(userId, startOfWeekDate);
            return ride.Vehicle.Capacity - ride.RideRiders.ToList().Count - 1;
        }
    }
}