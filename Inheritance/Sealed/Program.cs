



//sealed class  Animal // Veche luvut ne moje da go nasledi
//{

//}

//class Lion :  Animal
//{

//}

public class Animal 
{
    public virtual void Sleep()
    {
        Console.WriteLine("Sleeping");
    }
}

sealed class Lion : Animal
{
    public sealed override void Sleep() // metoda ne move da se nasledqva i nadolu nqma da mogat da go nasledqvat
    {
        base.Sleep();
    }
}