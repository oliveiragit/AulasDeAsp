using BLContainer_TP02.DAO;
using BLContainer_TP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLContainer_TP02.DAO
{
    public class BLDAO
    {
        public void Adiciona(BL bl)
        {
            using (var context = new TerminalContext())
            {
                if (BuscaPorId(bl.Id) == null)
                {
                    context.BLs.Add(bl);
                    context.SaveChanges();
                }
                else
                    Atualiza(bl);

            }
        }
        public IList<BL> Lista()
        {
            using (var contexto = new TerminalContext())
            {
                return contexto.BLs.ToList();
            }
        }
        public BL BuscaPorId(int id)
        {
            using (var contexto = new TerminalContext())
            {
                return contexto.BLs
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
            }
        }
        public void Atualiza(BL bl)
        {
            using (var contexto = new TerminalContext())
            {
                contexto.Entry(bl).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        public void Apagar(int id)
        {
            using (var contexto = new TerminalContext())
            {
                var bl = contexto.BLs.Single(c => c.Id == id);
                var containers = contexto.Containers
                .Where(c => c.BLId == id);
                contexto.Containers.RemoveRange(containers);
                contexto.BLs.Remove(bl);
                contexto.SaveChanges();
            }
        }
    }
}