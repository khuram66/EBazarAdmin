using EBazarAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarAdmin.Controllers
{
    public class CustomerController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
    }
}