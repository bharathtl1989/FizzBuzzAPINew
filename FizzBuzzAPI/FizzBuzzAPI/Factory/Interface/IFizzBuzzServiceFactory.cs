using FizzBuzzAPI.Services.Interface;

namespace FizzBuzzAPI.Factory.Interface
{
    public interface IFizzBuzzServiceFactory
    {
        IFizzBuzzService CreateFizzBuzzService();
    }
}
