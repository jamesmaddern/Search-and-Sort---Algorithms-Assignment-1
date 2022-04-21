internal class Reader
{
    public string path;
    List<string> files = new List<string>();
    public List<string[]> fileContent = new List<string[]>();

    public Reader()
    {
        Directory.SetCurrentDirectory(@"..\..\..\");
        path = Directory.GetCurrentDirectory();
        getFileNames();
        readFiles();

    }
    private void getFileNames()
    {
        int i = -1;
        foreach(string filename in Directory.GetFiles(path))
        {
            if (filename.EndsWith(".txt"))
            {
                files.Add(filename);
            }
        }
        Console.WriteLine(files);
    }
    private void readFiles()
    {
        for(int i = 0; i < files.Count; i++)
        {
            string filename = files[i];
            fileContent.Add(File.ReadAllLines(filename));
        }
    }
}