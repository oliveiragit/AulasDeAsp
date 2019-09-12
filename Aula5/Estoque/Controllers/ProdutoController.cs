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
            ProdutoDAO dao = new ProdutoDAO();
           // dao.Adiciona(new Produto { Nome = "SASA", Categoria = new CategoriaDoProduto { Nome = "ao", Descricao = "Disabou", Id = 2 }, CategoriaId = 2, Id = 2, Descricao = "O melhor", Preco = 2134.23F, Quantidade = 32 });
            IList<Produto> produtos = dao.Lista();

            ViewBag.Produtos = produtos;
            return View();
        }
        public ActionResult Form()
        {
            CategoriaDAO dao = new CategoriaDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        //  [HttpPostAttribute] //Forma completa
        //Forma permitida, por convenção todos os metodos que possuem attribute pode ser encurtados
        // public ActionResult Adiciona(string nome, float preco, int quantidade, string descricao, int categoriaId) // Para GET
        [HttpPost]
        public ActionResult Adiciona (Produto produto)
        {
           /* Produto produto = new Produto()
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                Descricao = descricao,
                CategoriaId = categoriaId
            };*/

            ProdutoDAO dao = new ProdutoDAO();
            dao.Adiciona(produto);

            return RedirectToAction("Index");
        }
            
    }
}
