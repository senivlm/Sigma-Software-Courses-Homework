using System;

// 1. Для кожного ip вкажіть:
// кількість відвідувань на тиждень, (class TrafficWorker, method GetNumberVisitsWeekVisitor)
// найбільш популярний день тижня, (class TrafficWorker, method GetMostPopularDayVisitor)
// найбільш популярний відрізок часу довжиною в одну годину. (class TrafficWorker, method GetMostPopularHourVisitor)
// 2. Знайдіть також найбільш популярний відрізок часу в добі довжиною одну годину в цілому для сайту. (class TrafficWorker, method GetMostPopularHour)
// 3. Продумайте, як оптимально здійснити повторювану дію для різних даних.
// Output in data folder
public static class Program
{
    public static void Main()
    {
        string path = "..\\..\\..\\data\\";
        List<VisitRecord> visitRecords = new();
        FileWorker.GetVisitsFromFile(visitRecords, path, "DataBase.txt");
        TrafficWorker trafficWorker = new(visitRecords);

        var NumberVisitsWeekVisitor = trafficWorker.GetNumberVisitsWeekVisitor();
        FileWorker.WriteNumberVisitsWeekVisitor(NumberVisitsWeekVisitor, path, "NumberVisitsWeekVisitor.txt");

        var MostPopularDayVisitor = trafficWorker.GetMostPopularDayVisitor();
        FileWorker.WriteMostPopularDayVisitor(MostPopularDayVisitor, path, "MostPopularDayVisitor.txt");

        var MostPopularHourVisitor = trafficWorker.GetMostPopularHourVisitor();
        FileWorker.WriteMostPopularHourVisitor(MostPopularHourVisitor, path, "MostPopularHourVisitor.txt");

        var MostPopularHour = trafficWorker.GetMostPopularHour();
        FileWorker.WriteMostPopularHour(MostPopularHour, path, "MostPopularhour.txt");
    }
}