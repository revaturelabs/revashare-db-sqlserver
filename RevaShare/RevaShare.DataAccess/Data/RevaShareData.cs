using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
    public partial class RevaShareData {
        private RevaShareDBEntities context;

        public RevaShareData() {
            context = new RevaShareDBEntities();
        }
    }
}
