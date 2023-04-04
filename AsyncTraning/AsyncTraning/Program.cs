
using System.Diagnostics;

internal class Program
{
    private static readonly CancellationTokenSource canToken = new CancellationTokenSource();
    private static async Task Main(string[] args)
    {
        #region 1
        //await GetValue();
        //Console.WriteLine("Hello, World!"+ data);
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        //var sumTask = SlowAndComplexSumAsync();
        //var wordTask = SlowAndComplexWordAsync();
        //await Task.WhenAll(sumTask, wordTask);
        //Console.WriteLine("Hello, World!"+ stopWatch.Elapsed);
        //var data = await FirstRespondingUrlAsync();
        //Console.WriteLine("Hello, World!"+data);
       // await CreateStringValue();
        stopWatch.Stop();
        #endregion

        Console.WriteLine("Appllication has started. Ctrl -C to end");

        Console.CancelKeyPress +=(sender, eventArgs) =>
        {
            Console.WriteLine("Cancel event triggered");
            canToken.Cancel();
            eventArgs.Cancel = true;
        };

        await Worker();
        Console.WriteLine("now shutting down");
        await Task.Delay(1000);
    }

    private static async Task Worker()
    {
        while (!canToken.IsCancellationRequested)
        {
            Console.WriteLine("Worker is running");
            await Task.Delay(1000);
        }
    }

    private static Task<string> CreateStringValue()
    {
       Console.WriteLine("Result of create string value starting");
        string returnValue = "Create String value method starting";
        Console.WriteLine("Result of create string value end");

        return Task.FromResult<string>(returnValue);
    }

    private static async Task GetValue()
    {
        Console.WriteLine("Method Start");

        var myTask = new HttpClient().GetStringAsync("https://www.egm.gov.tr/")
                                                        .ContinueWith((data) =>
                                                        {
                                                            Console.WriteLine($"data length {data.Result.Length}");
                                                        });
        await myTask;
        Console.WriteLine("Method End");
        // return result;
    }

    /// <summary>
    ///  //TODO:Tum ısteklerın sonuclanmasını beklıyoruz WhenAll
    /// </summary>
    /// <returns></returns>
    private static async Task<int> SlowAndComplexSumAsync()
    {
        Console.WriteLine("Result of complex sum starting =");
        int sum = 0;

        foreach (var counter in Enumerable.Range(0, 5))
        {
            sum += counter;
            await Task.Delay(200);
        }
        Console.WriteLine("Result of complex sum End =");
        return sum;
    }

    /// <summary>
    /// //TODO:Tum ısteklerın sonuclanmasını beklıyoruz WhenAll
    /// </summary>
    /// <returns></returns>
    private static async Task<string> SlowAndComplexWordAsync()
    {
        Console.WriteLine("Result of complex word starting =");

        var word = string.Empty;
        foreach (var counter in Enumerable.Range(0, 6))
        {
            word =string.Concat(word, (char)counter);
            await Task.Delay(2500);
        }
        Console.WriteLine("Result of complex word End =");
        return word;
    }

    private static async Task<string> FirstRespondingUrlAsync()
    {
        Task<string> downA = new HttpClient().GetStringAsync("https://www.egm.gov.tr/");
        Task<string> downB = new HttpClient().GetStringAsync("https://www.egm.gov.tr/il-emniyet-mudurlukleri");

        //TODO:Ilk hangı deger donuyorsa onu alıp ıslemı bıtırıyor
        Task<string> completedTask = await Task.WhenAny(downA, downB);
        string data = await completedTask;
        return data;
    }



}