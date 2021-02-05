using System;
using MyShapes;
using My3DShapes;

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
            My3DShapes.Hexagon c = new My3DShapes.Hexagon();  // OK
            My3DShapes.Square c = new My3DShapes.Square();  // OK


        }
    }
}