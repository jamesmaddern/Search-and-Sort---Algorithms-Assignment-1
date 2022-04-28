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
    /// <summary>
    /// Prints the list of Share files for menu purposes
    /// </summary>
    void printFiles()
    {

        for (int i = 0; i < r.shares.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + r.shares[i].filename);
        }
    }
    /// <summary>
    /// Gets the file to be sort/searched from user input
    /// </summary>
    /// <returns>Selected file</returns>
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
    /// <summary>
    /// Gets the number to be searched for and the search method
    /// </summary>
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
    /// <summary>
    /// Gets the sort method
    /// </summary>
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
    /// <summary>
    /// Prints every 10th value of the sorted list
    /// </summary>
    /// <param name="array"></param>
    static void printList(List<int> array)
    {
        for (int i = 9; i < array.Count; i += 10)
        {
            Console.WriteLine(array[i]);
        }
    }
    /// <summary>
    /// Prints the time taken for a given operation
    /// </summary>
    /// <param name="start">Start time of the operation</param>
    /// <param name="end">End time of the operation</param>
    static void printTime(DateTime start, DateTime end)
    {
        TimeSpan duration = end - start;
        Console.WriteLine("Sort took " + duration.TotalSeconds + " Seconds");
    }
    /// <summary>
    /// Sorting menu
    /// </summary>
    /// <param name="file">file to be sorted</param>
    /// <param name="flag">Selects the corresponding sorting algorithm</param>
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
    /// <summary>
    /// Search method
    /// </summary>
    /// <param name="file">file to be searched</param>
    /// <param name="flag">selects the corresponding algorithm</param>
    /// <param name="target">the integer to be found</param>
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
}