using BusinessLayer.CQRS.Results.GuideResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries.GuideQueries
{
    public class GetAllGuidesQuery : IRequest<List<GetAllGuideResult>>
    {
    }
}
