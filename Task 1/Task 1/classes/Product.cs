class Product
{
    private string _name;
    private decimal _price, _weight;
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
    public decimal Weight
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
    public Product(string n, int p, int w) { Name = n; Price = p; Weight = w; }
}