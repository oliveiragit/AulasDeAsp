using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLContainer_TP02.Models
{
    public class Container
    {
        public int Id { get; set; }
        //
        [StringLength(12)]
        [Index(IsUnique = true)]
        public string Numero { get; set;}
        public string Tipo { get; set; }
        public int Tamanho { get; set; }

        public int? BLId { get; set; }
        public BL Bl { get; set; }
    }
}