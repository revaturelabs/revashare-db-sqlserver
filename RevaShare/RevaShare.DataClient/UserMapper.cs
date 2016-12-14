using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
  public class UserMapper
  {
    public static UserDAO MapToUserDAO(AspNetUser user)
    {
      var u = new UserDAO();
      u.UserID = user.Id;
      u.Email = user.Email;
      u.Name = user.Name;
     
      u.PhoneNumber = user.PhoneNumber;
      
      u.Apartment = ApartmentMapper.MapToApartmentDAO(user.Apartment);
     

      return u;
    }

    public static AspNetUser MapToUser(UserDAO user)
    {
      var u = new AspNetUser();
      u.Id = user.UserID;
      u.Email = user.Email;
      u.Name = user.Name;
     
      u.Apartment = ApartmentMapper.MapToApartment(user.Apartment);

      return u;
    }


    // this is an example of "Reflection"
    public static object MapTo(object o)
    {
      var properties = o.GetType().GetProperties();
      var ob = new object();

      foreach (var item in properties.ToList())
      {
        ob.GetType().GetProperty(item.Name).SetValue(ob, item.GetValue(item));
      }
      return ob;
    }
  }
}