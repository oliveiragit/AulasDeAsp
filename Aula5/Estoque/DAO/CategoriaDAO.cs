using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estoque.DAO
{
    public class CategoriaDAO
    {
        public void Adiciona(CategoriaDoProduto categoria)
        {
            using (var context = new EstoqueContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();

            }
        }
        public IList<CategoriaDoProduto> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Categorias.Include("Categoria").ToList();
            }
        }
        public CategoriaDoProduto BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Categorias.Include("Categoria")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }
        public void Atualiza(CategoriaDoProduto Categoria)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(Categoria).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
   
} 