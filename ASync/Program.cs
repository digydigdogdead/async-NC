using ASync;
using System.Diagnostics;
using System.Numerics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        async Task SayHelloAndWorld()
        {
            var _cancelTasks = new CancellationTokenSource();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            var sayHello = Task.Run(async () =>
            {
                await Task.Delay(new Random().Next(1000, 10001));
                return "Hello";
            },
            _cancelTasks.Token);

            var sayWorld = Task.Run(async () =>
            {
                await Task.Delay(new Random().Next(1000, 10001));
                return "World";
            },
            _cancelTasks.Token);

                        
            try
            {
                if (!Task.WaitAll([sayHello, sayWorld], 5000))
                {
                    _cancelTasks.Cancel();
                }
                _cancelTasks.Token.ThrowIfCancellationRequested();
                string[] results = await Task.WhenAll([sayHello, sayWorld]);
                stopwatch.Stop();

                Console.WriteLine($"{results[0]}...{results[1]}");
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _cancelTasks.Dispose();
            }
        }

        //await SayHelloAndWorld();

        List<BigInteger> bigInts = Exercises.GetBigInts();

        List<Task> allTasks = new List<Task>();

        foreach (BigInteger bigInt in bigInts)
        {
            allTasks.Add(new Task(() =>
            { BigInteger result = Exercises.CalculateFactorial(bigInt);
                Console.WriteLine(result);
            }));
        }

        await Task.Run(() => allTasks[0]);
    }
}