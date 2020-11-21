﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBox.Models.UserModels
{
    public class UserAdminView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
        public bool Enable { get; set; }
    }
}
