internal class Reader
{
    public string path;
    List<string> files = new List<string>();
    public List<Share> shares = new List<Share>();

    public Reader()
    {
        Directory.SetCurrentDirectory(@"..\..\..\");
        path = Directory.GetCurrentDirectory();
        getFileNames();
        

    }
    private void getFileNames()
    {
        int i = -1;
        foreach(string filePath in Directory.GetFiles(path))
        {
            if (filePath.EndsWith(".txt"))
            {
                files.Add(filePath);
                string file = Path.GetFileName(filePath);
                Share share = new Share(file,filePath);
                shares.Add(share);
            }
        }
        Console.WriteLine(files);
    }
    
} 