namespace BusinessLayer.CQRS.Results.GuideResults
{
    public class GetByIdGuideResult
    {
        public int GuideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
