using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
  public class ApartmentMapper
  {
    public static ApartmentDAO MapToApartmentDAO(Apartment apartment)
    {
      var c = new ApartmentDAO();
      c.ApartmentID = apartment.ID;
      c.Latitude = apartment.Latitude;
      c.Longitude = apartment.Longitude;
     
      return c;
    }

    public static Apartment MapToApartment(ApartmentDAO apartment)
    {
      var c = new Apartment();
      c.ID = apartment.ApartmentID;
      c.Latitude = apartment.Latitude;
      c.Longitude = apartment.Longitude;

      return c;
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