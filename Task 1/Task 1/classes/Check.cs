static class Check
{
    public static void Purchase()
    {
        Console.WriteLine($"Кількість товарів: {Buy.PurchaseAmount} | Ціна за весь товар: {Buy.PurchasePrice} | Вага всього товару: {Buy.PurchaseWeight}");
    }
}