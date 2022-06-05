using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        string path = "D:\\Sigma-Software-Courses-Homework\\Task 6\\Task 6 Problem 2\\Task 6 Problem 2\\data\\";
        TextWorker fileWorker = new TextWorker(path);
        fileWorker.ReadFromFile();
        fileWorker.SplitText();
        fileWorker.WritoToFile();
        fileWorker.FindWords();
    }
}