namespace DistroGuide.Domain.Model.Entities
{
    public class ResourceTranslation
    {
        public string Id { get; set; }
        public string ResourceId { get; set; }
        public string Language { get; set; }
        public string Translation { get; set; }

        public Resource Resource { get; set; }
    }
}