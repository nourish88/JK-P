using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Entity.Entities
{
    public class IhbarDurumu : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        public List<Ihbar> Ihbarlar { get; set; }
    }
}
