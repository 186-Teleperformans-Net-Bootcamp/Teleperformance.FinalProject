using FinalProject.Domain.Entities.Common;
using FinalProject.Domain.Entities.Enums;


namespace FinalProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public float Quantity { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public bool IsPurchased { get; set; }
    }
}
