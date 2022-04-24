internal class Sorter
{
    public List<int> fileContent;
    int steps;
    public Sorter(List<int> f)
    {
        int[] temp = new int[f.Count];
        f.CopyTo(temp);
        fileContent = temp.ToList();
        steps = 0;
    }
    public void getSteps()
    {
        Console.WriteLine("Steps: " + steps);
    }
    public List<int> bubble()
    {
        bool swapped = false;
        int temp = 0;
        do
        {
            swapped = false;
            for(int i = 1; i < fileContent.Count; i++)
            {
                
                if (fileContent[i-1] > fileContent[i])
                {
                    steps++;
                    temp = fileContent[i];
                    fileContent[i] = fileContent[i-1];
                    fileContent[i-1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);        
        return fileContent;
    }
    public List<int> quickSort(List<int> unsortedList)
    {
        int pivot;
        List<int> lessThanPivot = new List<int>();
        List<int> greaterThanPivot = new List<int>();
        if (unsortedList.Count <= 1)
        {
            return unsortedList;
        }
        else
        {
            pivot = unsortedList[unsortedList.Count-1];
            unsortedList.RemoveAt(unsortedList.Count-1);
        }
        foreach(int i in unsortedList)
        {
            steps++;
            if (i < pivot)
            {
                lessThanPivot.Add(i);
            }
            else
            {
                greaterThanPivot.Add(i);
            }
        }
        lessThanPivot = quickSort(lessThanPivot);
        greaterThanPivot = quickSort(greaterThanPivot);

        lessThanPivot.Add(pivot);
        lessThanPivot.AddRange(greaterThanPivot);
        return lessThanPivot;
    }
    public List<int> mergeSort(List<int> unsortedList)
    {
        int n = unsortedList.Count;
        if (n == 1)
        {
            return unsortedList;
        }

        steps++;
        List<int> left = unsortedList.GetRange(0, n / 2);
        List<int> right = unsortedList.GetRange(n / 2, n / 2);

        left = mergeSort(left);
        right = mergeSort(right);

        return Merge(left, right);
    }
    private List<int> Merge(List<int> left, List<int> right)
    {
        List<int> mergedList = new List<int>();
        while(left.Count > 0 && right.Count > 0)
        {
            steps++;
            if (left[0] > right[0])
            {
                mergedList.Add(right[0]);
                right.RemoveAt(0);
            }
            else
            {
                mergedList.Add(left[0]);
                left.RemoveAt(0);
            }
        }
        while (left.Count > 0)
        {
            steps++;
            mergedList.Add(left[0]);
            left.RemoveAt(0);
        }
        while(right.Count > 0)
        {
            steps++;
            mergedList.Add(right[0]);
            right.RemoveAt(0);
        }
        return mergedList;
    }
    public List<int> InsertionSort(List<int> array)
    {
        for(int i = 0; i < array.Count; i++)
        {
            int key = array[i];

            int j = i - 1;
            while(j>=0 && key < array[j])
            {
                steps++;
                array[j+1] = array[j];
                j--;
            }
            array[j+1] = key;
        }
        return array;
    }
    


}