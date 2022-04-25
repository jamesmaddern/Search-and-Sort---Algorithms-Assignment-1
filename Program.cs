internal class Program
{

    Reader r = new Reader();
    public static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine("Search and Sort Program");
        Console.WriteLine("--MENU--");
        Console.Write("1.Sort\n2.Search\n3.Auto Generate Results\n-------\n0.Exit\n\nChoice: ");
        char option = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (option)
        {
            case '1':
                p.sortMenu();
                break;
            case '2':
                Console.WriteLine();
                break;
            case '3':
                Console.WriteLine();
                break;
            case '0':
                Console.WriteLine();
                break;
            default:
                break;
        }
        //tester();
        //searchTester();
    }
    void printFiles()
    {
        
        for(int i = 0; i < r.shares.Count; i++)
        {
            Console.WriteLine(i+1 +". " + r.shares[i].filename);
        }        
    }
    void sortMenu()
    {
        bool valid = false;        
        Share file;
        HashSet<char> validKeys = new HashSet<char>();
        for (int i = 1; i < 8; i++)
        {
            string s = i.ToString();

            validKeys.Add(Convert.ToChar(s));
        }
        while (!valid) 
        {
            Console.Clear();
            Console.WriteLine("Choose file to Sort");
            Console.WriteLine("--MENU--");
            printFiles();
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();            

            if (validKeys.Contains(option))
            {
                valid = true;
                string i = option.ToString();
                file = r.shares[Convert.ToInt16(i) - 1];
            }
            else
            {
                Console.WriteLine("WRONG");
                valid = false;
                Thread.Sleep(1000);
            }            
        }
        valid = false;
        while (!valid)
        {
            Console.Clear();
            Console.WriteLine("Choose Sorting Method");
            Console.WriteLine("--MENU--");
            Console.WriteLine("1.Bubble Sort");
        }

        

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