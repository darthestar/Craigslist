using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Craigslist.Context;
using Craigslist.ViewModel;
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


        //get one listing
        [HttpGet]
        [Route("api/listings/{listingID}")]
        public IHttpActionResult GetOneListing(int listingID)
        {
            using (var context = new ListingContext())
            {
                var oneListing = context.Listings.SingleOrDefault(i => i.ID == listingID);
                return Ok(oneListing);
            }
        }

        //create a listing
        [HttpPost]
        [Route("api/createpost/")]
        public IHttpActionResult CreateListing([FromBody] OneListingViewModel listing)
        {
            using (var context = new ListingContext())
            {
                context.Listings.Add(new Listing()
                {
                    Title = listing.title,
                    Content = listing.content,
                    Location = listing.location,
                    Date = listing.date,

                });
                context.SaveChanges();
                return Ok(listing);
            }
        }

        //get post id
        //find property to be changed
        //make update
        //save change
        [HttpPut]
        [Route("api/listing/{listingID}/updatepost")]
        public IHttpActionResult EditPost([FromUri] int listingID, [FromBody] OneListingViewModel updatedListing)
        {
            using (var context = new ListingContext())
            {
                var existingListing = context.Listings.SingleOrDefault(i => i.ID == listingID);

                if (existingListing != null)
                {
                    existingListing.Title = updatedListing.title;
                    existingListing.Content = updatedListing.content;
                    existingListing.Location = updatedListing.location;
                    existingListing.Date = DateTime.Now;

                    context.SaveChanges();
                }
                return Ok(existingListing);
            }
        }
        [HttpDelete]
        [Route ("api/listing/{listingID}/DeletePost/")]
        public IHttpActionResult DeletePost([FromUri] int listingID)
        {
            using (var context = new ListingContext())
            {
                Listing deletedPost = context.Listings
                 
                .Single<Listing>(i => i.ID == listingID);

                context.Listings.Remove(deletedPost);
                context.SaveChanges();
            }
            return Ok();
        }

    }
}
