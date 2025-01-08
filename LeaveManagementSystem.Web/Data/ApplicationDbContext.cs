using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Adding default auth roles
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole 
                { 
                    Id = "6e6a28ad-60bb-47f8-88f1-21c642cb5401",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
                 new IdentityRole
                 {
                     Id = "2b25e4a1-74c5-45f0-aa24-27a7a5d01421",
                     Name = "Supervisor",
                     NormalizedName = "SUPERVISOR",
                 },
                  new IdentityRole
                  {
                      Id = "af42a916-b144-45d3-8426-3d7db9febf95",
                      Name = "Administrator",
                      NormalizedName = "ADMINISTRATOR",
                  }
                );

            //initialising a default admin user

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser 
                { 
                    Id = "d8e76c65-c900-495b-a047-7c7446ac0fd3",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1950, 12, 01)
                });

            //giving the user the admin role

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "af42a916-b144-45d3-8426-3d7db9febf95",
                    UserId = "d8e76c65-c900-495b-a047-7c7446ac0fd3"
                }
                );

            //Then do the migration in PM console:
            // PM> add-migration SeedingDefaultRolesAndUser
        }

        //letting dbcontext know about our data classes
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> leaveAllocations { get; set; }
        public DbSet<Period> Periods { get; set; }

    }
}
