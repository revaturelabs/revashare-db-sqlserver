using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient.Mappers
{
    public class FlagMapper
    {
        public static Flag MapToFlag(FlagDAO flag)
        {
            var u = new Flag();
            u.ID = flag.FlagID;
            u.DriverID = flag.DriverID;
            u.RiderID = flag.RiderID;
            u.Type = flag.Type;
            u.Message = flag.Message;

            return u;
        }

        public static FlagDAO MapToFlagDAO(Flag flag)
        {
            var u = new FlagDAO();
            u.FlagID = flag.ID;
            u.DriverID = flag.DriverID;
            u.RiderID = flag.RiderID;
            u.Type = flag.Type;
            u.Message = flag.Message;

            return u;
        }
    }
}