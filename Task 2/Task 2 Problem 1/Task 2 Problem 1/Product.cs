class Product
{
    public string name;
    public decimal price, weight;
    public Product(string n, decimal p, decimal w) { name = n; price = p; weight = w; }
    private protected Product() { }
  
    public virtual void changeValue(decimal percent)
    {
        this.price += this.price * (percent/100);
    }
}
