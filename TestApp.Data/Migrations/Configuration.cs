namespace TestApp.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestApp.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestApp.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "iamrks",
                Email = "iamrks@outlook.com",
                EmailConfirmed = true,
                FirstName = "Ravi Kant",
                LastName = "Sharma",
                JoinDate = DateTime.Now.AddYears(-2)
            };

            manager.Create(user, "mypass@123");
        }
    }
}
