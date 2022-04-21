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
        Reader r = new Reader();
        foreach(string[] f in r.fileContent)
        {
            foreach(string item in f)
            {
                Console.WriteLine(item);
            }
        }
        
    }

    /*public async void write(string file)
    {
        await File.WriteAllTextAsync(file, "hello there");
    }*/

    
}