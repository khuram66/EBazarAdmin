using EBazarAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarAdmin.Controllers
{
    public class OrderController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: Order
        public ActionResult Index()
        {
            
            return View();
        }
    }
}