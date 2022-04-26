internal class Searcher
{
    int steps;
    public Searcher()
    {
        steps = 0;
    }
    public void getSteps()
    {
        Console.WriteLine("Steps: " + steps);
    }
    public List<int> BinarySearch(List<int> array, int target)
    {
        List<int> indicies = new List<int>();

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
                    indicies.Add(mid);
                    mid++;                    
                }while(array[mid] == target);
                while(array[i] == target)
                {
                    steps++;
                    indicies.Add(i);
                    i--;
                }
                return indicies;
            }           
        }
        return indicies;

    }
    public List<int> LinearSearch(List<int> array, int target)
    {
        List<int> indicies =new List<int>();   
        for(int i = 0; i < array.Count; i++)
        {
            steps++;
            if (array[i] == target)
            {
                do
                
                {
                    indicies.Add(i);
                    i++;
                }while (array[i] == target);
                return indicies;
            }
        }
        return indicies;
    }
}