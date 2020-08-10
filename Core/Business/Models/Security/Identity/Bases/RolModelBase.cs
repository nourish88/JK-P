using System.ComponentModel.DataAnnotations;
using Core.Records.Bases;

namespace Core.Business.Models.Security.Identity.Bases
{
    public abstract class RolModelBase : RecordBase
    {
        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        [StringLength(50)]
        public string Adi { get; set; }
    }
}
