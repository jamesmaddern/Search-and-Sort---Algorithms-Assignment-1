internal class Reader
{
    public string path;
    List<string> files = new List<string>();
    public List<Share> shares = new List<Share>();
    /// <summary>
    /// Reader object
    /// </summary>
    public Reader()
    {
        Directory.SetCurrentDirectory(@"..\..\..\");
        path = Directory.GetCurrentDirectory();
        getFileNames();
    }
    /// <summary>
    /// Creates and stores a list of Shares
    /// </summary>
    private void getFileNames()
    {
        
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
        
    }
    
} 