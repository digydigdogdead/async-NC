using ASync;
using System.ComponentModel;
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

        /*        List<BigInteger> bigInts = Exercises.GetBigInts();

                List<Task<BigInteger>> allTasks = new();

                foreach (BigInteger bigInt in bigInts)
                {
                    allTasks.Add(Task.Run(() =>
                    {
                        BigInteger result = Exercises
                        .CalculateFactorial(bigInt);

                        return result;
                    }));
                }

                string story = "Mary had a little lamb, its fleece was white as snow.";
                string[] storyArray = story.Split(' ');


                var tellAStory = Task.Run(async () =>
                {
                    foreach (var word in storyArray)
                    {
                        Console.WriteLine(word);
                        await Task.Delay(1000);
                    }
                });

                var printFactorials = Task.Run(async () =>
                {
                    await Task
                        .WhenAll(allTasks)
                        .ContinueWith(x =>
                        {
                            foreach (BigInteger result in x.Result)
                            {
                                Console.WriteLine(result);
                            }
                        });
                });

                await Task.WhenAll([tellAStory, printFactorials]);*/



        string encryptedContent = await ASyncFileManager.ReadFile("Resources/SuperSecretFile.txt");
        Console.WriteLine(encryptedContent);

        string result = "";
        /*foreach (char c in encryptedContent)
        {
            if (c != ' ')
            {
                int i = c - 0;
                i++;
                result += (char)i;
            }
            else
            {
                result += c;
            }
        }*/

        await Task.Run(() =>
        {
            foreach (char c in encryptedContent)
            {
                if (c != ' ')
                {
                    int i = c - 0;
                    i++;
                    result += (char)i;
                }
                else
                {
                    result += c;
                }
            }
        });

        ASyncFileManager.WriteFile("Resources/DecryptedMessage.txt", result);

        string decryptedContent = ASyncFileManager.ReadFile("Resources/DecryptedMessage.txt").Result;
        Console.WriteLine(decryptedContent);



    }
}