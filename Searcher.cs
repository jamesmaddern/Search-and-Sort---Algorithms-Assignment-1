internal class Searcher
{
    int steps;
    /// <summary>
    /// Searcher class
    /// </summary>
    public Searcher()
    {
        steps = 0;
    }
    /// <summary>
    /// Prints the number of steps
    /// </summary>
    public void getSteps()
    {
        Console.WriteLine("Steps: " + steps);
    }
    /// <summary>
    /// Binary search algorithm
    /// </summary>
    /// <param name="array">List to be searched</param>
    /// <param name="target">Integer to be searched for</param>
    /// <returns>List of indices where the target is found</returns>
    public List<int> BinarySearch(List<int> array, int target)
    {
        List<int> indices = new List<int>();

        int l = 0, r = array.Count-1,mid=0;
        while (l < r)
        {
            mid = (l+r)/2;
            if (array[mid] < target)
            {
                steps++;
                l = mid+1;
            }
            else if (array[mid] > target)
            {
                steps++;
                r = mid -1;
            }
            else
            {
                int i = mid - 1;
                do
                {
                    steps++;
                    indices.Add(mid);
                    mid++;                    
                }while(array[mid] == target);
                while(array[i] == target)
                {
                    steps++;
                    indices.Add(i);
                    i--;
                }
                return indices;
            }           
        }
        return indices;
    }
    /// <summary>
    /// Linear search algorithm
    /// </summary>
    /// <param name="array">List to be searched</param>
    /// <param name="target">Integer to be searched for</param>
    /// <returns>List of indices where the target is found</returns>
    public List<int> LinearSearch(List<int> array, int target)
    {
        List<int> indices =new List<int>();   
        for(int i = 0; i < array.Count; i++)
        {
            steps++;
            if (array[i] == target)
            {
                do                
                {
                    indices.Add(i);
                    i++;
                }while (array[i] == target);
                return indices;
            }
        }
        return indices;
    }
}