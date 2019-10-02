using BLBL_TP02.DAO;
using BLContainer_TP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLBL_TP02.Controllers
{
    public class BLController : Controller
    {
        // GET: BL
        public ActionResult Index()
        {
            BLDAO dao = new BLDAO();
            IList<BL> BLs = dao.Lista();

            ViewBag.BLs = BLs;
            return View();
        }
        public ActionResult Form()
        {
            ViewBag.BL = new BL();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(BL BL)
        {
            return View();
        }
    }
}