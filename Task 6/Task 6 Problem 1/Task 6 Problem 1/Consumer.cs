class Consumer
{
    private string _surname;
    private int _apartmentNumber;
    public List<Metering> meterings;
    public string Surname
    {
        get => _surname;
        set => _surname = value;
    }

    public int ApartmentNumber
    {
        get => _apartmentNumber;
        set => _apartmentNumber = value;
    }

    public Consumer(string surname, int apartmentNumber) 
    { 
        _surname = surname;
        _apartmentNumber = apartmentNumber;
        meterings = new List<Metering>();
    }

    public void AddMetering(Metering metering)
    {
        meterings.Add(metering);
    }

    public int GetMeteringsCount()
    {
        return meterings.Count;
    }
    public int GetMeteringIndicator(int index)
    {
        return meterings[index].counterIndicator;
    }
    
    public DateTime GetMeteringIndicatorDate(int index)
    {
        return meterings[index].takingIndicatorDate;
    }
}