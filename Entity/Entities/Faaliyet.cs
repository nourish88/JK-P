using System;
using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Entity.Entities
{
    public class Faaliyet : RecordBase
    {
        public int IhbarId { get; set; }
        public Ihbar Ihbar { get; set; }
        public int IslemDurumuId { get; set; }
        public IslemDurumu IslemDurumu { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

        [Required]
        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }

        [Required]
        public string Yer { get; set; }
    }
}
