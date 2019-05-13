using System;
using System.Collections.Generic;
using System.Linq;

namespace DistroGuide.App_Domain.Repository.Entities
{
    public class Distro
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HomePage { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string IconUrl { get; set; }

        public string BasedOnId { get; set; }
        public Distro BasedOn { get; set; }

        public IQueryable<Distro> Children { get; set; }
    }
}