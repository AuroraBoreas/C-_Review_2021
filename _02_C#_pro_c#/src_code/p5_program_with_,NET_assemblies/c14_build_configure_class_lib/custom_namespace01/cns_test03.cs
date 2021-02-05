using System;
using MyShapes;
using My3DShapes;

// resolve the ambiguity using a custom alias
using The3DHexagon = My3DShapes.Hexagon;

namespace CustomNamespaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Circle c1 = new Circle();    // <-- name clash
            // Hexagon h1 = new Hexagon();  // <-- name clash
            // Square s1 = new Square();    // <-- name clash

            My3DShapes.Circle c = new My3DShapes.Circle();  // OK
            The3DHexagon h = new The3DHexagon();  // OK
            My3DShapes.Square s = new My3DShapes.Square();  // OK


        }
    }
}