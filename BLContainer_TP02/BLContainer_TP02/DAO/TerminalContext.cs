using BLContainer_TP02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BLContainer_TP02.DAO
{
    public class TerminalContext: DbContext
    {
        public DbSet<Container> Containers { get; set; }
        public DbSet<BL> BLs { get; set; }
        public object Bls { get; internal set; }
    }
}