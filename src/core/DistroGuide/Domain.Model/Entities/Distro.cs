using System;
using System.Collections.Generic;

namespace DistroGuide.Domain.Model.Entities
{
    public class Distro
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string IconUrl { get; set; }

        public string BasedOnId { get; set; }
        public Distro BasedOn { get; set; }

        public HashSet<Distro> Children { get; set; }
        public HashSet<ExternalResource> ExternalResources { get; set; }    
    }
}
