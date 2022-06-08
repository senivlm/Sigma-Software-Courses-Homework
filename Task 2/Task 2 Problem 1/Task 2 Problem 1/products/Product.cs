class Product
{
    public string name;
    public decimal price, weight;
    public Product(string n, decimal p, decimal w) { name = n; price = p; weight = w; }
    protected Product() { }
    public virtual void ChangeValue(decimal percent)
    {
        price += price * (percent/100);
    }
}
