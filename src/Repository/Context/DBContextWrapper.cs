using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class DBContextWrapper : DbContext
    {
        public DBContextWrapper(DbContextOptions<DBContextWrapper> options) : base(options) { }
    }
}
