using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
   public partial class RevaShareDataService
   {
      public UserDAO Login(string username, string password)
      {
         var result = data.TryLogin(username, password);
         if (result)
         {
            return GetUserByUsername(username);
         }
         else return null;

      }

      public List<UserDAO> GetAllUsers()
      {
         List<UserInfo> allUsers = new List<UserInfo>();
         allUsers = data.ListUsers();

         List<UserDAO> usersDAO = new List<UserDAO>();

         foreach (UserInfo user in allUsers)
         {
            if (user != null)
            {
               usersDAO.Add(UserMapper.MapToUserDAO(data.GetIdentityUser(user.UserID), user));
            }
         }

         return usersDAO;
      }

      public UserDAO GetUserByUsername(string username)
      {
         List<UserInfo> allUsers = new List<UserInfo>();
         allUsers = data.ListUsers();

         List<UserDAO> usersDAO = new List<UserDAO>();

         foreach (UserInfo user in allUsers)
         {
            if (user != null)
            {
               usersDAO.Add(UserMapper.MapToUserDAO(data.GetIdentityUser(user.UserID), user));
            }
         }

         var userRequested = usersDAO.Where(a => a.UserName == username);

         if (userRequested.Count() > 0)
         {
            return userRequested.First();
         }

         else
         {
            return null;
         }
      }

      public bool RegisterUser(UserDAO user, string username, string password)
      {
         UserInfo info = new UserInfo();
         info.Name = user.Name;
         info.ApartmentID = data.GetApartmentByName(user.Apartment.Name).ID;
         info.Phone = user.PhoneNumber;
         info.Email = user.Email;
         return data.CreateUser(info, username, password);
      }

      public List<UserDAO> GetAdmins()
      {
         List<UserInfo> allAdmins = new List<UserInfo>();
         allAdmins = data.ListAdmins();

         List<UserDAO> adminsDAO = new List<UserDAO>();

         foreach (UserInfo admin in allAdmins)
         {
            adminsDAO.Add(UserMapper.MapToUserDAO(data.GetIdentityUser(admin.UserID), admin));
         }

         return adminsDAO;
      }

      public UserDAO GetAdminByUsername(string username)
      {
         List<UserInfo> allAdmins = new List<UserInfo>();
         allAdmins = data.ListAdmins();

         List<UserDAO> adminsDAO = new List<UserDAO>();

         foreach (UserInfo admin in allAdmins)
         {
            adminsDAO.Add(UserMapper.MapToUserDAO(data.GetIdentityUser(admin.UserID), admin));
         }

         var adminRequested = adminsDAO.Where(a => a.UserName == username);

         if (adminRequested.Count() > 0)
         {
            return adminRequested.First();
         }

         else
         {
            return null;
         }
      }

      public bool DeleteUser(string username)
      {
         return data.DeleteUser(username);
      }

      public bool ApproveDriver(string username)
      {
         return data.ApproveUserDriverRequest(username);
      }

      public bool ApproveUser(string username)
      {
         return data.ApproveUserRegistration(username);
      }

      public List<UserDAO> PendingRegistrations()
      {
         List<UserDAO> users = new List<UserDAO>();
         var pendings = data.ListUsersWithPendingApproval();
         foreach (var item in pendings)
         {
            users.Add(UserMapper.MapToUserDAO(data.GetIdentityUser(item.UserID), item));
         }
         return users;
      }

      public List<UserDAO> PendingDriverApprovals()
      {
         List<UserDAO> users = new List<UserDAO>();
         var pendings = data.ListUsersWithDriverApprovalPending();
         foreach (var item in pendings)
         {
            users.Add(UserMapper.MapToUserDAO(data.GetIdentityUser(item.UserID), item));
         }
         return users;
      }

      public bool UpdateUser(UserDAO user)
      {
         string userId = data.GetUserId(user.UserName);
         IdentityUser identityUser = data.GetIdentityUser(userId);
         identityUser.Email = user.Email;
         identityUser.PhoneNumber = user.PhoneNumber;

         IdentityResult result = RevaShareIdentity.Instance.Manager.UpdateAsync(identityUser).Result;

         if (!result.Succeeded)
         {
            return false;
         }

         Apartment apartment = data.GetApartmentByName(user.Apartment.Name);

         UserInfo info = data.ListUserByUserId(userId);
         info.UserID = userId;
         info.Email = user.Email;
         info.Apartment = apartment;
         info.ApartmentID = apartment.ID;
         info.Name = user.Name;
         info.Phone = user.PhoneNumber;

         return data.UpdateUserInfo(info);
      }

      public bool UpdatePassword(string username, string currentPassword, string newPassword)
      {
         return RevaShareIdentity.Instance.Manager.ChangePassword(data.GetUserId(username), currentPassword, newPassword).Succeeded;
      }

      public bool RequestToBeDriver(string username)
      {
         return data.RequestToBeDriver(username);
      }
   }
}