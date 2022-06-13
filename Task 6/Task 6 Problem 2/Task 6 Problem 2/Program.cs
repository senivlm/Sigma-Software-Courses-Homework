using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        TextWorker fileWorker = new TextWorker("..\\..\\..\\data\\");
        fileWorker.ReadFromFile();
        fileWorker.SplitText();
        //Ім'я файлу краще передавати як параметр
        fileWorker.WritoToFile();
        fileWorker.FindWords();
    }
}
