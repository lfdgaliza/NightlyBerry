using System.Collections.Generic;

namespace DistroGuide.Domain.Services.Dto
{
    public class TranslationBundleDto
    {
        public int Version { get; set; }
        public List<TranslationGroupDto> TranslationGroupList { get; set; }
    }

    public class TranslationGroupDto
    {
        public string Name { get; set; }
        public Dictionary<string, string> Items { get; set; }
    }
}
