using System.Text;
static class FileWorker
{
    public static void GetVisitsFromFile(List<VisitRecord> visitRecords, string path, string filename)
    {
        using (StreamReader streamReader = new(path + filename))
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                var lineSplit = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                TimeOnly time = TimeOnly.Parse(lineSplit[1]);
                Enum.TryParse(typeof(DayOfWeek), lineSplit[2], true, out object day);
                visitRecords.Add(new VisitRecord(lineSplit[0], time, (DayOfWeek)day));
            }
        }
    }

    public static void WriteNumberVisitsWeekVisitor(Dictionary<string, int> visitors, string path, string filename)
    {
        using (StreamWriter streamWriter = new(path + filename))
        {
            streamWriter.WriteLine("-------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-15} |", "IP", "Visits number"));
            streamWriter.WriteLine("-------------------------------------");
            foreach (KeyValuePair<string, int> kvp in visitors)
            {
                streamWriter.WriteLine(String.Format("| {0,-15} | {1,-15} |", kvp.Key, kvp.Value));
            }
            streamWriter.WriteLine("-------------------------------------");
        }
    }

    public static void WriteMostPopularDayVisitor(Dictionary<string, KeyValuePair<DayOfWeek, int>> days, string path, string filename)
    {
        using (StreamWriter streamWriter = new(path + filename))
        {
            streamWriter.WriteLine("-----------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-15} | {2,-10} |", "IP", "Day of Week", "Visits number"));
            streamWriter.WriteLine("-----------------------------------------------------");
            foreach (KeyValuePair<string, KeyValuePair<DayOfWeek, int>> kvp in days)
            {
                streamWriter.WriteLine(String.Format("| {0,-15} | {1,-15} | {2,-13} |", kvp.Key, kvp.Value.Key, kvp.Value.Value));
            }
            streamWriter.WriteLine("-----------------------------------------------------");
        }
    }

    public static void WriteMostPopularHourVisitor(Dictionary<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> visitors, string path, string filename)
    {
        using (StreamWriter streamWriter = new(path + filename))
        {
            streamWriter.WriteLine("-------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-9}{2,0}{3,10} | {4,-10} |", "IP", "", "Time", "", "Visits number"));
            streamWriter.WriteLine("-------------------------------------------------------------");
            foreach (KeyValuePair<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> kvp in visitors)
            {
                streamWriter.WriteLine(String.Format("| {0,-15} | {1,10} - {2,-10} | {3,-13} |", kvp.Key, kvp.Value.Key.Key, kvp.Value.Key.Value, kvp.Value.Value));
            }
            streamWriter.WriteLine("-------------------------------------------------------------");
        }
    }

    public static void WriteMostPopularHour(Dictionary<DayOfWeek, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> days, string path, string filename)
    {
        using (StreamWriter streamWriter = new(path + filename))
        {
            streamWriter.WriteLine("-------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-9}{2,0}{3,10} | {4,-10} |", "Day of week", "", "Time", "", "Visits number"));
            streamWriter.WriteLine("-------------------------------------------------------------");
            foreach (KeyValuePair<DayOfWeek, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> kvp in days)
            {
                streamWriter.WriteLine(String.Format("| {0,-15} | {1,10} - {2,-10} | {3,-13} |", kvp.Key, kvp.Value.Key.Key, kvp.Value.Key.Value, kvp.Value.Value));
            }
            streamWriter.WriteLine("-------------------------------------------------------------");
        }
    }
}

