using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcProjeKampii.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();//burayı buisnes-validationrules içerisinde açtık.

        [Authorize]
        //Alınan Mesajalr
        public ActionResult Inbox()
        {
            var p = "admin@gmail.com";
            var values = mm.GetListInbox(p);
            return View(values);
           
        }
        // Gönderilen Mesajlar
        public ActionResult Sendbox()
        {
            var p = "admin@gmail.com";
            var values = mm.GetListSendbox(p);
            return View(values);
         
        }

        //Yeni Mesaj Gönderme
        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult AddNewMessage(EntitiyLayer.Concrete.Message p)
        {
            // `messagevalidator` nesnesi üzerinden `Validate` yöntemini çağırın
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate= DateTime.Parse(DateTime.Now.ToShortDateString());//Günün Kısa Tarihi.
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }






        //Gelen Mesajların Detaylarını getirme(gmail üzerine tıklandığı zaman).
        public ActionResult GetInBoxMessageDetails(int id)
        {

            var values = mm.GetByID(id);
            return View(values);
        }

        //Gönderilen Mesajların Detaylarını getirme(gmail üzerine tıklandığı zaman).
        public ActionResult GetSendboxMessageDetails(int id)
        {

            var values = mm.GetByID(id);
            return View(values);
        }



        //okundu-okunmadı özelliği(Gelen Kutusu)
        public ActionResult IsRead(int id)
        {
            mm.ToggleReadStatus(id);
            return RedirectToAction("Inbox");
        }

       














    }
}
