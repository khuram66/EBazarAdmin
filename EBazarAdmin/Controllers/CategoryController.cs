using EBazarAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarAdmin.Controllers
{
    public class CategoryController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {   
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryViewModel cat)
        {
            
            if(ModelState.IsValid)
            {
                if (cat.Category_Image != null)
                {
                    var imagename = Path.GetFileNameWithoutExtension(cat.Category_Image.FileName);
                    var extention = Path.GetExtension(cat.Category_Image.FileName);
                    imagename = imagename + "_" + DateTime.Now.Date.ToString("ddMMyyyy") + extention;
                    cat.Category_Image_Path = "~/CategoryImages/" + imagename;
                    var serverpath = Path.Combine(Server.MapPath("~/CategoryImages/"), imagename);
                    cat.Category_Image.SaveAs(serverpath);
                    Category category = new Category
                    {
                        ID = cat.ID,
                        Category_Name = cat.Category_Name,
                        Category_Image_Path = cat.Category_Image_Path,
                        Is_Active = cat.Is_Active
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Category cat = db.Categories.SingleOrDefault(x => x.ID == id);
            
            if (cat == null)
            {
                return HttpNotFound();
            }
            else
            {
                CategoryViewModel catvm = new CategoryViewModel
                {
                    Category_Name = cat.Category_Name,
                    Category_Image_Path = cat.Category_Image_Path,
                    Is_Active = cat.Is_Active
                };
                return View(catvm);
            }       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                if (cat.Category_Image != null)
                {
                    var imagename = Path.GetFileNameWithoutExtension(cat.Category_Image.FileName);
                    var extention = Path.GetExtension(cat.Category_Image.FileName);
                    imagename = imagename + "_" + DateTime.Now.Date.ToString("ddMMyyyy") + extention;
                    cat.Category_Image_Path = "~/CategoryImages/" + imagename;
                    var serverpath = Path.Combine(Server.MapPath("~/CategoryImages/"), imagename);
                    cat.Category_Image.SaveAs(serverpath);
                    Category category = new Category
                    {
                        ID = cat.ID,
                        Category_Name = cat.Category_Name,
                        Category_Image_Path = cat.Category_Image_Path,
                        Is_Active = cat.Is_Active
                    };
                    db.Categories.Add(category);
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Category cat = db.Categories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            else
            {
                CategoryViewModel catvm = new CategoryViewModel
                {
                    Category_Name = cat.Category_Name,
                    Category_Image_Path = cat.Category_Image_Path,
                    Is_Active = cat.Is_Active
                };
                return View(catvm);
            }
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Category cat = db.Categories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            else
            {
                CategoryViewModel catvm = new CategoryViewModel
                {
                    Category_Name = cat.Category_Name,
                    Category_Image_Path = cat.Category_Image_Path,
                    Is_Active = cat.Is_Active
                };
                return View(catvm);
            }
           }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category cat = db.Categories.Find(id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}