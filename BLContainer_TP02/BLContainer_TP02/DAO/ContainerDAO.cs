﻿using BLContainer_TP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  BLContainer_TP02.DAO
    {
    public class ContainerDAO
    {
        public void Adiciona(Container container)
        {
            using (var context = new TerminalContext())
            {
                context.Containers.Add(container);
                context.SaveChanges();
            }
        }
        public IList<Container> Lista()
        {
            using (var contexto = new TerminalContext())
            {
                return contexto.Containers.Include("BLId").ToList();
            }
        }
        public Container BuscaPorId(int id)
        {
            using (var contexto = new TerminalContext())
            {
                return contexto.Containers.Include("BLId")
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
            }
        }
        public void Atualiza(Container container)
        {
            using (var contexto = new TerminalContext())
            {
                contexto.Entry(container).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}