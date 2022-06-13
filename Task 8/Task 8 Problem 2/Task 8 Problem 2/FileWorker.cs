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
            foreach (KeyValuePair<string, int> kvp in visitors)
            {
                streamWriter.WriteLine(kvp.Key + "\t" + kvp.Value);
            }
        }
    }

    public static void WriteMostPopularDayVisitor(Dictionary<string, KeyValuePair<DayOfWeek, int>> days, string path, string filename)
    {
        using (StreamWriter streamWriter = new(path + filename))
        {
            foreach (KeyValuePair<string, KeyValuePair<DayOfWeek, int>> kvp in days)
            {
                streamWriter.WriteLine(kvp.Key + " " + kvp.Value.Key + " " + kvp.Value.Value);
            }
        }
    }

    public static void GetMostPopularHourVisitor(Dictionary<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> visitors, string path, string filename)
    {
        using (StreamWriter streamWriter = new(path + filename))
        {
            foreach (KeyValuePair<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> kvp in visitors)
            {
                streamWriter.WriteLine(kvp.Key + "\t" + kvp.Value.Key.Key + "-" + kvp.Value.Key.Value + "\t" + kvp.Value.Value);
            }
        }
    }
}

