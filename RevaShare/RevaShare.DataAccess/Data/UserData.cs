using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data
{
   public partial class RevaShareData
   {
      //Constants to be used for inputing the different roles. 
      private const string ROLE_UNASSIGNED = "Unassigned",
          ROLE_RIDER = "Rider",
          ROLE_DRIVER = "Driver",
          ROLE_REQUEST_DRIVER = "RequestDriver",
          ROLE_ADMIN = "Admin";

      public bool CreateUser(UserInfo userInfo, string username, string password)
      {
         IdentityUser user = new IdentityUser
         {
            UserName = username,
            Email = userInfo.Email,
            PhoneNumber = userInfo.Phone
         };

         IdentityResult result = RevaShareIdentity.Instance.Manager.Create(user, password);

         if (!result.Succeeded)
         {
            return false;
         }

         user = RevaShareIdentity.Instance.Manager.FindByName(username);
         RevaShareIdentity.Instance.Manager.AddToRole(user.Id, ROLE_UNASSIGNED);
         userInfo.UserID = user.Id;
         context.UserInfoes.Add(userInfo);
         return context.SaveChanges() > 0;
      }

        public bool CreateAdmin(UserInfo userInfo, string username, string password)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = username,
                Email = userInfo.Email,
                PhoneNumber = userInfo.Phone
            };

            IdentityResult result = RevaShareIdentity.Instance.Manager.Create(user, password);

            if (!result.Succeeded)
            {
                return false;
            }

            user = RevaShareIdentity.Instance.Manager.FindByName(username);
            RevaShareIdentity.Instance.Manager.AddToRole(user.Id, ROLE_ADMIN);
            userInfo.UserID = user.Id;
            context.UserInfoes.Add(userInfo);
            return context.SaveChanges() > 0;
        }

        public IdentityUser GetIdentityUser(string id)
      {
         return RevaShareIdentity.Instance.Manager.FindById(id);
      }

      public UserInfo GetUser(string username)
      {
         IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);
         return context.UserInfoes.FirstOrDefault(u => u.UserID == user.Id);
      }

      public List<UserInfo> ListUserInfoes()
      {
         return context.UserInfoes.ToList();
      }

      public string GetUserId(string username)
      {
         IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);
         return user == null ? string.Empty : user.Id;
      }

        public List<UserInfo> ListRidersAndDrivers()
        {
            List<UserInfo> allUsers = new List<UserInfo>();

            foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users)
            {
                if (RevaShareIdentity.Instance.Manager.IsInRole(user.Id, ROLE_RIDER) || RevaShareIdentity.Instance.Manager.IsInRole(user.Id, ROLE_DRIVER))
                {
                    allUsers.Add(GetUser(user.UserName));
                }
            }

            return allUsers;
        }

        public List<UserInfo> ListAdmins()
        {
            List<UserInfo> allAdmins = new List<UserInfo>();

            foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users)
            {
                if (RevaShareIdentity.Instance.Manager.IsInRole(user.Id, ROLE_ADMIN))
                {
                    allAdmins.Add(GetUser(user.UserName));
                }
            }

            return allAdmins;
        }

        public List<UserInfo> ListRiders()
        {
            List<UserInfo> allRiders = new List<UserInfo>();

            foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users)
            {
                if (RevaShareIdentity.Instance.Manager.IsInRole(user.Id, ROLE_RIDER))
                {
                    allRiders.Add(GetUser(user.UserName));
                }
            }

            return allRiders;
        }

        public List<UserInfo> ListDrivers()
        {
            List<UserInfo> allDrivers = new List<UserInfo>();

            foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users)
            {
                if (RevaShareIdentity.Instance.Manager.IsInRole(user.Id, ROLE_DRIVER))
                {
                    allDrivers.Add(GetUser(user.UserName));
                }
            }

            return allDrivers;
        }

        public List<UserInfo> ListUsersInRole(string role) {
            List<UserInfo> users = new List<UserInfo>();

         foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users)
         {
            if (RevaShareIdentity.Instance.Manager.IsInRole(user.Id, role))
            {
               users.Add(GetUser(user.UserName));
            }
         }

         return users;
      }

        public List<UserInfo> ListUsers()
        {
            List<UserInfo> users = new List<UserInfo>();

            foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users)
            {
                users.Add(GetUser(user.UserName));
            }

            return users;
        }

        public UserInfo ListUserByUserId(string userId)
        {
            return context.UserInfoes.Find(userId);
        }

        public List<UserInfo> ListUsersWithPendingApproval() {
            return ListUsersInRole(ROLE_UNASSIGNED);
        }

      public List<UserInfo> ListUsersWithDriverApprovalPending()
      {
         return ListUsersInRole(ROLE_REQUEST_DRIVER);
      }

      public bool ApproveUserRegistration(string username)
      {
         return UpdateUserRole(username, ROLE_RIDER);
      }

      public bool RequestToBeDriver(string username)
      {
         return UpdateUserRole(username, ROLE_REQUEST_DRIVER);
      }

      public bool ApproveUserDriverRequest(string username)
      {
         return UpdateUserRole(username, ROLE_DRIVER);
      }

        public bool RemoveDriverPrivilegesRequest(string username)
        {
            return UpdateUserRole(username, ROLE_RIDER);
        }

        public bool UpdateUserRole(string username, string role)
      {
         IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);

         foreach (string userRole in RevaShareIdentity.Instance.Manager.GetRoles(user.Id))
         {
            RevaShareIdentity.Instance.Manager.RemoveFromRole(user.Id, userRole);
         }

         IdentityResult result = RevaShareIdentity.Instance.Manager.AddToRole(user.Id, role);
         return result.Succeeded;
      }

      public bool UpdateUserInfo(UserInfo info)
      {
         DbEntityEntry<UserInfo> entry = context.Entry(info);
         entry.State = System.Data.Entity.EntityState.Modified;
         return context.SaveChanges() > 0;
      }

      public bool DeleteUser(string username)
      {
         DbEntityEntry entry = context.Entry(GetUser(username));
         entry.State = System.Data.Entity.EntityState.Deleted;

         IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);
         IdentityResult result = RevaShareIdentity.Instance.Manager.Delete(user);

         if (!result.Succeeded)
         {
            return false;
         }

         return context.SaveChanges() > 0;
      }

      public bool TryLogin(string username, string password)
      {
         IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);

         if (user == null)
         {
            return false;
         }

         return RevaShareIdentity.Instance.Manager.CheckPassword(user, password);
      }
   }
}
