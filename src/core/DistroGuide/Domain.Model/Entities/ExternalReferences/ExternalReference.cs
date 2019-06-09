using CrossCutting.Infra.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.ExternalReferences
{
    public class ExternalReference : BaseEntity
    {
        [MaxLength(250)]
        public string Reference { get; set; }
        public bool IsPrincipal { get; set; }

        public Guid ExternalReferenceTypeId { get; set; }
        public ExternalReferenceType ExternalReferenceType { get; set; }

        public Guid TargetId { get; set; }
    }
}