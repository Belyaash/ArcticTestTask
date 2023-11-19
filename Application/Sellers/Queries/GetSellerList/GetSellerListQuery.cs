using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sellers.Queries.GetSellerList
{
    public class GetSellerListQuery: IRequest<List<Seller>>
    {
    }
}
