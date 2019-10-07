using BLBL_TP02.DAO;
using BLContainer_TP02.DAO;
using BLContainer_TP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLContainer_TP02.Controllers
{
    public class ContainerController : Controller
    {
        // GET: Container
        public ActionResult Index()
        {
            ContainerDAO dao = new ContainerDAO();
            IList<Container> containers = dao.Lista();
            return View(containers);

        }
        public ActionResult Form()
        {
            BLDAO blDAO = new BLDAO();
            ViewBag.BLs = blDAO.Lista();
            ViewBag.Container = new Container();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Container Container)
        {
            ContainerDAO dao = new ContainerDAO();
            dao.Adiciona(Container);
            return RedirectToAction("Index");
        }
        [Route("bls/{id}")]
        public ActionResult BLContainer(int id)
        {
            BLDAO bldao = new BLDAO();

            return View(bldao.BuscaPorId(id));
        }

        [Route("Apagar/{id}", Name="ApagarContainer")]
        public ActionResult Apagar(int id)
        {
            ContainerDAO dao = new ContainerDAO();
            dao.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}