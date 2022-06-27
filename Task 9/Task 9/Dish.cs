class Dish
{
    #region Variables
    private string _name;
    private List<Product> _ingredients;
    #endregion

    #region Properties
    public string Name
    {
        get => _name;
        set
        {
            if (value.Any(char.IsDigit)) throw new Exception($"Назва блюда не може містити числа! (\"{value}\")");
            _name = value;
        }
    }
    #endregion

    #region Constructors
    public Dish(string name, List<Product> ingredients)
    {
        Name = name;
        _ingredients = ingredients;
    }
    #endregion


    #region Methods
    public List<Product> GetIngredients()
    {
        return _ingredients;
    }
    #endregion
}