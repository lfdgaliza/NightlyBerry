using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    public class Orbiter
    {
        public string Name { get; private set; }
        public int Position { get; private set; }
        public Orbiter Parent { get; set; }
        public List<Orbiter> Children { get; private set; }
        private List<Orbiter> Neighbors { get { return Parent == null ? null : Parent.Children; } }

        public double GetSize(double starSize, double factor)
        {
            if (Parent == null)
                return starSize;

            return Parent.GetSize(starSize, factor) * factor;
        }

        private double GetBiggestChildRadius(double starSize, double factor)
        {
            if (Children.Any())
            {
                var childWithBiggestPosition = Children.First(c => c.Position == Children.Max(m => m.Position));
                var childRadius = childWithBiggestPosition.GetOrbitRadius(starSize, factor);
                return childRadius;
            }

            return 0;
        }

        public double GetOrbitRadius(double starSize, double factor)
        {
            if (Parent == null) return 0;

            var mySize = GetSize(starSize, factor);
            var parentSize = Parent.GetSize(starSize, factor);

            // 1.2 = 20%
            var radius = (Position * mySize * 1.2) + parentSize;

            if (Position > 1)
            {
                var previousOrbiter = Neighbors.First(n => n.Position == Position - 1);
                var normalGrowth = (previousOrbiter.GetOrbitRadius(starSize, factor) + mySize * 1.2);
                radius = normalGrowth + previousOrbiter.GetBiggestChildRadius(starSize, factor);
            }

            radius += GetBiggestChildRadius(starSize, factor);

            return radius;
        }

        public Orbiter(string name)
        {
            Name = name;
            Position = 1;
            Children = new List<Orbiter>();
        }

        public void Add(Orbiter child)
        {
            child.Parent = this;
            child.Position = Children.Count + 1;
            Children.Add(child);
        }
    }
}