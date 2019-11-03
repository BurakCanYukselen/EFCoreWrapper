using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Extensions
{
    static class ServiceCollectionExtension
    {
        public static void AddEFCoreWrapper<DBContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
            where DBContext : DBContextWrapper
        {
            services.AddDbContext<DBContext>(optionsAction);
        }

        public static void AddEFCoreIndetityWrapper<DBContext, AppUser>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
            where DBContext : IdentityDBContextWrapper<AppUser>
            where AppUser : IdentityUser
        {
            services.AddDbContext<DBContext>(optionsAction);
            services.AddIdentityCore<AppUser>()
                    .AddEntityFrameworkStores<DbContext>();
        }
    }
}
