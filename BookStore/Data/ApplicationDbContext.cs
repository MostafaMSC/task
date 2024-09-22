using BookStore.Controllers;
using BookStore.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Books> BooksTable { get; set; }
        public DbSet<ShippingCartModule> ShippingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderModule> OrdersTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string Owner_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string OwnerRole_ID = "oi2eoij-1oqjsdkj-kaslk-OwnerRole";

            // Define relationships
            builder.Entity<CartItem>()
                .HasOne<ShippingCartModule>()
                .WithMany()
                .HasForeignKey(c => c.ShippingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CartItem>()
                .HasOne<Books>()
                .WithMany()
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed roles
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "owner",
                Name = "owner",
                NormalizedName = "OWNER"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "admin",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "View",
                Name = "View",
                NormalizedName = "VIEW"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "admin2",
                Name = "admin2",
                NormalizedName = "ADMIN2"
            });
        }

        public async Task SeedUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminEmail = "admin@gmail.com";
            const string adminPassword = "Mustafa@101";

            var existingUser = await userManager.FindByEmailAsync(adminEmail);
            if (existingUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    NormalizedEmail = adminEmail.ToUpper()
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
        }

    }
}
