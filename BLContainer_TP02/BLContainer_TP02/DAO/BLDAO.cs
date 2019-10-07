using BLContainer_TP02.DAO;
using BLContainer_TP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLBL_TP02.DAO
{
    public class BLDAO
    {
        public void Adiciona(BL bl)
        {
            using (var context = new TerminalContext())
            {
                context.BLs.Add(bl);
                context.SaveChanges();
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
                    .Where(bl => bl.Id == id)
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
                var bl = contexto.BLs.Single(b => b.Id == id);
                contexto.BLs.Remove(bl);
                contexto.SaveChanges();
            }
        }
    }
}