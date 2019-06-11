using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBazarAdmin.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Display (Name = "Category Name")]
        public string Category_Name { get; set; }
        [Display(Name = "Category Image")]
        public string Category_Image_Path { get; set; }
        [Display(Name = "Is Active")]
        public string Is_Active { get; set; }
        public HttpPostedFileBase Category_Image { get; set; }
    }
}