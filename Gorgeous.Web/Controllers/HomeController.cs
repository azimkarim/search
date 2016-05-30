using Gorgeous.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gorgeous.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                var viewModel = new IndexViewModel
                {

                    Items = new List<string>(),
                    Pager = new Pager(0, 1)
                };

                return View(viewModel);
            }
            else
            {
                var dummyItems = Enumerable.Range(1, 150).Select(x => "Response " + x);
                var pager = new Pager(dummyItems.Count(), page);

                var viewModel = new IndexViewModel
                {
                    Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };

                return View(viewModel);
            }

            
        }

        [HttpPost]
        public ActionResult Index(int? page, object result)
        { 
            //query api
        var key = "qlsyOUZzMr2HLbKQ2UY6~PSKRQ4FQuzACREKfwZV-zQ~AphcrPrQQATYD5ZC7I4ydblOghwReINi6VaBrLgLLUuy0niC4ggPskx0Tl08rB2L";
        var search = @"http://spatial.virtualearth.net/REST/v1/data/f22876ec257b474b82fe2ffcb8393150/NavteqNA/NavteqPOIs?spatialFilter=nearby(40.83274904439099,-74.3163299560546935,5)&$filter=EntityTypeID%20eq%20'6000'&$select=EntityID,DisplayName,Latitude,Longitude,__Distance&$top=3&key=";
        search += key;
        
        var dummyItems = Enumerable.Range(1, 150).Select(x => "Response " + x);
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}