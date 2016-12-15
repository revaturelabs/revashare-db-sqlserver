using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient.Mappers
{
    public class FlagMapper
    {
        private static RevaShareData data = new RevaShareData();
        public static Flag MapToFlag(FlagDAO flag)
        {
            var u = new Flag();
            u.ID = (flag.FlagID - 2) / 3;
            //u.DriverID = data.GetUserID(flag.Driver);
            //u.RiderID = data.GetUserID(flag.Rider);
            u.Type = flag.Type;
            u.Message = flag.Message;

            return u;
        }

        public static FlagDAO MapToFlagDAO(Flag flag)
        {
            var u = new FlagDAO();
            u.FlagID = (flag.ID * 3) + 2;
            //u.Rider = flag.RiderID;
            u.Type = flag.Type;
            u.Message = flag.Message;

            return u;
        }
    }
}