class Check
{
    public void purchase(Buy buy)
    {
        Console.WriteLine($"Кількість товарів: {buy.purchaseAmount} | Ціна за весь товар: {buy.purchasePrice} | Вага всього товару: {buy.purchaseWeight}");
    }
}