namespace DistroGuide.Domain.Model.Entities
{
    public class Translation
    {
        public string Id { get; set; }
        public string Module { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Value { get; set; }
    }
}
