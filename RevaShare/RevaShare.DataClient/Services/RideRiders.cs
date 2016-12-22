using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
    public partial class RevaShareDataService
    {
        public List<RideRidersDAO> GetRideRiders()
        {
            var r = new List<RideRidersDAO>();

            foreach (var rider in data.GetRideRiders())
            {
                r.Add(RideRiderMapper.MapToRideRiderDAO(rider));
            }
            return r;
        }

        public bool AddRideRiders(UserDAO user, RideDAO ride)
        {
            return data.AddRideRider(UserMapper.MapToUser(user), RideMapper.MapToRide(ride));          
        }

        public bool AcceptRideRequest(RideRidersDAO riderider)
        {
            return data.AcceptRider(RideRiderMapper.MapToRideRider(riderider));
        }

        public bool UpdateRideRider(RideRidersDAO riderider)
        {
            return data.UpdateRideRider(RideRiderMapper.MapToRideRider(riderider));
        }

        public bool DeleteRideRider(RideRidersDAO rider)
        {
            return data.DeleteRideRider(RideRiderMapper.MapToRideRider(rider));
        }
    }
}