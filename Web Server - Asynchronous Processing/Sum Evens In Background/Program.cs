
long sum = 0;

var task = Task.Run(() =>
{
    for (long i = 2; i <= 1000000000; i += 2)
    {
        sum += i;
        Thread.Sleep(10);
    }
});

while (true)
{
    var command = Console.ReadLine();
    if (command == "exit")
    {
        return;
    }
    else if (command == "show")
    {
        Console.WriteLine(sum);
    }
}

