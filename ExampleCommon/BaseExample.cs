using System;
using AlchemyAPI;

namespace ExampleCommon
{
    public abstract class BaseExample
    {
        protected readonly Alchemy Api;

        protected BaseExample()
        {
            Console.WriteLine("Enter API key");
            var key = Console.ReadLine();

            // Create an AlchemyAPI object.
            Api = new Alchemy
            {
                ApiKey = key
            };
        }

        protected virtual void Example()
        {
            Console.WriteLine("Press any key to escape");
            Console.ReadKey();
        }

        protected void PauseForUserInput()
        {
            Console.WriteLine("Press any key to continue");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
