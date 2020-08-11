using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Entity.Entities
{
    public class Ihbar : RecordBase
    {
        public int IhbarDurumuId { get; set; }
        public IhbarDurumu IhbarDurumu { get; set; }

        [Required]
        public string Ozet { get; set; }

        [Required]
        public string Yer { get; set; }

        public DateTime Tarih { get; set; }

        public List<OlayIhbar> OlayIhbarlar { get; set; }
        public List<Faaliyet> Faaliyetler { get; set; }
    }
}
