using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Craigslist.Context;
using Craigslist.Models;


namespace Craigslist.Controllers
{

    public class ListingsController : ApiController
    {
        [HttpGet]
        public IEnumerable<Listing> GetAllListings()
        {
            using (var context = new ListingContext())
            {
                var listings = context.Listings.OrderBy(o => o.Date).ToList();
                return listings;
            }
        }
    }
    
}
