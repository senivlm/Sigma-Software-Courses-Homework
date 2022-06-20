class Product
{
    #region Variables
    private string _name;
    private decimal _price;
    private int _weight;
    #endregion

    #region Properties
    public string Name
    {
        get => _name;
        set
        {
            if (value.Any(char.IsDigit))
            {
                throw new Exception($"Назва продукту не може містити числа! (\"{value}\")");
            }
            _name = value;
        }
    }
    public decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
            {
                throw new Exception($"Ціна продукту не може бути меншою або рівною нулю! ({_name} != {value}грн)");
            }
            _price = value;
        }
    }
    public int Weight
    {
        get => _weight;
        set
        {
            if (value <= 0)
            {
                throw new Exception($"Вага продукту не може бути меншою або рівною нулю! ({_name} != {value}г)");
            }
            _weight = value;
        }
    }
    #endregion

    #region Constructors
    public Product(string name, int weight)
    {
        Name = name;
        Weight = weight;
        if (Storage.FindPriceForProduct(name) != null)
        {
            Price = (decimal)(weight * Storage.FindPriceForProduct(name)/1000);
        }
        else
        {
            Storage.GetProductPriceInDialog(name);
        }
    }
    #endregion
}