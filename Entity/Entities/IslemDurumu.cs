using Core.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class IslemDurumu : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        public List<Faaliyet> Faaliyetler { get; set; }
    }
}
