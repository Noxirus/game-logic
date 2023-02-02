// See https://aka.ms/new-console-template for more information
using GameCalculator;
using System.Windows;

Vector2 a = new Vector2(0, 0);
Vector2 b = new Vector2(5, 5);

float length = VectorCalculator.LengthBetweenTwoVectors(a, b);

Console.WriteLine(length);