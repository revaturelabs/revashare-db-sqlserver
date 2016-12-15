using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
  public class FlagMapper
  {
    public static FlagDAO MapToFlagDAO(Flag flag)
    {
      var c = new FlagDAO();
      c.FlagID = flag.ID;
      c.DriverID = flag.DriverID;
      c.RiderID = flag.RiderID;
      c.Type = flag.Type;
      c.Message = flag.Message;      

      return c;
    }

    public static Flag MapToFlag(FlagDAO flag)
    {
      var c = new Flag();
      c.ID = flag.FlagID;
      c.DriverID = flag.DriverID;
      c.RiderID = flag.RiderID;
      c.Type = flag.Type;
      c.Message = flag.Message;

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