using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEquationEvaluator
{
    public class EquationInformation
    {
        private readonly IEquationProvider _equationProvider;

        public EquationInformation(IEquationProvider equationProvider)
        {
            _equationProvider = equationProvider;
        }

        // Implement a method called DisplayEquationInformation that fetches the equation data from the IEquationProvider and displays the equation information.
        public async Task DisplayEquationInformation() 
        {
            var equationIds = await _equationProvider.GetEquationIdsAsync();
            var results = new List<double>();

            foreach (var equationId in equationIds)
            {
                var equationData = await _equationProvider.GetEquationDataAsync(equationId);
                var equationCollection = equationData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"Equation {equationId}: {equationData}");

                foreach (var equation in equationCollection) 
                {
                    try 
                    {
                        var result = EquationEvaluator.EvaluateEquation(equationData);
                        results.Add(result);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error evaluating equation: {ex.Message}");
                    }
                }
            }

            if (results.Count > 0)
            {
                var average = results.Average();
                var sum = results.Sum();
                var standardDeviation = CalculateStandardDeviation(results);
                Console.WriteLine($"Average: {average}");
                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"Standard Deviation: {standardDeviation}");
            }
        }

        private static double CalculateStandardDeviation(List<double> values)
        {
            double average = values.Average();
            double sumOfSquares = values.Sum(val => Math.Pow(val - average, 2));
            return Math.Sqrt(sumOfSquares / (values.Count - 1));
        }
    }
}
