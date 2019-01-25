using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using static CacheDemo.CacheExtension;

namespace CacheDemo.Controllers
{
    public class HomeController : Controller
    {
        private ICache<MyEnum , Sample> _cache;

        public HomeController()
        {
            _cache = new Cache<MyEnum, Sample>();
        }



        public ActionResult Index()
        {


            Sample data = MyEnum.FUCK.GetCache(_cache , Get, 1);

            ViewBag.Title = data;

            return View();
        }

        private Sample Get()
        {
            return new Sample { MyProperty = 20 };
        }
    }


    public enum MyEnum
    {
        FUCK ,
        SHIT ,
    }

    public class Sample
    {
        public int MyProperty { get; set; }
    }
}


