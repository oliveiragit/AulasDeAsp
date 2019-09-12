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
            ViewBag.Produto = new Produto();
            CategoriaDAO dao = new CategoriaDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View(categorias);
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
           
                int IdInformática = 2;
            if(produto.CategoriaId.Equals(IdInformática)&& produto.Preco < 100)
            {
                ModelState.AddModelError("produto.informaticaComPrecoInvalido", "Categoria informática deve ter preço maior que 100");
            }

            //if (produto.Preco > 0 && produto.Preco < 5000 && produto.Quantidade > 0 && !String.IsNullOrEmpty(produto.Descricao)) //validação na Controler
            if (ModelState.IsValid) //validação na Model. É necessário utilizar Migration do Nuget se o banco foi criado com Entity FrameWork
            {
                ProdutoDAO dao = new ProdutoDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index");
            }
            else
            {
                CategoriaDAO catDAO = new CategoriaDAO();
                ViewBag.Categorias = catDAO.Lista();
                return RedirectToAction("Form");
            }
            
        }
            
    }
}
