using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProjeKampii.Controllers
{  //Yetkilendirmeler
    public class AuthorizationController : Controller
    {
        AdminManager am = new AdminManager(new EFAdminDal());
      
        //Tüm Adminleri Listeleme
        public ActionResult Index()
        {
            var values =am.GetList();
            return View(values);
        }

        //Admin Ekleme
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> Admin = (from x in am.GetList()
                                          select new SelectListItem
                                          {
                                              Value = x.AdminRole,
                                              Text = x.AdminRole
                                          }).ToList();
            // En başta "Rolü Seçiniz" alanı gelsin ama kullanıcı bu seçeneği seçemesin (disabled)
            Admin.Insert(0, new SelectListItem { Text = "Rolü Seçiniz", Value = "", Disabled = true, Selected = true });
            ViewBag.tasi = Admin;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }


        //Admin Güncelleme
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {

            List<SelectListItem>Admin=(from  x in am.GetList()
                                       select new SelectListItem
                                       {
                                           Value=x.AdminRole,
                                           Text = x.AdminRole,
                                       }).ToList();
            Admin.Insert(0, new SelectListItem { Text = "Rolü Seçiniz", Value = "", Disabled = true, Selected = true });
            ViewBag.tasi = Admin;

            var values = am.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            //CategoryValidator category2 = new CategoryValidator();
            //ValidationResult result = category2.Validate(category);
            //if (result.IsValid)
            //{
            //    cm.UpdateCategory(category);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)//hataları göster 
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//propert-->veritabanındaki stun adları kategoriname,categorydescription..

            //    }
            //}
            //return View();

            am.UpdateAdmin(admin);
            return RedirectToAction("Index");

        }
    }
}