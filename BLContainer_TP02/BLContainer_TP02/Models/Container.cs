using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLContainer_TP02.Models
{
    public class Container
    {
        public int Id { get; set; }
        //[Index(IsUnique = true)]
//        [StringLength(12)]

        public string Numero { get; set;}
        public string Tipo { get; set; }
        public int Tamanho { get; set; }

        public int? BLId { get; set; }
        public BL Bl { get; set; }
    }
}