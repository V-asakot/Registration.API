﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Entities
{
    public class User : IdentityUser
    {
        public Region? Region { get; set; }

        public User(string email)
        {
           Email = email;
           UserName = email;
        }
    }
}
