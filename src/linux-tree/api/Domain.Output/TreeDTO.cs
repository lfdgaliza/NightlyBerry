using System.Collections.Generic;

namespace NightlyBerry.LinuxTree.Domain.Output
{
    public class TreeDTO
    {
        public string Name { get; set; }
        public List<TreeDTO> Children { get; set; }
    }
}
