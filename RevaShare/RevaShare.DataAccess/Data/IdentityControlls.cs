using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RevaShare.DataAccess.Data
{
    public class Q : IdentityDbContext
    {
        public Q() : base("RevaShareDBEntities")
        {

        }
    }

    public class IdentityControlls
    {
        private static RevaShareDBEntities context = new RevaShareDBEntities();
        private static UserStore<IdentityUser> credentials = new UserStore<IdentityUser>(new Q());

        public bool Signup(string Username, string password)
        {
            var user = new IdentityUser { UserName = Username };
            var manager = new UserManager<IdentityUser>(credentials);
            var result = manager.Create(user, password);
            if (result.Succeeded)
            {
                //Roles.AddUserToRole(account.Username, "admin");
                return true;
            }
            return false;
        }

        public bool Login(string Username, string password)
        {
            var manager = new UserManager<IdentityUser>(credentials);
            var user = manager.FindByName(Username);
            if (user == null)
            {
                return false;
            }
            return true;
        }

    }
    
}
