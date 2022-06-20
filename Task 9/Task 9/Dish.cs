class Dish
{
    private string _name;
    public List<Product> _ingredients;

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
                throw new Exception($"Назва блюда не може містити числа! (\"{value}\")");
            }
        }
    }

    public Dish(string name, List<Product> ingredients)
    {
        Name = name;
        _ingredients = ingredients;
    }
}