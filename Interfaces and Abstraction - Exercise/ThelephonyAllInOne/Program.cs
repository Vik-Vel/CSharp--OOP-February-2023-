using Telephony.Models;
using Telephony.Models.Interfaces;

string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

ICallable callable;

foreach (var phoneNumber in phoneNumbers)
{
    if (phoneNumber.Length == 10)
    {
        callable = new Smartphone();
    }
    else
    {
        callable = new Stationary();
    }

    try
    {
        Console.WriteLine(callable.Call(phoneNumber));
    }
    catch (ArgumentException ex)
    {

        Console.WriteLine(ex.Message);
    }
}

IBrowsable browsable = new Smartphone();

foreach (var url in urls)
{
    try
    {
        Console.WriteLine(browsable.Browse(url));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}