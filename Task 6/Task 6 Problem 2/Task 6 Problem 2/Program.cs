using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        string path = "..\\..\\..\\data\\";
        TextWorker fileWorker = new TextWorker(path);
        fileWorker.ReadFromFile();
        fileWorker.SplitText();
        fileWorker.WritoToFile();
        fileWorker.FindWords();
    }
}