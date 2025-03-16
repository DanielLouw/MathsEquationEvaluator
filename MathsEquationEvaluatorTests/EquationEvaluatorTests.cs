using MathsEquationEvaluator;

namespace MathsEquationEvaluatorTests
{

    public class EquationEvaluatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenEquationString_WhenEvaluated_ReturnsCorrectSum()
        {
            //Arrange 
            var testData = "5,3,3";

            //Act
            var result = EquationEvaluator.EvaluateEquation(testData);

            //Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void GivenEquationString_WhenEvaluated_ReturnsCorrectDifference()
        {
            //Arrange 
            var testData = "5,4,1";
            //Act
            var result = EquationEvaluator.EvaluateEquation(testData);
            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GivenEquationString_WhenEvaluated_ReturnsCorrectProduct()
        {
            //Arrange 
            var testData = "5,1,5";
            //Act
            var result = EquationEvaluator.EvaluateEquation(testData);
            //Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void GivenEquationString_WhenEvaluated_ReturnsCorrectQuotient()
        {
            //Arrange 
            var testData = "5,2,2";
            //Act
            var result = EquationEvaluator.EvaluateEquation(testData);
            //Assert
            Assert.That(result, Is.EqualTo(2.5));
        }
    }
}