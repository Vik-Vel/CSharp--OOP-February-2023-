

Lion lion = new();
lion.Roar();
class Animal
{
    private int privateField = 1;
    protected int protectedField = 2; //vijda se v klasa i vuv vsichki deca
    internal int internalField = 3;
    public int publicField = 4;
}

class Lion : Animal
{
    public void Roar()
    {
        //Console.WriteLine(privateField); ne moje da se dostupi
        Console.WriteLine(protectedField);
        Console.WriteLine(internalField);
        Console.WriteLine(publicField);
    }
}