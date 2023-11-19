using MediatR;

namespace Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
