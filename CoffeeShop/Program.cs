CoffeeShop coffeeShop = new CoffeeShop();
await coffeeShop.Customer();

public class CoffeeShop
{
    TaskCompletionSource<string> _waitForSyrup = new TaskCompletionSource<string>();
    private async Task<string> BrewEspresso(CancellationToken token)
    {
        Console.WriteLine("Brewing Espresso");
        await Task.Delay(2000, token);
        Console.WriteLine("Brewed Espresso");
        return "Made Espresso";
    }
    
    private async Task<string> ToastPanini(CancellationToken token)
    {
        Console.WriteLine("Toasting Panini");
        await Task.Delay(4000, token);
        Console.WriteLine("Toasted Panini");
        return "Made Panini";
    }

    private async Task<String> MakeSyrupCoffee()
    {
        Console.WriteLine("Waiting for Syrup");
        await _waitForSyrup.Task;
        Console.WriteLine("Got Syrup");
        return "Made Syrup Coffee";
    }

    public void SyrupDelivery()
    {
        _waitForSyrup.TrySetResult("syrup");
    }
    
    public async Task Customer()
    {
        CancellationTokenSource cts = new CancellationTokenSource(5000);
        try
        {
            Task<string> task1 = BrewEspresso(cts.Token);
            Task<string> task2 = ToastPanini(cts.Token);
            Task<string> task3 = MakeSyrupCoffee();
            Console.WriteLine("Cleaning Counters");
            SyrupDelivery();
            string response1 = await task1;
            string response2 = await task2;
            string response3 = await task3;
            Console.WriteLine($"Responses: {response1}, {response2}, and {response3}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled");
        }
        
        
        return;
    }
}

