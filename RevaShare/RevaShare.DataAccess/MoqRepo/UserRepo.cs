using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.MoqRepo
{
  public class UserRepo : IUserInfo
  {
    public List<UserInfo> ListUsers()
    {
      var userList = new List<UserInfo>();
      userList.Add(
        new UserInfo
        {
          UserID = "user1",
          ApartmentID = 1,
          Name = "Billy Bob",
          Email = "email1@test.com",
          Phone = "2028675309"
        });
      userList.Add(
       new UserInfo
       {
         UserID = "user1",
         ApartmentID = 1,
         Name = "Billy Bob",
         Email = "email1@test.com",
         Phone = "2028675309"
       });
      userList.Add(
       new UserInfo
       {
         UserID = "user2",
         ApartmentID = 1,
         Name = "Joe Blow",
         Email = "email2@test.com",
         Phone = "1234567890"
       });
      userList.Add(
       new UserInfo
       {
         UserID = "user3",
         ApartmentID = 2,
         Name = "Jenny Mathews",
         Email = "email3@test.com",
         Phone = "9087654321"
       });
      userList.Add(
       new UserInfo
       {
         UserID = "user4",
         ApartmentID = 2,
         Name = "Jane Doe",
         Email = "email4@test.com",
         Phone = "4837283843"
       });
      userList.Add(
       new UserInfo
       {
         UserID = "user5",
         ApartmentID = 2,
         Name = "Monica Barnes",
         Email = "email5@test.com",
         Phone = "3344556789"
       });
      userList.Add(
       new UserInfo
       {
         UserID = "user6",
         ApartmentID = 1,
         Name = "Matt Johnson",
         Email = "email6@test.com",
         Phone = "3459870239"
       });
      return userList;
    }
  }
}
