using FizzBuzzAPI.Services.Interface;

namespace FizzBuzzAPI.Services.Service
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public string GetFizzBuzzResult(int number)
        {
            if (number % 3 == 0 && number % 5 == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";
            if (number % 3 != 0 && number % 5 != 0) return "Divided " + number + " by 3 \n Divided " + number + " by 5";
            return number.ToString();
        }
    }
}
