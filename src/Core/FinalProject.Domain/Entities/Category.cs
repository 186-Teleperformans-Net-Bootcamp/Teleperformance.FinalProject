using FinalProject.Domain.Entities.Common;


namespace FinalProject.Domain.Entities
{
    public class Category : BaseEntity
    {
        public ICollection<Product> Products { get; set; }

    }
}
