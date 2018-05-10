namespace Craigslist.Migrations
{
    using Craigslist.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Craigslist.Context.ListingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Craigslist.Context.ListingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var listings = new List<Listing>
            {
                new Listing {Title= "Trek Bike",Content="Like New, 5 speed, $500", Location="St. Petersburg", Date= new DateTime(2018,5,1)},
                new Listing {Title= "Trek Bike",Content="1 year old, 5 speed, $300", Location="St. Petersburg", Date= new DateTime(2018,5,3)},
                new Listing {Title= "Kid's Bicycle",Content="Good Shape,yellow and green, $30", Location="St. Petersburg", Date= new DateTime(2018,5,7)},
                new Listing {Title= "Women's Bicycle",Content="In Good Shape, light green, $140", Location="South Tampa", Date= new DateTime(2018,5,10)},
                new Listing {Title= "Men's Racing Bicycle",Content="Few years old,black, $290", Location="Pinellas Park", Date= new DateTime(2018,5,9)},
                new Listing {Title= "Women's Cruiser", Content="3 years old, pink, $190", Location="St. Petersburg", Date= new DateTime(2018,5,4)},
            };

            listings.ForEach(l =>
            {
                context.Listings.AddOrUpdate(i => i.ID, l);
            });
        }
    }
}
