CoffeeShop coffeeShop = new CoffeeShop();
await coffeeShop.Customer();

public class CoffeeShop
{
    public async Task<string> BrewEspresso(CancellationToken token)
    {
        Console.WriteLine("Brewing Espresso");
        await Task.Delay(2000, token);
        Console.WriteLine("Brewed Espresso");
        return "Made Espresso";
    }
    
    public async Task<string> ToastPanini(CancellationToken token)
    {
        Console.WriteLine("Toasting Panini");
        await Task.Delay(4000, token);
        Console.WriteLine("Toasted Panini");
        return "Made Panini";
    }
    
    public async Task Customer()
    {
        CancellationTokenSource cts = new CancellationTokenSource(3000);
        try
        {
            Task<string> task1 = BrewEspresso(cts.Token);
            Task<string> task2 = ToastPanini(cts.Token);

            Console.WriteLine("doing other stuff");

            string response1 = await task1;
            string response2 = await task2;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled");
        }
        
        
        return;
    }
}

