using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingDevHub.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProgrammingDevHub.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<MeetUp> MeetUps { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Languages> Language { get; set; }

    }
}
