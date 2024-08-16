using FizzBuzzAPI.Services.Interface;

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
                    if (number % 3 == 0 && number % 5 == 0)
                        results.Add("FizzBuzz");
                    else if (number % 3 == 0)
                        results.Add("Fizz");
                    else if (number % 5 == 0)
                        results.Add("Buzz");
                    else if (number % 3 != 0 && number % 5 != 0)
                    { 
                        results.Add("Divided " + number + " by 3");
                        results.Add("Divided " + number + " by 5");
                    }
                    else
                        results.Add(number.ToString());
                }
                else
                {
                    results.Add("Invalid input");
                }
            }

            return results;
        }
    }
}
