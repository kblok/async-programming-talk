using System;
using System.Threading.Tasks;

namespace AwaitDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            var positiveTask = GetNegativeNumbersAsync();
            var negativeTask = GetNegativeNumbersAsync();

            await Task.WhenAll(positiveTask, negativeTask);

            var task = await Task.WhenAny(positiveTask, negativeTask);

            Console.ReadKey();
        }

        private static async Task GetPositiveNumbersAsync()
        {
            for (var i = 1; i <= 21; i++)
            {
                Console.WriteLine(i);
                if (i % 3 == 0)
                {
                    await LongAsync(i).ConfigureAwait(false);
                }
            }
        }

        private static async Task GetNegativeNumbersAsync()
        {
            for (var i = -1; i >= -21; i--)
            {
                Console.WriteLine(i);
                if (i % 3 == 0)
                {
                    await LongAsync(i);
                }
            }
        }

        private static Task LogAsync(int number)
            => Console.Out.WriteLineAsync($"Waiting for {number}");

        private static async Task LongAsync(int number)
        {
            await Task.Delay(100);
            await Console.Out.WriteLineAsync($"Waiting for {number}");
        }

        private static Task<int> GetTwo(bool getFromResource = false)
        {
            if (getFromResource)
            {
                return Task.FromResult(2);
            }

            return Task.FromResult(2);
        }

        private static Task BuildTask()
        {
            var tcs = new TaskCompletionSource<bool>();

            Task.Delay(1000).ContinueWith((obj) => tcs.TrySetResult(true));

            return tcs.Task;
        }
    }
}
