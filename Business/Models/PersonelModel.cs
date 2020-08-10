using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Business.Models
{
    public class PersonelModel : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Isim { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyisim { get; set; }

        public string IsimSoyisim => Isim + " " + Soyisim;
    }
}
