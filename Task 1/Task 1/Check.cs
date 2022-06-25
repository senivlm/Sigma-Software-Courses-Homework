static class Check
{
    public static void Purchase(Buy buy)
    {
        Console.WriteLine($"Кількість товарів: {buy.PurchaseAmount} | Ціна за весь товар: {buy.PurchasePrice} | Вага всього товару: {buy.PurchaseWeight}");
    }
}