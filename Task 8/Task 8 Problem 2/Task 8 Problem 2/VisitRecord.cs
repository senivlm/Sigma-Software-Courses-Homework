using System;
class VisitRecord
{
    public string IP { get; set; }
    public TimeOnly Time { get; set; }
    public DayOfWeek Day { get; set; }

    public VisitRecord(string ip, TimeOnly time, DayOfWeek day)
    {
        IP = ip;
        Time = time;
        Day = day;
    }
}