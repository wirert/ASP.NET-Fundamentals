int[] arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Console.WriteLine(string.Join(" ", MergeSortAsync(arr.ToList())));

 static async Task<List<int>> MergeSortAsync(List<int> list)
{   
    if (list.Count <= 1)
    {
        return list;
    }

    List<int> leftList = await Task.Run(() => MergeSortAsync(list.GetRange(0, list.Count / 2)));
    List<int> rightList = await Task.Run(() => MergeSortAsync(list.GetRange(list.Count / 2, list.Count - list.Count / 2)));
    
    return CombineArraysAsync(leftList, rightList);
}

 static List<int> CombineArraysAsync(List<int> leftList, List<int> rightList)
{
    List<int> sortedList = new List<int>();
    int leftIndex = 0;
    int rightIndex = 0;

    while (leftIndex < leftList.Count && rightIndex < rightList.Count)
    {
        if (leftList[leftIndex] <= rightList[rightIndex])
        {
            sortedList.Add(leftList[leftIndex]);
            leftIndex++;
        }
        else
        {
            sortedList.Add(rightList[rightIndex]);
            rightIndex++;
        }
    }

     for (int i = leftIndex; i < leftList.Count; i++)
    {
        sortedList.Add(leftList[i]);
    }

    for (int i = rightIndex; i < rightList.Count; i++)
    {
        sortedList.Add(rightList[i]);
    }

    return sortedList;
}
