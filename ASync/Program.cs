using System.Diagnostics;

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
                string[] results = await Task.WhenAll([sayHello, sayWorld]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            _cancelTasks.CancelAfter(5000);

            /*private void DoStuff()
            {
                _cancelTasks = new CancellationTokenSource();

                var task = new Task(() => { *//* your actions here *//* }, _cancelTasks.Token);
                task.Start();

                if (!task.Wait(5000)) _cancelTasks.Cancel();
            }*/
            

            

            stopwatch.Stop();

            Console.WriteLine($"{results[0]}...{results[1]}");
            Console.WriteLine(stopwatch.ElapsedMilliseconds);


        }

        await SayHelloAndWorld();
    }
}