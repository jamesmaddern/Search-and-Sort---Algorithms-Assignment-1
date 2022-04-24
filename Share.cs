public class Share
{
    public string filename;
    string path;
    public List<int> content = new List<int>();
    public Share(string fileName, string filePath)
    {
        filename = fileName;
        path = filePath;
        getContent();
    }
    public void getContent()
    {
        string[] strContent = File.ReadAllLines(path);
        foreach(string item in strContent)
        {
            content.Add(int.Parse(item));
        }
        
    }
}