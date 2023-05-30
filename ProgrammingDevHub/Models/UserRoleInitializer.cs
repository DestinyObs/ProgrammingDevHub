using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;


namespace ProgrammingDevHub.Models
{
    public class UserRoleInitializer 
    {

        public static async Task InitializerAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

            String[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;
            foreach ( var roleName in roleNames )
            {
                var roleExists = await roleManager.RoleExistsAsync( roleName );
                if ( !roleExists )
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var email = "admin@gmail.com";
            var password = "Password!";

            if (UserManager.FindByEmailAsync(email).Result == null) 
            {
                DefaultUserIdProvider user = new()
                {
                    UserName = "DestinyUser",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    Language = new Languages()
                    {
                        Language = "React Javascript",
                        Description = "Senior Developer in Javascript"
                    }

                };
            }


        }
    }
}
