using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Reindawn.Domain.Models;
using Reindawn.Repository.Context;

namespace ReindawnApi.App_Start
{
    public class IdentityConfig
    {
        public class ApplicationUserManager : UserManager<User, Guid>
        {
            public ApplicationUserManager(IUserStore<User, Guid> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {

                var manager = new ApplicationUserManager(new CustomUserStore(context.Get<ReindawnContext>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<User, Guid>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, Guid>
                //{
                //    MessageFormat = "Your security code is {0}"
                //});
                //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, Guid>
                //{
                //    Subject = "Security Code",
                //    BodyFormat = "Your security code is {0}"
                //});
                //manager.EmailService = new EmailService();
                //manager.SmsService = new SmsService();
                //var dataProtectionProvider = options.DataProtectionProvider;
                //if (dataProtectionProvider != null)
                //{
                //    manager.UserTokenProvider =
                //        new DataProtectorTokenProvider<User, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
                //}
                return manager;
            }
        }

        public class ApplicationSignInManager : SignInManager<User, Guid>
        {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
                : base(userManager, authenticationManager)
            {
            }

            public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
            {
                return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
            }

            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }
    }
}