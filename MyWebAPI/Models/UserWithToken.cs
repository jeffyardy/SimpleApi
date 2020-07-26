using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class UserWithToken
    {
        public User _user;

        //public string Token { get; set; }

        public UserWithToken(User user)
        {
            _user = user;
        }


    }
}
