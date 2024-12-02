using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
async Task SayHelloAndWorld()
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    var sayHello = Task.Run(async () =>
    {
        await Task.Delay(3000);
        Console.WriteLine("Hello");
    });

    var sayWorld = Task.Run(async () =>
    {
        await Task.Delay(3000);
        Console.WriteLine("World");
    });
    
    await Task.WhenAll([sayHello, sayWorld]);

    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
}

await SayHelloAndWorld();