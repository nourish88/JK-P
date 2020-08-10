﻿using Core.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class IhbarModel : RecordBase
    {
        [Required]
        [DisplayName("İhbar Durumu")]
        public int? IhbarDurumuId { get; set; }

        [Required]
        [StringLength(4000)]
        [DisplayName("Özet")]
        public string Ozet { get; set; }

        [Required]
        [StringLength(2000)]
        public string Yer { get; set; }

        [Required]
        public DateTime? Tarih { get; set; }

        public string TarihText { get; set; }

        public string IhbarDurumu { get; set; }

        public List<int> OlayIdleri { get; set; }
    }
}
