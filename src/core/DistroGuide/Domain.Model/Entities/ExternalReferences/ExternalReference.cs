using CrossCutting.Infra.Entities;
using DistroGuide.Domain.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.ExternalReferences
{
    public class ExternalReference : BaseEntity
    {
        [MaxLength(250)]
        public string Reference { get; set; }
        public bool IsPrincipal { get; set; }
        public ExternalReferenceType ExternalReferenceType { get; set; }

        public Guid TargetId { get; set; }
    }
}