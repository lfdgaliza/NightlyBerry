using System;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var mercury = new Orbiter("Mercury");
            var venus = new Orbiter("Venus");

            var satellite1 = new Orbiter("Satellite 1");
            var satellite2 = new Orbiter("Satellite 2");
            var earth = new Orbiter("Earth");
            earth.Add(satellite1);
            earth.Add(satellite2);

            var mars = new Orbiter("Mars");
            var jupiter = new Orbiter("Jupiter");

            var sun = new Orbiter("Sun");
            sun.Add(mercury);
            sun.Add(venus);
            sun.Add(earth);
            sun.Add(mars);
            sun.Add(jupiter);

            const double starSize = 5;
            const double factor = .5;

            Console.WriteLine("Size --------------------------------------------");
            Console.WriteLine($"Sun: {sun.GetSize(starSize, factor)}");
            Console.WriteLine($"Mercury: {mercury.GetSize(starSize, factor)}");
            Console.WriteLine($"Venus: {venus.GetSize(starSize, factor)}");
            Console.WriteLine($"Earth: {earth.GetSize(starSize, factor)}");
            Console.WriteLine($"Satellite 1: {satellite1.GetSize(starSize, factor)}");
            Console.WriteLine($"Satellite 2: {satellite2.GetSize(starSize, factor)}");
            Console.WriteLine($"Mars: {mars.GetSize(starSize, factor)}");
            Console.WriteLine($"Jupiter: {jupiter.GetSize(starSize, factor)}");


            Console.WriteLine("Radius ------------------------------------------");

            Console.WriteLine("SUN" + new string('+', (int)sun.GetOrbitRadius(starSize, factor)));
            Console.WriteLine("MER" + new string('+', (int)mercury.GetOrbitRadius(starSize, factor)));
            Console.WriteLine("VEN" + new string('+', (int)venus.GetOrbitRadius(starSize, factor)));
            Console.WriteLine("EAR" + new string('+', (int)earth.GetOrbitRadius(starSize, factor)));
            //Console.WriteLine("SA1" + new string('+', (int)satellite1.GetOrbitRadius(starSize, factor)));
            //Console.WriteLine("SA2" + new string('+', (int)satellite2.GetOrbitRadius(starSize, factor)));
            Console.WriteLine("MAR" + new string('+', (int)mars.GetOrbitRadius(starSize, factor)));
            Console.WriteLine("JUP" + new string('+', (int)jupiter.GetOrbitRadius(starSize, factor)));

            Console.ReadKey();
        }
    }
}
