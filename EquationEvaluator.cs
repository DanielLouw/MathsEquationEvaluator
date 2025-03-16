using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEquationEvaluator
{
    public class EquationEvaluator
    {
        //Create a private enum to neatly represent the different operations that can be performed in the equation.
        private enum EquationOperation 
        {
            Multiply = 1,
            Divide = 2,
            Add = 3,
            Subtract = 4
        }

        // Create an EquationEvaluator class with a static method called EvaluateEquation that takes a string equation as a parameter and returns a double.
        public static double EvaluateEquation(string equationString)
        {           
            try 
            {
                var equationParts = equationString.Split(',').ToList();

                if (equationParts.Count != 3)
                    throw new ArgumentException("Invalid equation format.");

                var firstNumber = Convert.ToDouble(equationParts[0]);
                var secondNumber = Convert.ToDouble(equationParts[2]);
                var operation = (EquationOperation)Convert.ToInt32(equationParts[1]);

                switch(operation)
                {
                    case EquationOperation.Multiply:
                        return firstNumber * secondNumber;
                    case EquationOperation.Divide:
                        return firstNumber / secondNumber;
                    case EquationOperation.Add:
                        return firstNumber + secondNumber;
                    case EquationOperation.Subtract:
                        return firstNumber - secondNumber;
                    default:
                        throw new ArgumentException("Invalid operation specified.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
