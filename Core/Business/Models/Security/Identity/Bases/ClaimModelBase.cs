using Core.Records.Bases;

namespace Core.Business.Models.Security.Identity.Bases
{
    public abstract class ClaimModelBase : RecordBase
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
