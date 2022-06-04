static class RandomInitialization
{
    public static void RandomConsumers(List <Consumer> consumers, int number)
    {
        string[] consumersSurnames = new string[] {"James", "Robert", "John", "Michael", "David", "William", "Richard", "Joseph" };
        Random random = new Random();
        for (int i = 0; i < number; i++)
        {
            string surname = consumersSurnames[random.Next(0, consumersSurnames.Length-1)];
            Consumer consumer = new(surname, i+1);
            consumers.Add(consumer);
        }
    }
    public static void RandomMeterings(Consumer consumer)
    {
        Random random = new Random();
        int indicator = random.Next(0, 10000);
        for (int i = 0; i < 12; i++)
        {
            DateTime dateTime = new DateTime(2022, (i + 1), random.Next(1,DateTime.DaysInMonth(2022,(i + 1))));
            indicator += random.Next(0, 500);
            Metering metering = new(indicator, dateTime);
            consumer.AddMetering(metering);
        }
    }
}