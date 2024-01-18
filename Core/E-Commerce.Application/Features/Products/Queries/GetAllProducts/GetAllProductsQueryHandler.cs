using E_Commerce.Application.Interfaces.UnitOfWorks;
using E_Commerce.Domain.Entities;
using MediatR;

namespace E_Commerce.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest,IList<GetAllProductsQueryResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;   
        }


        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAllAsync();

            List<GetAllProductsQueryResponse> responses = new();
            foreach (var product in products)
                responses.Add(new GetAllProductsQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price - (product.Price * product.Discount / 100),
                });
            return responses;
        }








    }
}
