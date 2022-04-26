internal class Program
{

    Reader r = new Reader();
    public static void Main(string[] args)
    {
        //tester();
        //Console.ReadLine();
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
                p.searchMenu();
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
        //searchTester();
    }
    void printFiles()
    {

        for (int i = 0; i < r.shares.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + r.shares[i].filename);
        }
    }
    Share selectFileMenu()
    {
        bool valid = false;
        Share file = new Share();
        HashSet<char> validKeys = new HashSet<char>();
        for (int i = 1; i < 8; i++)
        {
            string s = i.ToString();

            validKeys.Add(Convert.ToChar(s));
        }
        while (!valid)
        {
            Console.Clear();
            Console.WriteLine("Please select a file");
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
        return file;
    }
    void searchMenu()
    {
        bool valid = false;
        int target = 0;
        while (!valid)
        {
            Console.WriteLine("Enter the value you wish to search for: ");
            string value = Console.ReadLine();
            try
            {
                target = Convert.ToInt32(value);
                valid = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        Share file = selectFileMenu();
        valid = false;
        while (!valid)
        {
            Console.Clear();
            Console.WriteLine("Choose Search Method");
            Console.WriteLine("--MENU--");
            Console.WriteLine("1.Binary Search\n2.Linear Search");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();
            valid = true;
            switch (option)
            {
                case '1':
                    Search(file, 0, target);
                    break;
                case '2':
                    Search(file, 1, target);
                    break;                
                default:
                    Console.WriteLine("WRONG");
                    valid = false;
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
    void sortMenu()
    {
        Share file = selectFileMenu();
        bool valid = false;
        while (!valid)
        {
            Console.Clear();
            Console.WriteLine("Choose Sorting Method");
            Console.WriteLine("--MENU--");
            Console.WriteLine("1.Bubble Sort\n2.Quick Sort\n3.Merge Sort\n4.Insertion Sort");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();
            valid = true;
            switch (option)
            {
                case '1':
                    Sort(file, 0);
                    break;
                case '2':
                    Sort(file, 1);
                    break;
                case '3':
                    Sort(file, 2);
                    break;
                case '4':
                    Sort(file, 3);
                    break;
                default:
                    Console.WriteLine("WRONG");
                    valid = false;
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
    static void printList(List<int> array)
    {
        for (int i = 9; i < array.Count; i += 10)
        {
            Console.WriteLine(array[i]);
        }
    }
    static void printTime(DateTime start, DateTime end)
    {
        TimeSpan duration = end - start;
        Console.WriteLine("Sort took " + duration.TotalSeconds + " Seconds");
    }
    
    static void Sort(Share file, int flag)
    {
        Console.WriteLine(file.filename);
        Sorter s = new Sorter(file.content);
        List<int> sortedList = new List<int>();
        DateTime start = DateTime.Now;
        switch (flag)
        {
            case 0:
                sortedList = s.bubble();
                break;
            case 1:
                sortedList = s.quickSort(file.content);
                break;
            case 2:
                sortedList = s.mergeSort(file.content);
                break;
            case 3:
                sortedList = s.InsertionSort(file.content);
                break;
        }
        DateTime end = DateTime.Now;
        printList(sortedList);
        printTime(start, end);
        s.getSteps();
    }
    static void Search(Share file, int flag, int target)
    {
        List<int> indicies = new List<int>();
        Searcher s = new Searcher();
        Sorter sorter = new Sorter(file.content);
        List<int> sortedList = sorter.quickSort(file.content);
        Console.WriteLine(file.filename);
        DateTime start = DateTime.Now;
        switch (flag)
        {
            case 0:                
                indicies = s.BinarySearch(sortedList,target);
                break;
            case 1:
                indicies = s.LinearSearch(sortedList, target);
                break;
        }
        DateTime end = DateTime.Now;
        if (indicies.Count > 0)
        {
            foreach (int i in indicies)
            {
                Console.WriteLine(sortedList[i]);
                Console.WriteLine("target found at index:" + i);

            }
        }
        else
        {
            Console.WriteLine("target not found");
        }
        printTime(start, end);
        s.getSteps();
    }
    static void searchTester()
    {
        Reader reader = new Reader();
        Sorter sorter = new Sorter(reader.shares[1].content);
        List<int> sortedList = sorter.quickSort(sorter.fileContent);
        Searcher s = new Searcher();
        List<int> indicies = s.BinarySearch(sortedList, 14);
        if (indicies.Count > 0)
        {
            foreach (int i in indicies)
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



    static void tester()
    {
        Reader r = new Reader();
        //INSERTION SORT
        Console.WriteLine("\nInsertion Sort");
        Console.WriteLine(r.shares[1].filename);
        Sorter b4 = new Sorter(r.shares[1].content);
        List<int> insertionSorted = b4.InsertionSort(b4.fileContent);
        for (int i = 9; i < insertionSorted.Count; i += 10)
        {
            Console.WriteLine(insertionSorted[i]);
        }
        b4.getSteps();
        //BUBBLE SORT
        Console.WriteLine("BubbleSort");
        Console.WriteLine(r.shares[1].filename);
        Sorter b = new Sorter(r.shares[1].content);
        List<int> sortedList = b.bubble();
        for (int i = 9; i < sortedList.Count; i += 10)
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

    }
}