using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWrapper.Context
{
    public class DBContextWrapper : DbContext
    {
        public DBContextWrapper(DbContextOptions options) : base(options) { }
    }
}
