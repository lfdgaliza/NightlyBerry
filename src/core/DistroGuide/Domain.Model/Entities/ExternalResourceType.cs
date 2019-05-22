namespace DistroGuide.Domain.Model.Entities
{
    public class ExternalResourceType
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public string ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}