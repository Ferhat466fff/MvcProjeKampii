using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    [AllowAnonymous]//Erişim İzni verdim.Bu sayede buraya erişebileceğiz.
    public class VitrinController : Controller
    {
        
        public ActionResult HomePage()
        {
            return View();
        }
    }
}