class Product
{
    #region Variables
    private string _name;
    public decimal price, weight;
    #endregion

    #region Properties
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
    #endregion

    #region Constructors
    public Product(string n, decimal p, decimal w)
    {
        Name = n;
        price = p;
        weight = w;
    }
    protected Product() { }
    #endregion

    #region Methods
    public virtual void ChangeValue(decimal percent)
    {
        price += price * (percent/100);
    }
    #endregion
}
