using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Business.Models
{
    public class OlayModel : RecordBase
    {
        [DisplayName("İlk Neden")]
        [StringLength(4000)]
        public string IlkNeden { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        [DisplayName("Oluş Şekli")]
        [StringLength(4000)]
        public string OlusSekli { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        [StringLength(2000)]
        public string Yer { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        public DateTime? Tarih { get; set; }

        public string TarihText { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")] 
        public string Saat { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        public string Dakika { get; set; }

        public string Zaman { get; set; }

        [DisplayName("Sıra")]
        public int Sira { get; set; }

        public int? IhbarId { get; set; }

        [DisplayName("İhbar Özeti")] 
        public string IhbarOzeti { get; set; }

        [DisplayName("İhbarlar")]
        public List<int> IhbarIdleri { get; set; }

        [DisplayName("İhbarlar")]
        public List<string> IhbarOzetleri { get; set; }
    }
}
