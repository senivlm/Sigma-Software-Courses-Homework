class Product
{
    private string _name;

    public decimal price, weight;

    public string Name 
    { 
        get => _name;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                char[] charArr = value.ToCharArray();
                charArr[0] = char.ToUpper(charArr[0]);
                string temp = new string(charArr);
                _name = temp;
            }
            else
            {
                _name = value;
            }
        }
    }

    public Product(string n, decimal p, decimal w)
    {
        Name = n;
        price = p;
        weight = w;
    }
    protected Product() { }
    public virtual void ChangeValue(decimal percent)
    {
        price += price * (percent/100);
    }
}
