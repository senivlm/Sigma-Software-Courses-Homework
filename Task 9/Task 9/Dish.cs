class Dish
{
    private string _name;
    public List<Product> _ingredients;

    public Dish(string name, List<Product> ingredients)
    {
        _name = name;
        _ingredients = ingredients;
    }
}