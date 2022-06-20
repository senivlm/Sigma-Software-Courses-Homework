class Consumer
{
    #region Variables
    private string _surname;
    private int _apartmentNumber;
    public const decimal price = 1.5m;
    public List<Metering> meterings;
    #endregion

    #region Properties
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
    #endregion

    #region Constructors
    public Consumer(string surname, int apartmentNumber) 
    { 
        _surname = surname;
        _apartmentNumber = apartmentNumber;
        meterings = new List<Metering>();
    }
    #endregion

    #region Methods
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

    public static decimal GetDebt(Consumer consumer)
    {
        decimal debt = (consumer.GetMeteringIndicator(2) - consumer.GetMeteringIndicator(0)) * price;
        return debt;
    }

    public static int FindLargestDebt(List<Consumer> consumers)
    {
        decimal largestDebt = 0;
        int index = 0;
        for (int i = 0; i < consumers.Count; i++)
        {
            decimal debt = Consumer.GetDebt(consumers[i]);
            if (debt > largestDebt)
            {
                largestDebt = debt;
                index = i;
            }
        }
        return index;
    }

    public static List<int> FindExempt(List<Consumer> consumers)
    {
        List<int> exempts = new List<int>();
        
        //Можна використовувати AddRange()
        for (int i = 0; i < consumers.Count; i++)
        {
            if (Consumer.GetDebt(consumers[i]) == 0)
            {
                exempts.Add(i);
            }
        }
        return exempts;
    }

    public int GetHashCode()
    {
        return _surname.GetHashCode()^_apartmentNumber.GetHashCode();
    }
    #endregion
}
class ConsumerList<Consumer> : List<Consumer>
{
    public static ConsumerList<Consumer> operator +(ConsumerList<Consumer> a, ConsumerList<Consumer> b)
    {
        for (int i = 0; i < b.Count; i++)
        {// 
            if (a.GetHashCode() != b.GetHashCode())
            {
                a.Add(b[i]);
            }
        }
        return a;
    }

    public static ConsumerList<Consumer> operator -(ConsumerList<Consumer> a, ConsumerList<Consumer> b)
    {//множини б краще підійшли
        foreach (Consumer consumer1 in a.ToList())
        {
            foreach (Consumer consumer2 in b.ToList())
            {
                if (consumer1.GetHashCode() == consumer2.GetHashCode())
                {
                    a.Remove(consumer1);
                }
            }
        }
        return a;
    }
}
