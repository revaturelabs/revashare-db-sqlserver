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
            RevaShareIdentity.Instance.Manager.AddToRole(user.Id, "Unassigned");

            context.UserInfoes.Add(userInfo);
            return context.SaveChanges() > 0;
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
