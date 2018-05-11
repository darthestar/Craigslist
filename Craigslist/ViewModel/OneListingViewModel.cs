using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craigslist.ViewModel
{
    public class OneListingViewModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
    }
}