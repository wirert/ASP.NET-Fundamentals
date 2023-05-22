while (true)
{
    var command = Console.ReadLine();
    if (command == "show")
    {
        long result = SumNumbersAsync();
        Console.WriteLine(result);
    }  
}

long SumNumbersAsync()
{
    return Task.Run(() =>
    {
        long sum = 0;

        for (long i = 2; i <= 10000; i += 2)
        {
            sum += i;
        }

        return sum;
    }).Result;
}