using System;
using System.Collections.Generic;

public class Product : ICloneable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public object Clone()
    {
        return new Product(Name, Price, Quantity);
    }

    public override string ToString()
    {
        return $"{Name}, Price: {Price}, Quantity: {Quantity}";
    }
}

public class Discount : ICloneable
{
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public Discount(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }

    public object Clone()
    {
        return new Discount(Name, Amount);
    }

    public override string ToString()
    {
        return $"{Name}, Amount: {Amount}";
    }
}

public class Order : ICloneable
{
    public List<Product> Products { get; set; }
    public decimal DeliveryCost { get; set; }
    public Discount AppliedDiscount { get; set; }
    public string PaymentMethod { get; set; }

    public Order(List<Product> products, decimal deliveryCost, Discount discount, string paymentMethod)
    {
        Products = products;
        DeliveryCost = deliveryCost;
        AppliedDiscount = discount;
        PaymentMethod = paymentMethod;
    }

    
    public object Clone()
    {
        var clonedProducts = new List<Product>();
        foreach (var product in Products)
        {
            clonedProducts.Add((Product)product.Clone());
        }

        return new Order(clonedProducts, DeliveryCost, (Discount)AppliedDiscount.Clone(), PaymentMethod);
    }

    public override string ToString()
    {
        string productDetails = string.Join("\n", Products);
        return $"Products:\n{productDetails}\nDelivery Cost: {DeliveryCost}\nDiscount: {AppliedDiscount}\nPayment Method: {PaymentMethod}";
    }
}

class Program
{
    static void Main()
    {
        var product1 = new Product("Книга: Война и Мир", 500.00m, 1);
        var product2 = new Product("Тетрадь 96 листов", 40.00m, 5);

        var discount = new Discount("Осенняя распродажа", 50.00m);

        var originalOrder = new Order(new List<Product> { product1, product2 }, 150.00m, discount, "Наличный расчет");

        Console.WriteLine("Оригинальный заказ:");
        Console.WriteLine(originalOrder);

        var clonedOrder = (Order)originalOrder.Clone();

        clonedOrder.Products[0].Name = "Книга: Преступление и Наказание";
        clonedOrder.PaymentMethod = "Банковская карта";

        Console.WriteLine("\nКлонированный заказ (с изменениями):");
        Console.WriteLine(clonedOrder);

        Console.WriteLine("\nОригинальный заказ (после клонирования):");
        Console.WriteLine(originalOrder); 
    }
}

