﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AdministratorRegisterDto
    {
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
