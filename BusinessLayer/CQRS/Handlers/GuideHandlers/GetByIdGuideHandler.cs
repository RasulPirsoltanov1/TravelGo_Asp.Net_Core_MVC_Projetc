using BusinessLayer.Abstract;
using BusinessLayer.CQRS.Queries.GuideQueries;
using BusinessLayer.CQRS.Results.GuideResults;
using EntityLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.GuideHandlers
{
    public class GetByIdGuideHandler : IRequestHandler<GetByIdGuidesQuery, GetByIdGuideResult>
    {
        IGuideService _guideService;
        public GetByIdGuideHandler(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public async Task<GetByIdGuideResult> Handle(GetByIdGuidesQuery request, CancellationToken cancellationToken)
        {
            Guide guide = _guideService.TGetById(request.Id);
            return new GetByIdGuideResult
            {
               Description=guide.Description,
               GuideId=guide.GuideId,   
               Image=guide.Image,
               Name = guide.Name
            };
        }
    }
}
