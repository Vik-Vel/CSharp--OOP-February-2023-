


Lion lion = new();
Console.WriteLine(lion.Age);
lion.PrintAge(15);

class Animal
{
    public int Age = 8;
}

class Lion : Animal
{
    public int Age = 10; // Vzima stoinostta na deteto, zashtoto posledno e zadadeno. Ako iskame da go izpolzvame vse pak, bez da ni go podchertava -> new int Age. TOVA NE E CHETIM KOD

    public void PrintAge(int age)
    {
        Console.WriteLine(Age); //ot podadenata stoinost /red 6/
        Console.WriteLine(this.Age); //ot zadadenata stoinost na red 11
        Console.WriteLine(base.Age); // ot  bazovata stoinost na klasa Animal, red 6

    }
}