using RevaShare.DataClient.Mappers;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
    public partial class RevaShareDataService
    { 
        public bool CreateFlag(FlagDAO flag)
        {
            return data.Create(FlagMapper.MapToFlag(flag));
        }

        public FlagDAO GetFlagByID(int id)
        {
            return FlagMapper.MapToFlagDAO(data.GetFlag(id));
        }

        public List<FlagDAO> GetAllFlags()
        {
            List<FlagDAO> flags = new List<FlagDAO>();
            foreach (var item in data.ListFlags())
            {
                flags.Add(FlagMapper.MapToFlagDAO(item));
            }
            return flags;
        }

        public bool MarkFlagAsRead(FlagDAO flag)
        {
            return data.MarkFlagAsRead(FlagMapper.MapToFlag(flag));
        }

    }
}