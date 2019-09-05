using Estoque.DAO;
using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> Produtos = dao.Lista();
            ViewBag.Produtos = Produtos;
            return View();
        }
    }
}