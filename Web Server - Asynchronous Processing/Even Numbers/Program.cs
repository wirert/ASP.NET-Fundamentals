int min = int.Parse(Console.ReadLine());
int max = int.Parse(Console.ReadLine());

PrintEvenNumbersInRangeInThread(min, max);

Console.WriteLine("Thread finished work");

void PrintEvenNumbersInRangeInThread(int min, int max)
{
    Thread thread = new Thread(() =>
    {
        for (int i = min; i <= max; i++)
        {
            if (i % 2 == 1) continue;

            Console.WriteLine(i);
        }
    });

    thread.Start();
    thread.Join();
}