using System.Collections.Generic;

namespace DistroGuide.Domain.Model.Entities
{
    public class Resource
    {
        public string Id { get; set; }
        public string Classification { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public HashSet<ResourceTranslation> ResourceTranslations { get; set; }
        public HashSet<ExternalResourceType> ExternalResourceTypes { get; set; }
    }
}