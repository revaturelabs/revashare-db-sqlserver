using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace RevaShare.DataClient
{
   public class RideRiderMapper
   {

      public static RideRidersDAO MapToRideRiderDAO(RideRider riderider)
      {
         RevaShareData data = new RevaShareData();
         //RevaShareDataService svc = new RevaShareDataService();
         var u = new RideRidersDAO();
         u.Ride = RideMapper.MapToRideDAO(riderider.Ride);
         u.Rider = UserMapper.MapToUserDAO(RevaShareIdentity.Instance.Manager.FindById(riderider.RiderID), data.ListUserInfoes().Where(m => m.UserID.Equals(riderider.RiderID)).FirstOrDefault());
         u.Accepted = riderider.Accepted;
         return u;
      }

      public static RideRider MapToRideRider(RideRidersDAO riderider)
      {
         var u = new RideRider();
         u.Ride = RideMapper.MapToRide(riderider.Ride);
         u.RideID = u.Ride.ID;
         u.RiderID = UserMapper.MapToUser(riderider.Rider).UserID;
         u.Accepted = riderider.Accepted;
         u.Active = true;
         return u;
      }
   }
}