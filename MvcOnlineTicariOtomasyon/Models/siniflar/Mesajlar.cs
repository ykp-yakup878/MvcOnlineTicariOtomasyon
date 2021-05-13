using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public String Gonderen { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public String Alici { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public String Konu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(3000)]
        public String Icerık { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }
    }
}