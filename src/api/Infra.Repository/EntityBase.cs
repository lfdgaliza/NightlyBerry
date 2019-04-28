using System;
namespace DistroGuide.Infra.Repository
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
