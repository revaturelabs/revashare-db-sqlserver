using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
    public partial class RevaShareDataService
    {
        public bool Login(string username, string password)
        {
            return data.TryLogin(username, password);
        }


        public bool register(UserDAO user,string username, string password)
        {
            UserInfo info = new UserInfo();
            info.Name = user.Name;
            info.ApartmentID = data.GetApartmentByName(user.Apartment.Name).ID;
            info.Phone = user.PhoneNumber;
            info.Email = user.Email;
            return data.CreateUser(info, username, password);
        }

        public bool DeleteUser(string username)
        {
            return data.DeleteUser(username);
        }

        public bool UpdateUserRole(string username, string role)
        {
            return data.UpdateUserRole(username, role);
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

        
    }
}