using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEquationEvaluator
{
    //Define an interface to define the methods that the EquationProviderHttpClient class will implement and we can mock the interface in our tests.
    public interface IEquationProvider
    {
        Task<List<int>> GetEquationIdsAsync();
        Task<string> GetEquationDataAsync(int equationId);
    }
}
