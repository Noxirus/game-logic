// See https://aka.ms/new-console-template for more information
using GameCalculator;
using System.Windows;

Vector2 a = new Vector2(float.MaxValue, float.MaxValue);
Vector2 b = new Vector2(float.MaxValue, float.MaxValue);

Vector2 c = a + b;

Console.WriteLine(c.ToString());