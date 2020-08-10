using Core.Records.Bases;

namespace Entity.Entities
{
    public class PersonelIhbar : RecordBase
    {
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int IhbarId { get; set; }
        public Ihbar Ihbar { get; set; }
    }
}
