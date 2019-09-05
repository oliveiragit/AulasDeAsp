using Estoque.DAO;
using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriaDAO dao = new CategoriaDAO();
            IList<CategoriaDoProduto> Categorias = dao.Lista();
            ViewBag.Categorias = Categorias;
            return View();
        }
    }
}