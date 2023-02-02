using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCalculator;

namespace GameCalculatorTests
{
    [TestClass]
    public class Vector2DAlgebraTests
    {   
        [TestMethod]
        public void CorrectAdditionTest()
        {
            //Arrange
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(1, 1);
            Vector2 expected = new Vector2(2, 2);
            //Act
            Vector2 result = a + b;
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void WrongAdditionTest()
        {
            //Arrange
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(1, 1);
            Vector2 expected = new Vector2(1, 2);
            //Act
            Vector2 result = a + b;
            //Assert
            Assert.AreNotEqual(result, expected);
        }

        [TestMethod]
        public void CorrectSubtractionTest()
        {
            //Arrange
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(1, 1);
            Vector2 expected = new Vector2(0, 0);
            //Act
            Vector2 result = a - b;
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void WrongSubtractionTest()
        {
            //Arrange
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(1, 1);
            Vector2 expected = new Vector2(1, 0);
            //Act
            Vector2 result = a - b;
            //Assert
            Assert.AreNotEqual(result, expected);
        }

        [TestMethod]
        public void CorrectMultiplyTest()
        {
            //Arrange
            Vector2 a = new Vector2(2, 2);
            float value = 2;
            Vector2 expected = new Vector2(4, 4);
            //Act
            Vector2 result = a * value;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void WrongMultiplyTest()
        {
            //Arrange
            Vector2 a = new Vector2(2, 2);
            float value = 2;
            Vector2 expected = new Vector2(3, 4);
            //Act
            Vector2 result = a * value;
            //Assert
            Assert.AreNotEqual(result, expected);
        }
        [TestMethod]
        public void CorrectDivisionTest()
        {
            //Arrange
            Vector2 a = new Vector2(2, 2);
            float value = 2;
            Vector2 expected = new Vector2(1, 1);
            //Act
            Vector2 result = a / value;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void WrongDivisionTest()
        {
            //Arrange
            Vector2 a = new Vector2(2, 2);
            float value = 2;
            Vector2 expected = new Vector2(3, 1);
            //Act
            Vector2 result = a / value;
            //Assert
            Assert.AreNotEqual(result, expected);
        }
    }

    [TestClass]
    public class AdvancedVector2DTests
    {
        [TestMethod]
        public void CorrectLengthBetweenTwoVectors()
        {
            Vector2 first = new Vector2(0f, 0f);
            Vector2 second = new Vector2(5.0f, 5.0f);
            float expected = 7.071068f;

            float result = VectorCalculator.LengthBetweenTwoVectors(first, second);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void WrongLengthBetweenTwoVectors()
        {
            Vector2 first = new Vector2(0f, 0f);
            Vector2 second = new Vector2(5.0f, 5.0f);
            float expected = 7.071067f;

            float result = VectorCalculator.LengthBetweenTwoVectors(first, second);

            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void CorrectLengthOfSingleVector()
        {
            Vector2 vector = new Vector2(5.0f, 5.0f);
            float expected = 7.071068f;

            float result = vector.length;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void WrongLengthOfSingleVector()
        {
            Vector2 vector = new Vector2(5.0f, 5.0f);
            float expected = 7.071067f;

            float result = vector.length;

            Assert.AreNotEqual(expected, result);
        }
        [TestMethod]
        public void NormalizedVectorLengthIsOne()
        {
            Vector2 testVector = new Vector2(4, 3);
            float lengthOfNormalizedVector = testVector.normalized.length;
            
            float expected = 1f;

            Assert.AreEqual(expected, lengthOfNormalizedVector);
        }
        [TestMethod]
        public void WrongIfVectorLengthIsNotOne()
        {
            Vector2 testVector = new Vector2(4, 3);
            float lengthOfNormalizedVector = testVector.normalized.length;

            float expected = 1.5f;

            Assert.AreNotEqual(expected, lengthOfNormalizedVector);
        }

        [TestMethod]
        public void CorrectDotProduct()
        {
            Vector2 first = new Vector2(1f, 1f);
            Vector2 second = new Vector2(.5f, .5f);
            float expected = 1f;

            float result = VectorCalculator.DotProduct(first, second);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WrongDotProduct()
        {
            Vector2 first = new Vector2(1f, 1f);
            Vector2 second = new Vector2(.5f, .5f);
            float expected = 1.5f;

            float result = VectorCalculator.DotProduct(first, second);

            Assert.AreNotEqual(expected, result);
        }
    }
}