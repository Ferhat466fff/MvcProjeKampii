using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skl = new SkillManager(new EFSkillDal());
        public ActionResult Index()
        {
            var skillValue = skl.GetSkills();
            return View(skillValue);
        }
    }
}