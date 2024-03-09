namespace Xpense.domain.Common
{
    public class AuditEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public string CreatedBy { get; set; }
    }
}
