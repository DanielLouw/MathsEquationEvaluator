using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEquationEvaluator;
using Moq;

namespace MathsEquationEvaluatorTests
{
    internal class EquationInformationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EquationInformationTest()
        {
            // Arrange 
            var mockEquationProvider = new Mock<IEquationProvider>();
            mockEquationProvider.Setup(x => x.GetEquationIdsAsync()).ReturnsAsync(new List<int> { 1, 2, 3 });
            mockEquationProvider.Setup(x => x.GetEquationDataAsync(It.IsAny<int>())).ReturnsAsync("5,3,3\n5,4,1\n5,1,5\n5,2,2");

            var equationInformation = new EquationInformation(mockEquationProvider.Object);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                var result = equationInformation.DisplayEquationInformation();

                // Assert
                var avgExpected = "Average: 9,875";
                var sumExpected = "Sum: 118,5";
                var stdDevExpected = "Standard Deviation: 9,359305044130728";

                Assert.IsNotNull(result);               

                // Check console output
                var consoleOutput = sw.ToString();
                Assert.IsTrue(consoleOutput.Contains(avgExpected));
                Assert.IsTrue(consoleOutput.Contains(sumExpected));
                Assert.IsTrue(consoleOutput.Contains(stdDevExpected));
            }
        }
    }
}
