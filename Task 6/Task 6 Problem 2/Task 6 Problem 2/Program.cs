using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        TextWorker fileWorker = new TextWorker("..\\..\\..\\data\\");
        fileWorker.ReadFromFile();
        fileWorker.SplitText();
        fileWorker.WritoToFile();
        fileWorker.FindWords();
    }
}