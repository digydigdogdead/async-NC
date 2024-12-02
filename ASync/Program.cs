using ASync;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static async Task Main(string[] args)
    {
        /*async Task SayHelloAndWorld()
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
        }*/

        //await SayHelloAndWorld();

        List<BigInteger> bigInts = Exercises.GetBigInts();

        List<Task<BigInteger>> allTasks = new();

        foreach (BigInteger bigInt in bigInts)
        {
            /*allTasks.Add(new Task(() =>
            {
                BigInteger result = Exercises
                .CalculateFactorial(new BigInteger(24672));

                Console.WriteLine(result);
            }));*/
            allTasks.Add(Task.Run(() =>
            {
                BigInteger result = Exercises
                .CalculateFactorial(bigInt);

                return result;
            }));
        }

        /*static Task CalculateFactorialAsync(BigInteger bigInteger)
        {
            var result = Task.Run(() =>
            {
                Exercises.CalculateFactorial(bigInteger);
            });
            return result;
        }


        foreach (BigInteger bigInteger in bigInts)
        {
            var task1 = CalculateFactorialAsync(bigInteger);
            
        }*/



        await Task
            .WhenAll(allTasks)
            .ContinueWith(x =>
            {
                foreach (BigInteger result in x.Result)
                {
                    Console.WriteLine(result);
                }
            });

        /*foreach (var num in combined)
        {
            Console.WriteLine(num);
        }*/
        /*
        await result1 = Exercises.CalculateFactorial(bigInts[0])
        await result2 = ...

        1-----
        2-----
        3-----
        4---------
        5---------
        6----------------
        7------------------------(<-)
        8----------------
        9---------
        
         */


    }
}