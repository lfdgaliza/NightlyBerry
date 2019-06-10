using CrossCutting.Infra.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.Resources
{
    public class ResourceTranslation : BaseEntity
    {
        [MaxLength(5)]
        public string Language { get; set; }
        [MaxLength(250)]
        public string Translation { get; set; }

        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}