namespace MathsEquationEvaluator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test the EvaluateEquation method with 5, 3(+), 3. Should output 8.
            Console.WriteLine($"{EquationEvaluator.EvaluateEquation("5,3,3")}");
        }
    }
}
