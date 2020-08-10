using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Entity.Entities
{
    public class Rol : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        public List<Kullanici> Kullanicilar { get; set; }
    }
}
