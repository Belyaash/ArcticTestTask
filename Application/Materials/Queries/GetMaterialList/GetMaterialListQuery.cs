﻿using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Materials.Queries.GetMaterialList
{
    public class GetMaterialListQuery: IRequest<List<Material>>
    {
    }
}
