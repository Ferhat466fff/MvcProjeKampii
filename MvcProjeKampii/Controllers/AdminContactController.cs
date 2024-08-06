using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator validator=new ContactValidator();
        MessageManager mm = new MessageManager(new EFMessageDal());
        public ActionResult Index()
        {
            
            var values = cm.GetList();
            return View(values);
        }
        //İletişim Detaylarını getirme.
        public ActionResult GetContactDetails(int id)
        {
          
            var values =cm.GetByID(id);
            return View(values);
        }

        public PartialViewResult GetContactDetailsPartial()//Üstteki  viewin Bir kısmını partiala aldım
        {
            ViewBag.ContactCount = cm.GetContactCount();//toplam iletişimdeki kişi saysısı
            TempData["SendboxMessageCount"] = mm.GetSendboxMessageCount();//Göndeilen Mesaj Sayısı
            TempData["GetReciverMessageCount"] = mm.GetReciverMessageCount();//gelen mesajların sayısı
            return PartialView();
        }

        //Okundu-Okunmadı(İletişim Kısmına)
        public ActionResult IsRead(int id)
        {
            cm.ToggleReadStatus(id);
            return RedirectToAction("Index");
        }





    }
}