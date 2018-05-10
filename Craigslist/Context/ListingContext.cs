using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Craigslist.Models;

namespace Craigslist.Context
{
    public class ListingContext:DbContext
    {
        public ListingContext() :base("name=DefaultConnection")
            {

            }
        public DbSet<Listing> Listings { get; set; }
    }
}