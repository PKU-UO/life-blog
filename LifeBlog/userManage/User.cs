using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBlog.userManage
{
    class User
    {
        public String username { get; set; }
        public String password { get; set; }
        public String date_of_birth { get; set; }
        public String email { get; set; }        
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String articles { get; set; }
        public String token { get;set;}
    }
}
