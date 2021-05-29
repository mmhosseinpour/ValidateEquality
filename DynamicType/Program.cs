using System;

namespace DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new();

            #region Test Service
            //Call Service
            string[] diffrence = service.GetObjectsDiffrence(
                new Bike()
                {
                    Id = 11,
                    Name = "BMW",
                    Offer = 33,
                    Rank = 1
                },
                new Bike()
                {
                    Id = 11,
                    Name = "Honda",
                    Offer = 33,
                    Rank = 3
                });

            //Write Diffrence
            foreach (string item in diffrence)
            {
                Console.WriteLine($"{item} Is not equel !");
            }
            #endregion

            Console.WriteLine("it's Done :)");
            Console.ReadKey();
        }
    }
}
