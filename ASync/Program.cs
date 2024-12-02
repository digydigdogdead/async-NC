// See https://aka.ms/new-console-template for more information
async Task SayHello()
{
    await Task.Delay(2000);
    Console.WriteLine("Hello, World!");
}

await SayHello();