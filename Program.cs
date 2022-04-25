internal class Program
{

    public static void Main(string[] args)
    {
        /*Program program = new Program();

        string path = Environment.CurrentDirectory;
        path = Directory.GetParent(path).FullName;
        string file = Path.Combine(path, "hello.txt");
        program.write(file);
        */
        //tester();
        searchTester();
    }
    static void tester()
    {
        Reader r = new Reader();
        //BUBBLE SORT
        Console.WriteLine("BubbleSort");
        Console.WriteLine(r.shares[1].filename);
        Sorter b = new Sorter(r.shares[1].content);
        List<int> sortedList = b.bubble();
        for (int i = 9; i < sortedList.Count;i+=10)
        {
            Console.WriteLine(sortedList[i]);
        }
        b.getSteps();
        //QUICKSORT
        Console.WriteLine("\nQuick Sort");
        Console.WriteLine(r.shares[1].filename);
        Sorter b2 = new Sorter(r.shares[1].content);
        List<int> quickSorted = b2.quickSort(b2.fileContent);
        for (int i = 9; i < quickSorted.Count; i += 10)
        {
            Console.WriteLine(quickSorted[i]);
        }
        b2.getSteps();
        //MERGE SORT
        Console.WriteLine("\nMerge Sort");
        Console.WriteLine(r.shares[1].filename);
        Sorter b3 = new Sorter(r.shares[1].content);
        List<int> mergeSorted = b3.mergeSort(b3.fileContent);        
        for (int i = 9; i < mergeSorted.Count; i += 10)
        {
            Console.WriteLine(mergeSorted[i]);
        }
        b3.getSteps();
        //INSERTION SORT
        Console.WriteLine("\nInsertion Sort");
        Console.WriteLine(r.shares[1].filename);
        Sorter b4 = new Sorter(r.shares[1].content);
        List<int> insertionSorted = b4.InsertionSort(b4.fileContent);
        for (int i = 9; i < insertionSorted.Count; i += 10)
        {
            Console.WriteLine(mergeSorted[i]);
        }
        b4.getSteps();
    }
    static void searchTester()
    {
        Reader reader = new Reader();
        Sorter sorter = new Sorter(reader.shares[1].content);
        List<int> sortedList = sorter.quickSort(sorter.fileContent);
        Searcher s = new Searcher();
        List<int> indicies = s.BinarySearch(sortedList, 14);
        if(indicies.Count > 0)
        {
            foreach(int i in indicies)
            {
                Console.WriteLine(sortedList[i]);
                Console.WriteLine("target found at index:" + i);

            }
        }
        else
        {
            Console.WriteLine("target not found");
        }
    }
    /*public async void write(string file)
    {
        await File.WriteAllTextAsync(file, "hello there");
    }*/

    
}