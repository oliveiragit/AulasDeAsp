using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLContainer_TP02.Models
{
    public class BL
    {
        public int Id { get; set; }
//        [Index(IsUnique = true)]

        public string Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }
    }
}