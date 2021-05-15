using System;

namespace Desafio
{
    class Program
    {
        static void Main(string[] args)
        {       
            // Initilize ad system
            AdvertisementSystem system = new AdvertisementSystem();

            // Create an advertisement
            Advertisement myAd = system.CreateAD();
            Advertisement myAd2 = system.CreateAD();
            system.ProvideReport();
        }
    }
}
