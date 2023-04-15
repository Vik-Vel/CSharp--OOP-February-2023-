using System;
using System.Linq;
using ShoppingSpreeAgain.Models;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();

//Слагаме ги в трай и кеч, за да видим дали някъде ще хване грешка, ако хване искаме програмата да приключи направо
try
{
    //Взимаме първи ред от конзолата и го разделяме по ;.
    string[] allPeopleAndMoney = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);


    //След като сме взели първия ред, трябва да минем по разделените му части и да ги разделим с =, за да можем да вземем отделно парите и отделно имената на хората.
    foreach (var personAndMoney in allPeopleAndMoney)
    {
        //Разделяме на име и пари
        string[] nameAndMoney = personAndMoney.Split("=", StringSplitOptions.RemoveEmptyEntries);

        string personName = nameAndMoney[0];
        decimal moneyHeHas = decimal.Parse(nameAndMoney[1]);

        //Създаваме си person от клас Person, който има име и пари
        Person person = new Person(personName, moneyHeHas);

        //Добавяме човека към листа с Хората
        people.Add(person);
    }
    string[] allProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

    foreach (var productAndCost in allProducts)
    {
        //Разделяме на име на продукта и стойността му
        string[] nameAndCost = productAndCost.Split("=", StringSplitOptions.RemoveEmptyEntries);

        string productName = nameAndCost[0];
        decimal costOfProduct = decimal.Parse(nameAndCost[1]);

        //Създаваме си product от клас Product, който има име на продукта и стойност
        Product product = new Product(productName, costOfProduct);

        //Добавяме продукта към листта с Продукти
        products.Add(product);
    }
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return ;
}

//Ако всичко е минало успешно и нямаме грешки - продължаваме 
string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] personAndProduct = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string personName = personAndProduct[0];
    string productName = personAndProduct[1];

    Person person = people.FirstOrDefault(p => p.Name == personName);
    Product product = products.FirstOrDefault(p => p.Name == productName);

    if (person is not null && product is not null)
    {
        Console.WriteLine(person.AddProduct(product));
    }

}

Console.WriteLine(string.Join(Environment.NewLine,people));


