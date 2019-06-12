using EBazarAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarAdmin.Controllers
{
    public class VendorController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: Vendor
        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }
    }
}