using Craigslist.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Craigslist.Models;
using Craigslist.ViewModel;

namespace Craigslist.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        public IEnumerable<Listing> Search([FromUri]SearchParams param)
        {
            using (var context = new ListingContext())
            {
                 IQueryable<Listing> query = context.Listings;

                if (!String.IsNullOrEmpty(param.searchTitle))
                {
                    query = query.Where(w => w.Title == param.searchTitle);
                }
                if (!String.IsNullOrEmpty(param.searchContent))
                {
                    query = query.Where(w => w.Content == param.searchContent);
                }
                if (!String.IsNullOrEmpty(param.searchLocation))
                {
                    query = query.Where(w => w.Location == param.searchLocation);
                }
                return query.ToList();

            }
        }
    }
}
