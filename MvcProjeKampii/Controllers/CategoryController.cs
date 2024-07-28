using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;


namespace MvcProjeKampii.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDal(), new EFHeadingDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var values = cm.GetList();
            return View(values);
        }





        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator category = new CategoryValidator(); //Burası ValidationRules içerisinde hata mesajları kısmı.
            ValidationResult result = category.Validate(p);//Kategoriye göre hata mesajlarını verecek.
            if (result.IsValid)//Sonuç geçerliyse
            {
                cm.CategoryAdd(p);//ekleme yap.cm-->CategoryManager kategori ekleme nesnesi.
                return RedirectToAction("GetCategoryList");
            }
            else//değilse
            {
                foreach (var item in result.Errors)//hataları göster 
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);//propert-->veritabanındaki stun adları kategoriname,categorydescription..

                }
            }
            return View();
        }
    }
}