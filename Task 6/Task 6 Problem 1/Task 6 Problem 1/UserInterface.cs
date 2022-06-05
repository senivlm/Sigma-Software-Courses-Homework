static class UserInterface
{
    public static int GetNumberOfConsumers()
    {
        Console.Write("Введіть бажану кількість споживачів: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number <= 0)
        {
            throw new Exception("Number cannot be less or equal to zero!");
        }
        return number;
    }

    public static int GetQuarter()
    {
        Console.Write("Введіть номер кварталу: ");
        int quarter = Convert.ToInt32(Console.ReadLine());
        if (quarter > 4 || quarter < 0)
        {
            throw new Exception("Quarter cannot be more than 4 or less than zero!");
        }
        return quarter;
    }
}