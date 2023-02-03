// See https://aka.ms/new-console-template for more information
using GameCalculator;
using System.Windows;

Vector2 normal = new Vector2(1, 0);
Vector2 ray = new Vector2(-2, -1);

Console.WriteLine(VectorCalculator.Reflection(normal, ray));
Console.WriteLine("Ray Initially: " + ray.normalized.ToString());