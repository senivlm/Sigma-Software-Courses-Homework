using System;
using System.Text;

// Task 1 in developing
class Program
{
    static void Main(string[] args)
    {
        List <Consumer> consumers = new List <Consumer> ();
        RandomInitialization.RandomConsumers(consumers, 10); // get number of consumers from user
        for (int i = 0; i < consumers.Count; i++)
        {
            RandomInitialization.RandomMeterings(consumers[i]);
        }
        int quarter = 3; // get quarter from user
        string path = "D:\\Sigma-Software-Courses-Homework\\Task 6\\Task 6 Problem 1\\Task 6 Problem 1\\";
        FileWorker.CreateDataFile(consumers, path, quarter);
    }
}