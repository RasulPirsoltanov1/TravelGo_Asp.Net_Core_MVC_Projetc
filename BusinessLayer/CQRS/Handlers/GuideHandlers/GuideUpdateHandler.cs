using BusinessLayer.Abstract;
using BusinessLayer.CQRS.Commands.GuideCommands;
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
    public class GuideUpdateHandler : IRequestHandler<UpdateGuideCommand, GuideUpdateResult>
    {
        IGuideService _guideService;

        public GuideUpdateHandler(IGuideService guideService)
        {
            this._guideService = guideService;
        }

        public async Task<GuideUpdateResult> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            Guide guide = _guideService.TGetById(request.GuideId);
            if (guide != null)
            {
                guide.Name = request.Name;
                guide.Description = request.Description;
                guide.Image = request.Image;
                _guideService.TUpdate(guide);
            }
            GuideUpdateResult guideUpdateResult = new GuideUpdateResult();
            guideUpdateResult.Issuccess = true;
            return guideUpdateResult;
        }
    }
}
