using Core.Records.Bases;

namespace Entity.Entities
{
    public class OlayIhbar : RecordBase
    {
        public int OlayId { get; set; }
        public Olay Olay { get; set; }
        public int IhbarId { get; set; }
        public Ihbar Ihbar { get; set; }
        public int OlaySira { get; set; }
    }
}
