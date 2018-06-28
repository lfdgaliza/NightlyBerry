using System;
using System.Collections.Generic;
using System.Text;

namespace NB.Shared.BasicClasses.Category
{
    public class CategoryComposite : CategoryBase
    {
        private List<CategoryBase> _childItems;
        public CategoryComposite(string name, int id)
        {
            Name = name;
            Id = id;
            _childItems = new List<CategoryBase>();
        }

        public void Add(CategoryBase c)
        {
            c.Parent = this;
            _childItems.Add(c);
        }
        public void Remove(CategoryBase c) => this._childItems.Remove(c);
    }
}
