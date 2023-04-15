using System;
using PizzaCalories.Models;

try
{
    string[] pizzaTokens = Console.ReadLine().Split();
    string[] doughTokens = Console.ReadLine().Split();

    string pizzaName = pizzaTokens[1];

    Dough dough = new Dough(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));

    Pizza pizza = new Pizza(pizzaName, dough);

    string input = Console.ReadLine();

    while (input != "END")
    {
        string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
       
            string toppingType = tokens[1];
            double grams = double.Parse(tokens[2]);

            Topping topping = new Topping(toppingType,grams);

            pizza.AddTopping(topping);
            

        input = Console.ReadLine();
    }

    Console.WriteLine(pizza);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


