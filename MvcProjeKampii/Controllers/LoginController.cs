using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampii.Controllers
{
    [AllowAnonymous]//Erişim İzni verdim.Bu sayede buraya erişebileceğiz.
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EFWriterDal());
        AdminLoginManager am = new AdminLoginManager(new EFAdminDal());


        //Admin Girişi
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();//context-->Tüm entitiylerimizin bulunuğu sınıf.      
            var user = am.GetAdmin(p.UserName, p.AdminPassword);//GetWritermanager methoduna bak.
            if (user != null)   // Giriş başarılıysa
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);//Cookie -->Kullanıcının Giriş Yapıp Yapmadığını Göstermek İçin Kullandk.
                Session["UserName"] = user.UserName;//Kullanıcı adını oturum boyunca saklar.
                Session["Image"] = user.WriterImage;
                return RedirectToAction("Index", "AdminCategory");
            }
            else // Hatalı giriş
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }

        }


        //Yazar Girişi
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();//context-->Tüm entitiylerimizin bulunuğu sınıf. 
            var user = wm.GetWriter(p.WriterMail,p.WriterPassword);//GetWritermanager methoduna bak.
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.WriterMail, false);
                Session["WriterMail"] = user.WriterMail;
                Session["WriterName"] = user.WriterName;//bunları WriterLayout Giriş yapınca ismi resmi gelsin diye yapıyorum.
                Session["WriterSurname"] = user.WriterSurName;
                Session["WriterImage"] = user.WriterImage;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else // Hatalı giriş
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }

        }



        //Çıkış Yap
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();//Oturumu Sonlandır.(Sisteme giren kullanıcının yetkilerini alıyor)
            return RedirectToAction("Headings", "Default");
        }
    }
}