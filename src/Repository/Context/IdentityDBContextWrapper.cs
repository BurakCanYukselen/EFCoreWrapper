﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreWrapper.Context
{
    public class IdentityDBContextWrapper<AppUser> : IdentityDbContext<AppUser>
        where AppUser : IdentityUser
    {
        public IdentityDBContextWrapper(DbContextOptions options) : base(options) { }
    }
}
