using Microsoft.AspNet.Identity.EntityFramework;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient {
    public class UserMapper {
        public static UserDAO MapToUserDAO(IdentityUser user, UserInfo info) {
            var u = new UserDAO() {
                UserName = user.UserName,
                Apartment = ApartmentMapper.MapToApartmentDAO(info.Apartment),
                Email = user.Email,
                Name = info.Name,
                PhoneNumber = info.Phone
            };

            List<RoleDAO> roles = new List<RoleDAO>();

            foreach (string role in RevaShareIdentity.Instance.Manager.GetRolesAsync(user.Id).Result) {
                roles.Add(new RoleDAO() {
                    Type = role
                });
            }

            u.Roles = roles;

            return u;
        }

        //public static AspNetUser MapToUser(UserDAO user)
        //{
        //  var u = new AspNetUser();
        //  u.Id = user.UserID;
        //  u.Email = user.Email;
        //  u.Name = user.Name;

        //  u.Apartment = ApartmentMapper.MapToApartment(user.Apartment);

        //  return u;
        //}


        // this is an example of "Reflection"
        public static object MapTo(object o) {
            var properties = o.GetType().GetProperties();
            var ob = new object();

            foreach (var item in properties.ToList()) {
                ob.GetType().GetProperty(item.Name).SetValue(ob, item.GetValue(item));
            }
            return ob;
        }
    }
}