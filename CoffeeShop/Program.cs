CoffeeShop coffeeShop = new CoffeeShop();
await coffeeShop.Customer();

public class CoffeeShop
{
    // brew espresso - 2 seconds
    // toast panini - 4 seconds

    // public string BrewEspresso()
    // {
    //     Console.WriteLine("Brewing Espresso");
    //     Thread.Sleep(2000);
    //     Console.WriteLine("Brewed Espresso");
    //     return "Made Espresso";
    // }
    //
    // public string ToastPanini()
    // {
    //     Console.WriteLine("Toasting Panini");
    //     Thread.Sleep(4000);
    //     Console.WriteLine("Toasted Panini");
    //     return "Made Panini";
    // }
    //
    // public void Customer()
    // {
    //     Task task1 = new Task(() => { BrewEspresso(); });
    //     Task task2 = new Task(() => { ToastPanini(); });
    //     task1.Start();
    //     task2.Start();
    //     
    //     Console.WriteLine("doing other stuff");
    //     
    //     Task.WaitAll(task1, task2);
    //     return;
    // }
    
    
    public async Task<string> BrewEspresso()
    {
        Console.WriteLine("Brewing Espresso");
        await Task.Delay(2000);
        Console.WriteLine("Brewed Espresso");
        return "Made Espresso";
    }
    
    public async Task<string> ToastPanini()
    {
        Console.WriteLine("Toasting Panini");
        await Task.Delay(4000);
        Console.WriteLine("Toasted Panini");
        return "Made Panini";
    }
    
    public async Task Customer()
    {
        Task<string> task1 = BrewEspresso();
        Task<string> task2 = ToastPanini();
        
        Console.WriteLine("doing other stuff");
        
        string response1 = await task1;
        string response2 = await task2;
        
        return;
    }
}

