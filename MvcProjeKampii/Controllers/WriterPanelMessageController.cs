using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidators = new MessageValidator();
      

        //Gelen Kutusu-Gönderilen Mesajlar... tuttuğumuz yer.(AdminContact vardı aynısı)
        public PartialViewResult GetWriterDetailsPartial()
        {
            return PartialView();
        }

        //Gelen(reciever) Mesajları Listeleme
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık(normalde manager kısmında elle giriyorduk.sessiona atayıp bundan kurtulmuş olduk.
            var values = mm.GetListInbox(p);//Bu methot burak@gmail.com gelen maillleri listeliyor.
            return View(values);
        }

        //Gönderilen(send) Mesajları Listeleme
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık(normalde manager kısmında elle giriyorduk.sessiona atayıp bundan kurtulmuş olduk.
            var values = mm.GetListSendbox(p);//Bu methot burak@gmail.com gelen maillleri listeliyor.
            return View(values);
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


        //Yeni Mesaj Gönderme
        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık(normalde manager kısmında elle giriyorduk.sessiona atayıp bundan kurtulmuş olduk.
            ValidationResult result = messageValidators.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());//Günün Kısa Tarihi.
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




   




    }
}