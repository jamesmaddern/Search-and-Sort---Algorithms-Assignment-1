public class Share
{
    public string filename;
    string path;
    public List<int> content = new List<int>();
    /// <summary>
    /// Share Object
    /// </summary>
    /// <param name="fileName">Name of the file</param>
    /// <param name="filePath">Path of the file</param>
    public Share(string fileName, string filePath)
    {
        filename = fileName;
        path = filePath;
        getContent();
    }
    public Share() { }
    /// <summary>
    /// Reads the file and adds each line to the content attribute
    /// </summary>
    public void getContent()
    {
        string[] strContent = File.ReadAllLines(path);
        foreach(string item in strContent)
        {
            content.Add(int.Parse(item));
        }
        
    }
}