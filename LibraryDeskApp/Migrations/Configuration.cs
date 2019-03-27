namespace LibraryDeskApp.Migrations
{
    using LibraryBookDeskApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryBookDeskApp.Model.MyLibraryDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LibraryBookDeskApp.Model.MyLibraryDb";
        }

        protected override void Seed(LibraryBookDeskApp.Model.MyLibraryDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.LibraryBook.AddOrUpdate(new LibraryBook()
            {
                Id = 9781491962299,
                Title = "Hands-On Machine Learning with Scikit-Learn & TensorFlow",
                Author = "Aurelien Geron",
                Publisher = "O'Reilly Media, Inc.",
                DatePublished = new DateTime(2018, 1, 19),
                InStockLocations = new List<Library>()
                {
                    new Library()
                    {
                        Id = 1,
                        Name = "Jake's Library",
                        Address = "123 Library Ln. Macon, Ga"
                    },
                    new Library()
                    {
                        Id = 2,
                        Name = "Matt's Library",
                        Address = "456 Reader Rd. Perry, Ga"
                    }
                }

            });
        }
    }
}
