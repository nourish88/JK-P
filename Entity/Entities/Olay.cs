using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Entity.Entities
{
    public class Olay : RecordBase
    {
        public string IlkNeden { get; set; }

        [Required]
        public string OlusSekli { get; set; }

        [Required]
        public string Yer { get; set; }

        public DateTime Tarih { get; set; }

        public List<OlayIhbar> OlayIhbarlar { get; set; }
    }
}
