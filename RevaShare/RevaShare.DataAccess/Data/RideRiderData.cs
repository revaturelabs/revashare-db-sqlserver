﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
namespace RevaShare.DataAccess.Data
{
    public partial class RevaShareData
    {
        private static UserStore<IdentityUser> credentials = new UserStore<IdentityUser>(new Q());

        public List<RideRider> GetRideRiders()
        {
            return context.RideRiders.Where(m => m.Active).ToList();
        }

        public bool AddRideRider(UserInfo user, Ride ride)
        {
            //Check if RideRider entry already exists
            var matchingRideRiders = context.RideRiders.Where(rr => rr.UserInfo.UserID == user.UserID && ride.ID == rr.RideID && rr.Active == false);

            if (matchingRideRiders.Count() > 0)
            {
                RideRider rrToUpdate = matchingRideRiders.First();

                //If the RideRider exists, send the updated info and set active to true
                rrToUpdate.RideID = ride.ID;
                rrToUpdate.RiderID = ListUserInfoes().Where(m => m.UserID.Equals(user.UserID)).FirstOrDefault().UserID;
                rrToUpdate.Accepted = false;
                rrToUpdate.Active = true;

                return UpdateRideRider(rrToUpdate);
            }

            else
            {
                //If RideRider entry doesn't already exist, add new entry
                var riderider = new RideRider();
                riderider.Active = true;
                riderider.RideID = ride.ID;
                riderider.RiderID = ListUserInfoes().Where(m => m.UserID.Equals(user.UserID)).FirstOrDefault().UserID;
                context.RideRiders.Add(riderider);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateRideRider(RideRider riderider)
        {
            var result = context.RideRiders.SingleOrDefault(x => (x.RiderID.Equals(riderider.RiderID) && x.RideID.Equals(riderider.RideID)));

            if (result != null)
            {
                if (riderider.RideID != 0)
                    result.RideID = riderider.RideID;

                if (riderider.RiderID != null)
                    result.RiderID = riderider.RiderID;

                result.Accepted = riderider.Accepted;

                result.Active = riderider.Active;
            }
            return context.SaveChanges() > 0;
        }

        public bool AcceptRider(RideRider riderider)
        {
            riderider.Accepted = true;
            return UpdateRideRider(riderider);
        }

        public bool DeleteRideRider(RideRider riderider)
        {
            riderider.Active = false;
            return UpdateRideRider(riderider);
        }

        public RideRider GetRideRiderByID(string id)
        {
            var result = context.RideRiders.Where(a => a.RiderID == id && a.Active).FirstOrDefault();
            return result;
        }

        public RideRider GetRideRiderByName(string name)
        {
            return context.RideRiders.FirstOrDefault(a => a.UserInfo.Name == name && a.Active);
        }
    }
}
