using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        async Task SayHelloAndWorld()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var sayHello = Task.Run(async () =>
            {
                await Task.Delay(3000);
                return "Hello";
            });

            var sayWorld = Task.Run(async () =>
            {
                await Task.Delay(3000);
                return "World";
            });

            string[] results = await Task.WhenAll([sayHello, sayWorld]);

            stopwatch.Stop();

            Console.WriteLine($"{results[0]}...{results[1]}");
            Console.WriteLine(stopwatch.ElapsedMilliseconds);


        }

        await SayHelloAndWorld();
    }
}