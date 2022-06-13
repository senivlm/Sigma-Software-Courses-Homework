class TrafficWorker
{
    private List<VisitRecord> _visitRecords;

    public TrafficWorker(List<VisitRecord> visitRecords)
    {
        _visitRecords = visitRecords;
    }

    public Dictionary<string, int> GetNumberVisitsWeekVisitor()
    {
        Dictionary<string, int> visitors = new Dictionary<string, int>();

        for (int i = 0; i < _visitRecords.Count; i++)
        {
            if (!visitors.ContainsKey(_visitRecords[i].IP))
            {
                visitors.Add(_visitRecords[i].IP, 0);
            }
        }
        for (int i = 0; i < _visitRecords.Count; i++)
        {
            visitors[_visitRecords[i].IP] += 1;
        }
        return visitors;
    }

    public Dictionary<string, KeyValuePair<DayOfWeek, int>> GetMostPopularDayVisitor()
    {
        Dictionary<string, KeyValuePair<DayOfWeek, int>> visitors = new Dictionary<string, KeyValuePair<DayOfWeek, int>>();

        for (int i = 0; i < _visitRecords.Count; i++)
        {
            if (!visitors.ContainsKey(_visitRecords[i].IP))
            {
                Dictionary<DayOfWeek, int> days = new Dictionary<DayOfWeek, int>();
                for (int j = 0; j < _visitRecords.Count; j++) 
                {
                    if (_visitRecords[i].IP == _visitRecords[j].IP)
                    {
                        if (!days.ContainsKey(_visitRecords[j].Day))
                        {
                            days.Add(_visitRecords[j].Day, 1);
                        }
                        else
                        {
                            days[_visitRecords[j].Day] += 1;
                        }
                    }
                }
                DayOfWeek day = days.MaxBy(kvp => kvp.Value).Key;
                KeyValuePair<DayOfWeek, int> kvp = new KeyValuePair<DayOfWeek, int>(day, days[day]);
                visitors.Add(_visitRecords[i].IP, kvp);
            }
        }
        return visitors;
    }

    public Dictionary<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> GetMostPopularHourVisitor() // !add day dependent
    {
        Dictionary<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> visitors = new Dictionary<string, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>>();

        for (int i = 0; i < _visitRecords.Count; i++)
        {
            if (!visitors.ContainsKey(_visitRecords[i].IP))
            {
                List<TimeOnly> hour = new List<TimeOnly>();
                for (int j = 0; j < _visitRecords.Count; j++)
                {
                    if (_visitRecords[i].IP == _visitRecords[j].IP)
                    {
                        hour.Add(_visitRecords[j].Time);
                    }
                }
                int max = 0, indexStart = 0, indexEnd = 0;
                for (int j = 0; j < hour.Count; j++)
                {
                    int k = j + 1;
                    while (k < hour.Count)
                    {
                        TimeSpan time = hour[k] - hour[j];
                        if (time.TotalMinutes < 60)
                        {
                            if (k - j > max)
                            {
                                max = k - j;
                                indexStart = j;
                                indexEnd = k;
                            }
                        }
                        k++; 
                    }
                }
                KeyValuePair<TimeOnly, TimeOnly> kvpTT = new(hour[indexStart], hour[indexEnd]);
                KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int> kvpTI = new(kvpTT, max);
                visitors.Add(_visitRecords[i].IP, kvpTI);
            }
        }
        return visitors;
    }

    public Dictionary<DayOfWeek, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> GetMostPopularHour()
    {
        Dictionary<DayOfWeek, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>> days = new Dictionary<DayOfWeek, KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int>>();

        for (int i = 0; i < 7; i++) // 7 days in week
        {
            DayOfWeek dayOfWeek = (DayOfWeek)i;
            List<TimeOnly> hour = new List<TimeOnly>();
            int max = 0, indexStart = 0, indexEnd = 0;
            
            for (int j = 0; j < _visitRecords.Count; j++)
            {
                if (dayOfWeek == _visitRecords[j].Day)
                {
                    hour.Add(_visitRecords[j].Time);
                }
            }

            for (int n = 0; n < hour.Count; n++)
            {
                int k = n + 1;
                while (k < hour.Count)
                {
                    TimeSpan time = hour[k] - hour[n];
                    if (time.TotalMinutes < 60)
                    {
                        if (k - n > max)
                        {
                            max = k - n;
                            indexStart = n;
                            indexEnd = k;
                        }
                    }
                    k++;
                }
            }
            if (hour.Count != 0)
            {
                KeyValuePair<TimeOnly, TimeOnly> kvpTT = new(hour[indexStart], hour[indexEnd]);
                KeyValuePair<KeyValuePair<TimeOnly, TimeOnly>, int> kvpTI = new(kvpTT, max + 1);
                days.Add(dayOfWeek, kvpTI);
            }
        }
        return days;
    }
}