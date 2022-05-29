public class Check
{
    public void product(string name, int price, int weight)
    {
        Console.WriteLine($"Название: {name} \t Цена: {price} (гр) \t Вес: {weight} (г)");
    }

    public void purchase(int num, int price, int weight)
    {
        Console.WriteLine($"Количество товаров: {num} (шт) \t Цена за весь товар: {price} (гр) \t Вес всего товара: {weight} (г)");
    }
}