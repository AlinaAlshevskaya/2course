using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab45
{
      public abstract class  Users
    {
          public string firsname;
        public string name;
        public string number;
        public string email;
        public  string password;
       public bool isAdmin;
        public Users(bool isadmin) 
        {
            isAdmin = isadmin;
        }
    }
}
