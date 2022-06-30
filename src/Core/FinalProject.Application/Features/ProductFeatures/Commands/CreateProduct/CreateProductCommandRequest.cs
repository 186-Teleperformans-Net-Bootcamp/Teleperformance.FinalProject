using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities.Enums;
using MediatR;


namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public string CategoryId { get; set; }
    }
}
