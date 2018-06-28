namespace NB.Shared.BasicClasses.Category
{
    public abstract class CategoryBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryBase Parent { get; set; }
    }
}
