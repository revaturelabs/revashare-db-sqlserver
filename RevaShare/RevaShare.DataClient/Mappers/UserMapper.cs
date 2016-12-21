using Microsoft.AspNet.Identity.EntityFramework;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
   public class UserMapper
   {
      public static UserDAO MapToUserDAO(IdentityUser user, UserInfo info)
      {
         var u = new UserDAO()
         {
            UserName = user.UserName,
            Apartment = ApartmentMapper.MapToApartmentDAO(info.Apartment),
            Email = user.Email,
            Name = info.Name,
            PhoneNumber = info.Phone
         };
         List<RoleDAO> roles = new List<RoleDAO>();
         foreach (string role in RevaShareIdentity.Instance.Manager.GetRolesAsync(user.Id).Result)
         {
            roles.Add(new RoleDAO()
            {
               Type = role
            });
         }
         u.Roles = roles;
         return u;
      }

      public static UserInfo MapToUser(UserDAO user)
      {
            RevaShareData data = new RevaShareData();

            var u = new UserInfo();
            u.Phone = user.PhoneNumber;
            u.Email = user.Email;
            u.Name = user.Name;
            u.UserID = data.GetUser(user.UserName).UserID;

            u.Apartment = ApartmentMapper.MapToApartment(user.Apartment);

         return u;
      }
   }
}