using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCalculator
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float length => MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2));
        
        public Vector2 normalized =>  this / length;


        public static Vector2 operator +(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x + second.x, first.y + second.y);
        }

        public static Vector2 operator -(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x - second.x, first.y - second.y);
        }

        public static Vector2 operator *(Vector2 vector, float value)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator *(float value, Vector2 vector)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator /(Vector2 vector, float value)
        {
            return new Vector2(vector.x / value, vector.y / value);
        }

        public override string ToString()
        {
            return "X: " + x.ToString("0.00") + " / Y: " + y.ToString("0.00");
        }
    }

    public static class VectorCalculator
    {
        public static float LengthBetweenTwoVectors(Vector2 first, Vector2 second)
        {
            Vector2 displacementVector = second - first;

            float length = displacementVector.length;

            return length;
        }

        public static float DotProduct(Vector2 first, Vector2 second)
        {
            return first.x * second.x + first.y * second.y;
        }

        public static Vector2 Reflection(Vector2 ray, Vector2 normal)
        {
            return ray - 2 * (DotProduct(ray, normal.normalized) * normal.normalized);
        }
    }
}
