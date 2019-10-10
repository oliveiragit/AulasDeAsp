using BLContainer_TP02.DAO;
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
        public ActionResult Index()
        {
            BLDAO dao = new BLDAO();
            IList<BL> BLs = dao.Lista();

            ViewBag.BLs = BLs;
            return View();
        }
        public ActionResult Form(BL bl)
        {
            if(bl == null){
                ViewBag.BL = new BL();
            }
            else
            ViewBag.BL = bl;
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(BL BL)
        {
            BLDAO dao = new BLDAO();
            dao.Adiciona(BL);
            return RedirectToAction("Index");
        }

        [Route("BLs/{numero}", Name = "BLContainer")]
        public ActionResult BLContainer(int id)
        {
            BLDAO bldao = new BLDAO();
            ContainerDAO container = new ContainerDAO();
            ViewBag.Containers = container.BuscaPorBL(id);
            IList<BL> lista = new List<BL>();
            var bl = bldao.BuscaPorId(id);
            lista.Add(bl);
            return View(lista);
        }
        [Route("BLs/Apagar/{numero}", Name = "ApagarBL")]
        public ActionResult Apagar(int id)
        {
            BLDAO dao = new BLDAO();
            dao.Apagar(id);
            return RedirectToAction("Index");
        }
        [Route("BLs/Editar/{numero}", Name = "EditarBL")]
        public ActionResult FormEdição(int id)
        {
            BLDAO dao = new BLDAO();
            ViewBag.BL = dao.BuscaPorId(id);
            return RedirectToAction("Form", ViewBag.BL);
        }
        [HttpPost]
        public ActionResult Editar(BL bl)
        {
            BLDAO dao = new BLDAO();
            dao.Atualiza(bl);
            return RedirectToAction("Index");
        }
    }
}