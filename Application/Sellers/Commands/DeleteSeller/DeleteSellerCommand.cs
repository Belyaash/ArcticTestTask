using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
