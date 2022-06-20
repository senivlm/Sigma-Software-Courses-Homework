class Product
{
    private string _name;
    private decimal _price;
    private int _weight;

    public string Name
    {
        get => _name;
        set
        {
            if (!value.Any(char.IsDigit))
            {
                _name = value;
            }
            else
            {
                throw new Exception($"Назва продукту не може містити числа! (\"{value}\")");
            }
        }
    }
    public decimal Price
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                _price = value;
            }
            else
            {
                throw new Exception($"Ціна продукту не може бути меншою або рівною нулю! ({_name} != {value}грн)");
            }
        }
    }
    public int Weight
    {
        get => _weight;
        set
        {
            if (value > 0)
            {
                _weight = value;
            }
            else
            {
                throw new Exception($"Вага продукту не може бути меншою або рівною нулю! ({_name} != {value}г)");
            }
        }
    }

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
}