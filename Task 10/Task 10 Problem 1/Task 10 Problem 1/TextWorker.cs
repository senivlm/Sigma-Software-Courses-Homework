class TextWorker
{
    #region Variables
    private string _path;
    private string _text;
    #endregion
    
    #region Properties
    private string Path
    {
        get { return _path; }
        set { _path = value; }
    }
    private string Text
    {
        get { return _text; }
        set { _text = value; }
    }
    #endregion

    #region Constructors
    public TextWorker(string path)
    {
        _path = path;
    }
    #endregion

    #region Methods
    public void ReadFromFile()
    {
        string path = Path + "Input.txt";
        if (!File.Exists(path))
        {
            throw new Exception("File for this method does not exist!");
        }
        using (StreamReader streamReader = new StreamReader(path))
        {
            Text = streamReader.ReadToEnd();
        }

    }
    public void WritoToFile()
    {
        string path = Path + "Result.txt";
        if (!File.Exists(path))
        {
            throw new Exception("File for this method does not exist!");
        }
        using (StreamWriter streamWriter = new StreamWriter(path))
        {
            streamWriter.Write(Text);
        }
    }
    public void SplitText()
    {
        string sent = "", res = "";
        string[] textSplit = Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < textSplit.Length; i++)
        {
            sent = textSplit[i];
            if (sent.Contains('\n') || sent.Contains('\r'))
            {
                sent = sent.Replace("\n", "");
                sent = sent.Replace("\r", "");
            }
            if (sent.Contains('.') && ((i+1) < textSplit.Length))
            {
                sent = sent.Replace(".", ".\n");
            }
            res += sent + ' ';
        }
        Text = res;
    }
    public void FindWords() // rework
    {
        string[] textSplit = Text.Split();
        string longest = "", shortest = "Pneumonoultramicroscopicsilicovolcanoconiosis";
        bool output = false;
        for (int i = 0; i < textSplit.Length; i++)
        {
            if (textSplit[i].Contains('.')) { output = true; }
            textSplit[i] = new string (textSplit[i].Where(c => !char.IsPunctuation(c)).ToArray());
            if (textSplit[i].Length > longest.Length) { longest = textSplit[i]; }
            if (textSplit[i].Length < shortest.Length) { shortest = textSplit[i]; }
            if (output == true) 
            { 
                Console.WriteLine($"Найдовше слово: {longest} | Найкоротше слово: {shortest}");
                longest = "";
                shortest = "Pneumonoultramicroscopicsilicovolcanoconiosis";
                output = false;
            }
        }
    }
    #endregion
}