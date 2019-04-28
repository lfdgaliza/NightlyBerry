using System;
using System.Collections.Generic;

namespace DistroGuide.Domain.Dto
{
    public class TreeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TreeDto> Children { get; set; }
    }
}
