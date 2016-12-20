using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
      public partial class RevaShareData {
      public bool Create(Flag flag)
      {
         flag.Active = true;
         context.Flags.Add(flag);
         return context.SaveChanges() > 0;
      }

      public Flag GetFlag(int id)
      {
         return context.Flags.FirstOrDefault(f => f.ID == id && f.Active);
      }

      public List<Flag> ListFlags()
      {
         return context.Flags.Where(f => f.Active).ToList();
      }

     public bool MarkFlagAsRead(Flag flag)
      {
         DbEntityEntry<Flag> entry = context.Entry(flag);
         flag.Active = false;
         entry.State = System.Data.Entity.EntityState.Modified;
         return context.SaveChanges() > 0;
      }

     
      public bool UpdateFlag(Flag flag)
      {
         var actualFlag = GetFlag(flag.ID);
         actualFlag.Active = flag.Active;
         actualFlag.DriverID = flag.DriverID;
         actualFlag.Message = flag.Message;
         actualFlag.RiderID = flag.RiderID;
         actualFlag.Type = flag.Type;         
         DbEntityEntry<Flag> entry = context.Entry(actualFlag);
         entry.State = System.Data.Entity.EntityState.Modified;
         return context.SaveChanges() > 0;
      }

      public bool DeleteFlag(Flag flag)
      {
         var actualFlag = GetFlag(flag.ID);
         actualFlag.Active = false;
         return UpdateFlag(actualFlag);
      }
   }
}
