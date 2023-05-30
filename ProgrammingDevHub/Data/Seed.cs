using ProgrammingDevHub.Data.Enums;
using System.Text.RegularExpressions;
using System;
using ProgrammingDevHub.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace ProgrammingDevHub.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {

                        new Club()
                        {
                            Title = "Programming Group 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Trainee Developer Group",
                            ClubCategory = ClubCategory.Trainee_Developer,
                            Language = new Languages()
                            {
                                Language = "Javascript",
                                Description = "Trainee Developer in Javascript"
                            }
                         },
                        new Club()
                        {
                            Title = "Programming Group 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Senior Developer Group",
                            ClubCategory = ClubCategory.Senior_Developer,
                            Language = new Languages()
                            {
                                Language = "React Javascript",
                                Description = "Senior Developer in Javascript"
                            }
                        },
                        new Club()
                        {
                            Title = "Programming Group 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Senior Developer Group",
                            ClubCategory = ClubCategory.Middle_Developer,
                            Language = new Languages()
                            {
                                Language = "ASP.NET 6.0",
                                Description = "Senior Developer in ASP.Net 6"
                            }
                        },
                        new Club()
                        {
                            Title = "Programming Group 4",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Junior Developer Group",
                            ClubCategory = ClubCategory.Junior_Developer,
                            Language = new Languages()
                            {
                                Language = "SQL",
                                Description = "Junoir Developer in SQL"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //CodingMeetUp
                if (!context.MeetUps.Any())
                {
                    context.MeetUps.AddRange(new List<MeetUp>()
                    {
                        new ()
                        {
                            Title = "Programming group for React Javascript",
                            Image = "https://media.sketchfab.com/models/350b1d11189b49919184ceda21886ebc/thumbnails/9b15af9655904474a31f0b7a48ff4955/72351db1ea1b4386aec2da04b2da68a1.jpeg",
                            Description = "This is the description of the React Developer",
                            MeetUpCategory = MeetUpCategory.JavaScript,
                            Language = new Languages()
                            {
                               Language = "React Javascript",
                                Description = "Senior Developer in Javascript"
                            }
                        },
                        new MeetUp()
                        {
                            Title = "ASP.Net",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Dot Net Developers",
                            MeetUpCategory = MeetUpCategory.ASPDotNet,
                            Language = new Languages()
                            {
                                Language = "ASP.NET 6.0",
                                Description = "Senior Developer in ASP.Net 6"
                            }
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "destinydeveloper",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Language = new Languages()
                        {
                            Language = "ASP.NET 6.0",
                            Description = "Senior Developer in ASP.Net 6"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new  AppUser()
                    {
                        UserName = "destiny0",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Language = new Languages()
                        {
                            Language = "ASP.NET 6.0",
                            Description = "Senior Developer in ASP.Net 6"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

    }
}

