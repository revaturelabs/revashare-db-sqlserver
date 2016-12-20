using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
    public class RevaShareIdentity {
        private static RevaShareIdentity _instance;

        public class RevaShareIdentityContext : IdentityDbContext<IdentityUser> {
            public RevaShareIdentityContext() : base("IdentityDBEntities") { }
        }


        //Get the Instance of RevaShareIdentity.
        public static RevaShareIdentity Instance {
            get {
                if (_instance == null) {
                    _instance = new RevaShareIdentity();
                }

                return _instance;
            }
        }

        public UserStore<IdentityUser> Credentials { get; private set; }
        public UserManager<IdentityUser> Manager { get; private set; }

        //Singleton for the Identity UserManager.
        private RevaShareIdentity() {
            Credentials = new UserStore<IdentityUser>(new RevaShareIdentityContext());
            Manager = new UserManager<IdentityUser>(Credentials);
        }
    }
}
