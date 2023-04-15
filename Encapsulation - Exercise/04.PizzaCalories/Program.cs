using System;
using PizzaCalories.Models;


//string input = string.Empty;


try
{
    string[] pizzaTokens = Console.ReadLine().Split();
    string[] doughTokens = Console.ReadLine().Split();

    string pizzaName = pizzaTokens[1];


    Dough dough = new(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));


    Pizza pizza = new(pizzaName, dough);

    while (true)
    {
        string toppingInput = Console.ReadLine();

        if (toppingInput == "END")
        {
            break;
        }

        string[] toppingTokens = toppingInput.Split();

        Topping topping = new(toppingTokens[1], double.Parse(toppingTokens[2]));

        pizza.AddTopping(topping);

    }
    Console.WriteLine(pizza);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
