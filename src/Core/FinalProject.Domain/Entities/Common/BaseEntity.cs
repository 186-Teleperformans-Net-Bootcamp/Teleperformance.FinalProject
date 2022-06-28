

namespace FinalProject.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}
