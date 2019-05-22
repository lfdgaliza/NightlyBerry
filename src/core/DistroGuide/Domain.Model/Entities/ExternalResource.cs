namespace DistroGuide.Domain.Model.Entities
{
    public class ExternalResource
    {
        public string Id { get; set; }
        public string TargetId { get; set; }
        public char TargetType { get; set; }
        public string Resource { get; set; }
        public bool IsPrincipal { get; set; }

        public string ExternalResourceTypeId { get; set; }
        public ExternalResourceType ExternalResourceType { get; set; }
    }
}