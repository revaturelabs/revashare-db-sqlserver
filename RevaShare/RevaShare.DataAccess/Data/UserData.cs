using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
    public partial class RevaShareData {
        private const string ROLE_UNASSIGNED = "Unassigned",
            ROLE_RIDER = "Rider",
            ROLE_DRIVER = "Driver",
            ROLE_REQUEST_DRIVER = "RequestDriver";
   
        /// <summary>
        /// Create a User.
        /// </summary>
        /// <param name="username">The new user's username.</param>
        /// <param name="password">The new user's password.</param>
        /// <returns>True if the creation was successful.</returns>
        public bool CreateUser(UserInfo userInfo, string username, string password) {
            IdentityUser user = new IdentityUser {
                UserName = username,
                Email = userInfo.Email,
                PhoneNumber = userInfo.Phone
            };

            IdentityResult result = RevaShareIdentity.Instance.Manager.Create(user, password);

            if (!result.Succeeded) {
                return false;
            }

            user = RevaShareIdentity.Instance.Manager.FindByName(username);            
            RevaShareIdentity.Instance.Manager.AddToRole(user.Id, ROLE_UNASSIGNED);
            userInfo.UserID = user.Id;
            context.UserInfoes.Add(userInfo);
            return context.SaveChanges() > 0;
        }

        public IdentityUser GetIdentityUser(string id)
        {
            return RevaShareIdentity.Instance.Manager.FindById(id);
        }
        /// <summary>
        /// Get a User by username.
        /// </summary>
        /// <param name="username">The username to get the user by.</param>
        /// <returns>The UserInfo or null if the user does not exist.</returns>
        public UserInfo GetUser(string username) {
            IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);
            return context.UserInfoes.FirstOrDefault(u => u.UserID == user.Id);
        }

        /// <summary>
        /// Get a user's Id.
        /// </summary>
        /// <param name="username">The username to get the Id from.</param>
        /// <returns>The Id or empty string if the user does not exist.</returns>
        public string GetUserId(string username) {
            IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);
            return user == null ? string.Empty : user.Id;
        }

        /// <summary>
        /// List all of the users in the given role.
        /// </summary>
        /// <param name="role">The role to List users from.</param>
        /// <returns>The List of users.</returns>
        public List<UserInfo> ListUsersInRole(string role) {
            List<UserInfo> users = new List<UserInfo>();

            foreach (IdentityUser user in RevaShareIdentity.Instance.Manager.Users) {
                if (RevaShareIdentity.Instance.Manager.IsInRole(user.Id, role)) {
                    users.Add(GetUser(user.UserName));
                }
            }

            return users;
        }

        /// <summary>
        /// List all the users who have registered but have not been approved
        /// to use the system.
        /// </summary>
        /// <returns>The List of unnapproved users.</returns>
        public List<UserInfo> ListUsersWithPendingApproval() {
            return ListUsersInRole(ROLE_UNASSIGNED);
        }

        /// <summary>
        /// List all the users who are pending approval to become a driver.
        /// </summary>
        /// <returns>The List of riders wanting to be drivers.</returns>
        public List<UserInfo> ListUsersWithDriverApprovalPending() {
            return ListUsersInRole(ROLE_REQUEST_DRIVER);
        }

        /// <summary>
        /// Approve a user and bring them into the system.
        /// </summary>
        /// <param name="username">The username of the user to approve.</param>
        /// <returns>True if the modification was successful.</returns>
        public bool ApproveUserRegistration(string username) {
            return UpdateUserRole(username, ROLE_RIDER);
        }

        /// <summary>
        /// Have a rider request to become a driver.
        /// </summary>
        /// <param name="username">The username of the user sending the request.</param>
        /// <returns>True if the modification was successful.</returns>
        public bool RequestToBeDriver(string username) {
            return UpdateUserRole(username, ROLE_REQUEST_DRIVER);
        }

        /// <summary>
        /// Approve a rider's request to become a driver.
        /// </summary>
        /// <param name="username">The username of the user to approve.</param>
        /// <returns>True if the modification was successful.</returns>
        public bool ApproveUserDriverRequest(string username) {
            return UpdateUserRole(username, ROLE_DRIVER);
        }

        /// <summary>
        /// Update a User's role.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <param name="role">The new role.</param>
        /// <returns>True if the role was successfully updated.</returns>
        public bool UpdateUserRole(string username, string role) {
            IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);

            foreach (string userRole in RevaShareIdentity.Instance.Manager.GetRoles(user.Id)) {
                RevaShareIdentity.Instance.Manager.RemoveFromRole(user.Id, userRole);
            }

            IdentityResult result = RevaShareIdentity.Instance.Manager.AddToRole(user.Id, role);
            return result.Succeeded;
        }

        /// <summary>
        /// Update a user's info.
        /// </summary>
        /// <param name="info">The UserInfo to update.</param>
        /// <returns>True if the update was successful.</returns>
        public bool UpdateUserInfo(UserInfo info) {
            DbEntityEntry<UserInfo> entry = context.Entry(info);
            entry.State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// Delete a User from the database.
        /// </summary>
        /// <param name="username">The username of the user to delete.</param>
        /// <returns>True if the deletion was successful.</returns>
        public bool DeleteUser(string username) {
            IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);
            IdentityResult result = RevaShareIdentity.Instance.Manager.Delete(user);

            if (!result.Succeeded) {
                return false;
            }

            DbEntityEntry entry = context.Entry(GetUser(username));
            entry.State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// Test to see if the username/password combination exists.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the username/password combination exists.</returns>
        public bool TryLogin(string username, string password) {
            IdentityUser user = RevaShareIdentity.Instance.Manager.FindByName(username);

            if (user == null) {
                return false;
            }

            return RevaShareIdentity.Instance.Manager.CheckPassword(user, password);
        }
    }
}
