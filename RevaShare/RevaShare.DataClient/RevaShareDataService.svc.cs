﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RevaShare.DataClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RevaShareDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RevaShareDataService.svc or RevaShareDataService.svc.cs at the Solution Explorer and start debugging.
    public class RevaShareDataService : IRevaShareDataService
    {

        public RideDAO passRide()
        {
            return new RideDAO();
        }

        public RideRidersDAO passRideRider()
        {
            return new RideRidersDAO();
        }

        public UserDAO passUser()
        {
            return new UserDAO();
        }

        private static UserStore<IdentityUser> credentials = new UserStore<IdentityUser>();

        public bool Signup(IdentityDAO account)
        {
            var user = new IdentityUser { UserName = account.Username };
            var manager = new UserManager<IdentityUser>(credentials);
            var result = manager.Create(user, account.Password);
            if (result.Succeeded)
            {
                //Roles.AddUserToRole(account.Username, "admin");
                return true;
            }
            return false;
        }

    }
}
