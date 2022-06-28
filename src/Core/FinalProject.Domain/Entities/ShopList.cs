using FinalProject.Domain.Entities.Common;


namespace FinalProject.Domain.Entities
{
    public class ShopList : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
