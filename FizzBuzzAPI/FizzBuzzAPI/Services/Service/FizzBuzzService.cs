using FizzBuzzAPI.Services.Interface;
using System.Runtime.CompilerServices;

namespace FizzBuzzAPI.Services.Service
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<string> GetFizzBuzzResult(List<string> inputs)
        {         
            var results = new List<string>();
            foreach (var input in inputs)
            {
                if (int.TryParse(input, out int number))
                {
                    if (number % FizzBuzzConstants.DivisorThree == 0 && number % FizzBuzzConstants.DivisorFive == 0)
                        results.Add(FizzBuzzConstants.FizzBuzz);
                    else if (number % FizzBuzzConstants.DivisorThree == 0)
                        results.Add(FizzBuzzConstants.Fizz);
                    else if (number % FizzBuzzConstants.DivisorFive == 0)
                        results.Add(FizzBuzzConstants.Buzz);
                    else if (number % FizzBuzzConstants.DivisorThree != 0 && number % FizzBuzzConstants.DivisorFive != 0)
                    { 
                        results.Add(number + FizzBuzzConstants.NotMultipleOfAny);
                    }
                    else
                        results.Add(number.ToString());
                }
                else
                {
                    results.Add(FizzBuzzConstants.InvalidInput);
                }
            }

            return results;
        }
    }
}
