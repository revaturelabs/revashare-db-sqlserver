using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data
{
    public class IdentityControlls
    {
        private static RevaShareDBEntities context = new RevaShareDBEntities();
        private static UserStore<AspNetUser> credentials = new UserStore<AspNetUser>(context);

        public bool Signup(string Username, string password)
        {
            var user = new AspNetUser { UserName = Username, Name = Username,  };
            var manager = new UserManager<AspNetUser>(credentials);
            var result = manager.Create(user, password);
            if (result.Succeeded)
            {
                //Roles.AddUserToRole(account.Username, "admin");
                return true;
            }
            return false;
        }

    }
    
}
