using System;

public static class Program
{
    public static void Main()
    {
        // Create 3 obejects for example
        Product Sugar = new Product("Sugar", 28, 1000);
        Product Bread = new Product("Bread", 22, 350);
        Product Pasta = new Product("Pasta", 97, 500);

        // Creating an array of products that are available for purchase
        Product[] ProductsSet = new Product[3];
        ProductsSet[0] = Sugar;
        ProductsSet[1] = Bread;
        ProductsSet[2] = Pasta;


        Check check = new Check();

        for (int i = 0; i < ProductsSet.Length; i++)
        {
            check.product(ProductsSet[i].name, ProductsSet[i].price, ProductsSet[i].weight);
        }

        Buy First_Buy = new Buy(ProductsSet, 3, 2, 4); // 3 is a number of ProductsSet[0] (Sugar) etc.
        check.purchase(First_Buy.purchase_num, First_Buy.price_sum, First_Buy.weight_sum);
        Console.ReadKey();
    }
}
