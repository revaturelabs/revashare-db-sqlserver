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
            u.ID = (flag.FlagID - 2) / 3;
            u.DriverID = flag.DriverID;
            u.RiderID = flag.RiderID;
            u.Type = flag.Type;
            u.Message = flag.Message;

            return u;
        }

        public static FlagDAO MapToFlagDAO(Flag flag)
        {
            var u = new FlagDAO();
            u.FlagID = (flag.ID * 3) + 2;
            u.DriverID = flag.DriverID;
            u.RiderID = flag.RiderID;
            u.Type = flag.Type;
            u.Message = flag.Message;

            return u;
        }
    }
}