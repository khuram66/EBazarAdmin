using EBazarAdmin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarAdmin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ECommerceDBEntities db = new ECommerceDBEntities();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [NonAction]
        public void getAllCategories()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Category_Name");
        }
        [HttpGet]
        public ActionResult Add()
        {
            //var categorylist = db.Categories.ToList();
            //SelectList list = new SelectList(categorylist, "ID", "Category_Name");
            //ViewBag.categoryName = list;
            getAllCategories();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductViewModel product)
        {
            getAllCategories();
            //if (ModelState.IsValid)
            //{
            //    if (product.ProdFeatureImage != null)
            //    {
            //        var imagename = Path.GetFileNameWithoutExtension(product.ProdFeatureImage.FileName);
            //        var extention = Path.GetExtension(product.ProdFeatureImage.FileName);
            //        imagename = imagename + "_" + DateTime.Now.Date.ToString("ddMMyyyy") + extention;
            //        product.Product_Feature_Image = "~/ProductImages/" + imagename;
            //        var serverpath = Path.Combine(Server.MapPath("~/ProductImages/"), imagename);
            //        product.ProdFeatureImage.SaveAs(serverpath);
            //        Product prod = new Product
            //        {
            //            Product_Name = product.Product_Name,
            //            Producct_Short_Description = product.Producct_Short_Description,
            //            Product_Long_Description = product.Product_Long_Description,
            //            Product_Feature_Image = product.Product_Feature_Image,
            //            Product_Price = product.Product_Price,
            //            Product_Quantity = product.Product_Quantity,
            //            Product_Sale_Price = product.Product_Sale_Price,
            //            Product_Size = product.Product_Size,
            //            Is_Active = product.Is_Active,
            //            Is_Featured = product.Is_Featured,
            //            Is_OnSale = product.Is_OnSale,
            //            Category_ID = product.Category_ID,
            //        };
            //        db.Products.Add(prod);
            //        return View();
            //    }
            //    if (product.ProdImages != null)
            //    {
            //        foreach (var images in product.ProdImages)
            //        {

            //            var imagename = Path.GetFileNameWithoutExtension(images.FileName);
            //            var extention = Path.GetExtension(images.FileName);
            //            imagename = imagename + "_" + DateTime.Now.Date.ToString("ddMMyyyy") + extention;
            //            product.Product_image = "~/ProductImages/" + imagename;
            //            var serverpath = Path.Combine(Server.MapPath("~/ProductImages/"), imagename);
            //            images.SaveAs(serverpath);
            //            ProdcutImages pimg = new ProdcutImages
            //            {
            //                Product_ID = product.ID,
            //                Product_image = product.Product_image
            //            };
            //            db.ProdcutImages.Add(pimg);
            //            db.SaveChanges();
            //            return View("Index", "Product");
            //        }
            //    }
            //}
            return View("Add", "Product");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Product product = db.Products.Find(id);
            var pimg = db.ProdcutImages.Where(x => x.Product_ID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel pvm = new ProductViewModel
                {
                    ID = product.ID,
                    Product_Name = product.Product_Name,
                    Producct_Short_Description = product.Producct_Short_Description,
                    Product_Long_Description = product.Product_Long_Description,
                    Product_Feature_Image = product.Product_Feature_Image,
                    Category_ID = product.Category_ID,
                    Product_Price = product.Product_Price,
                    Product_Quantity = product.Product_Quantity,
                    Product_Sale_Price = product.Product_Sale_Price,
                    Product_Size = product.Product_Size,
                    Is_Active = product.Is_Active,
                    Is_Featured = product.Is_Featured,
                    Is_OnSale= product.Is_OnSale

                };
                return View(pvm);
            }
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel pvm = new ProductViewModel
                {
                    ID = product.ID,
                    Product_Name = product.Product_Name,
                    Producct_Short_Description = product.Producct_Short_Description,
                    Product_Long_Description = product.Product_Long_Description,
                    Product_Feature_Image = product.Product_Feature_Image,
                    Category_ID = product.Category_ID,
                    Product_Price = product.Product_Price,
                    Product_Quantity = product.Product_Quantity,
                    Product_Sale_Price = product.Product_Sale_Price,
                    Product_Size = product.Product_Size,
                    Is_Active = product.Is_Active,
                    Is_Featured = product.Is_Featured,
                    Is_OnSale = product.Is_OnSale

                };
                return View(pvm);
            }

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Product product = db.Products.Find(id);   
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}