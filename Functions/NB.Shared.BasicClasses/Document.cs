using NB.Shared.BasicClasses.Category;
using NB.Shared.BasicClasses.Enum;
using System;

namespace NB.Shared.BasicClasses
{
    public class Document : CategoryLeaf
    {
        public string Content { get; set; }
        public DocumentType DocumentType { get; set; }
        public Language Language { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}   
