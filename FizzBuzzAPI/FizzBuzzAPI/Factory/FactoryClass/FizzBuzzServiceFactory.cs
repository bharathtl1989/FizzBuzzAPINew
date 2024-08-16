using FizzBuzzAPI.Factory.Interface;
using FizzBuzzAPI.Services.Interface;
using FizzBuzzAPI.Services.Service;

namespace FizzBuzzAPI.Factory.FactoryClass
{
    public class FizzBuzzServiceFactory : IFizzBuzzServiceFactory
    {
        public IFizzBuzzService CreateFizzBuzzService()
        {
            return new FizzBuzzService();
        }
    }
}
