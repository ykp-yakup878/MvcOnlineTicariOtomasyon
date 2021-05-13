using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name ="Personel Ad")]
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersoneAd { get; set; }

        [Display(Name = "Personel Soyad")]
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersoneSoyad { get; set; }

        [Display(Name = "Personel Görsel")]
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string PersoneGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}