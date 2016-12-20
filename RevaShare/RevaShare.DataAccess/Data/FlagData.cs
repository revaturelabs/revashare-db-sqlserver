using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
      public partial class RevaShareData {
      /// <summary>
      /// Create a Flag object.
      /// </summary>
      /// <param name="flag">The Flag to create.</param>
      /// <returns>True if the creation was successful or false if it was not.</returns>
      public bool Create(Flag flag)
      {
         flag.Active = true;
         context.Flags.Add(flag);
         return context.SaveChanges() > 0;
      }

      /// <summary>
      /// Get a Flag object.
      /// </summary>
      /// <param name="id">The ID of the Flag.</param>
      /// <returns>Returns the Flag object if it exists, null if it does not.</returns>
      public Flag GetFlag(int id)
      {
         return context.Flags.FirstOrDefault(f => f.ID == id && f.Active);
      }

      /// <summary>
      /// List the unread Flags.
      /// </summary>
      /// <returns>A List of all unread Flags.</returns>
      public List<Flag> ListFlags()
      {
         return context.Flags.Where(f => f.Active).ToList();
      }

      /// <summary>
      /// Mark a Flag as read.
      /// </summary>
      /// <param name="flag">The Flag object to mark as read, get it by using GetFlag.</param>
      /// <returns>True if the marking was successful, false otherwise.</returns>
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
