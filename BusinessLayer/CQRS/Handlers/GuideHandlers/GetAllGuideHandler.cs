using BusinessLayer.Abstract;
using BusinessLayer.CQRS.Queries.GuideQueries;
using BusinessLayer.CQRS.Results.GuideResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideHandler : IRequestHandler<GetAllGuidesQuery, List<GetAllGuideResult>>
    {
        private IGuideService _guideService;

        public GetAllGuideHandler(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public async Task<List<GetAllGuideResult>> Handle(GetAllGuidesQuery request, CancellationToken cancellationToken)
        {
            return _guideService.TGetList().Select(g=>new GetAllGuideResult
            {
                Description=g.Description,
                GuideId=g.GuideId,
                Image=g.Image,
                Name = g.Name
            }).ToList();
        }
    }
}
