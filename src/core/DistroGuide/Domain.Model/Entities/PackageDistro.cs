namespace DistroGuide.Domain.Model.Entities
{
    public class PackageDistro
    {
        public string Id { get; set; }
        public string DistroId { get; set; }
        public string PackageId { get; set; }
        public bool IsOficial { get; set; }
        public bool IsPrincipal { get; set; }
    }
}