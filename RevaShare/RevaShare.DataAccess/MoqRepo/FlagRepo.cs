using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.MoqRepo
{
  public class FlagRepo : IFlag
  {
    public List<Flag> ListFlags()
    {
      var flagList = new List<Flag>();
      flagList.Add(
        new Flag
        {
          ID = 1,
          DriverID = "user1",
          RiderID = "user6",
          Type = "Positive",
          Message = "Always on time and drives great!"
        });
      flagList.Add(
        new Flag
        {
          ID = 2,
          DriverID = "user3",
          RiderID = "user4",
          Type = "Negative",
          Message = "Always on late and drives like a maniac!"
        });
      return flagList;
    }
  }
}
