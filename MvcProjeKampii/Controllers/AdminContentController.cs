using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
     
        public ActionResult Index()
        {
            return View();
        }

        //Aradığımız Şeye göre listeleme yapma.
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);//getlist methodunu incele.
            if(p == null )
            {
                return View(cm.GetList(""));//boşsa tümü gelsin
            }
            return View(values);//p nullsa tüm değerleri göster.
        }

        //Başlığın Id göre içeriğini getirme
        public ActionResult ContentByHeadingg(int id)
        {
            var contentvalues = cm.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}