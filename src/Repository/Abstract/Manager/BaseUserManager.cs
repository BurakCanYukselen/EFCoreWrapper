using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EFCoreWrapper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWrapper.Abstract.Manager
{
    public abstract class BaseUserManager<AppUser> : UserManager<AppUser>
        where AppUser : IdentityUser
    {
        public BaseUserManager(
            IUserStore<AppUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<AppUser> passwordHasher,
            IEnumerable<IUserValidator<AppUser>> userValidators,
            IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<AppUser>> logger) : base(store,
                                                         optionsAccessor,
                                                         passwordHasher,
                                                         userValidators,
                                                         passwordValidators,
                                                         keyNormalizer,
                                                         errors,
                                                         services,
                                                         logger)
        {
        }

        public async Task<AppUser> GetUserById(string userId)
        {
            return await base.FindByIdAsync(userId);
        }
        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await base.FindByEmailAsync(email);
        }
        public async Task<DBResponseModel<AppUser>> CheckUserAndPassword(string email, string password)
        {
            var user = await this.GetUserByEmail(email);
            var checkPassword = await base.CheckPasswordAsync(user, password);
            if (user == null)
                return new DBResponseModel<AppUser>(null) { IsSucces = false, ErrorMessage = "User Not Found" };
            if (checkPassword)
                return new DBResponseModel<AppUser>(null) { IsSucces = false, ErrorMessage = "Password is not correct" };

            return new DBResponseModel<AppUser>(user) { IsSucces = true};
        }
        public async Task<DBResponseModel<AppUser>> CreateUser(AppUser user, string password)
        {
            var result = await base.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var sb = new StringBuilder();
                sb.AppendJoin(Environment.NewLine, result.Errors.Select(p => p.Description));
                return new DBResponseModel<AppUser>(null) { IsSucces = false, ErrorMessage = sb.ToString() };
            }
            return new DBResponseModel<AppUser>(user) { IsSucces = true };
        }
    }
}
