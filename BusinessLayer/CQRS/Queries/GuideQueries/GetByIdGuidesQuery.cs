using BusinessLayer.CQRS.Results.GuideResults;
using MediatR;

namespace BusinessLayer.CQRS.Queries.GuideQueries
{
    public class GetByIdGuidesQuery : IRequest<GetByIdGuideResult>
    {
        public int Id { get; set; }
    }
}
