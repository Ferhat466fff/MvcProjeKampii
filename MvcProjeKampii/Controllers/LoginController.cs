using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampii.Controllers
{
  
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();//context-->Tüm entitiylerimizin bulunuğu sınıf.
            var user=c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.AdminPassword == p.AdminPassword);
            //Veri tabanındaki kullanıcı adı ve şifre parametredekine(kullanıcının gireceği veriler) eşitse giriş yapacak.
            if (user != null)   // Giriş başarılıysa
            {
                FormsAuthentication.SetAuthCookie(user.UserName,false);//Cookie -->Kullanıcının Giriş Yapıp Yapmadığını Göstermek İçin Kullandk.
                Session["UserName"] = user.UserName;//Kullanıcı adını oturum boyunca saklar.
                return RedirectToAction("Index", "AdminCategory");
            }
            else // Hatalı giriş
            { 
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
          
        }
    }
}