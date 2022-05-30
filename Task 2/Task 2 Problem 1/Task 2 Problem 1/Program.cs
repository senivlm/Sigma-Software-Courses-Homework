using System;
using System.Text;


public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8; // Ukrainian symbols in console
        Interface UserInterface = new Interface();
        UserInterface.Menu();
        Console.ReadKey();
    }
}