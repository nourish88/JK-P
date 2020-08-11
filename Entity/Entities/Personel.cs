using Core.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class Personel : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Isim { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyisim { get; set; }

        public List<Faaliyet> Faaliyetler { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
