using System;
using System.Collections.Generic;

namespace NightlyBerry.LinuxTree.Domain.Output
{
    public class TreeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TreeDTO> Children { get; set; }
    }
}
