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
        public ActionResult Adiciona(Container container)
        {
            ContainerDAO dao = new ContainerDAO();
            dao.Adiciona(container);
            return RedirectToAction("Index");
        }
       

        [Route("Apagar/{numero}", Name ="ApagarContainer")]
        public ActionResult Apagar(int id)
        {
            ContainerDAO dao = new ContainerDAO();
            dao.Apagar(id);
            return RedirectToAction("Index");
        }
        [Route("Editar/{numero}", Name = "EditarContainer")]
        public ActionResult FormEdição(int id)
        {
            ContainerDAO dao = new ContainerDAO();
            Container ctn = dao.BuscaPorId(id);
            BLDAO bl = new BLDAO();
            ViewBag.BLs = bl.Lista();
            ViewBag.Container = ctn;
            return View();
        }
        [HttpPost]
        public ActionResult Editar(Container container)
        {
            ContainerDAO dao = new ContainerDAO();
            String n = container.Numero;
            dao.Atualiza(container);
            return RedirectToAction("Index");
        }
        [Route("Container/Detalhes/Numero", Name = "ContainerDetalhes")]
        public ActionResult Detalhes (int id)
        {
            ContainerDAO dao = new ContainerDAO();
            var container = dao.BuscaPorId(id);
            return View(container);
        }
    }
}

