using _180528.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _180528.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HackerNewsRepository repo = new HackerNewsRepository(); 
            return View(repo.GetTwentyTopStories());
        }                   
    }
}