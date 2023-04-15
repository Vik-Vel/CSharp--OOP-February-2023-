

Lion lion = new();

//lion.Animal.Name

class Animal
{
    public string Name { get; set; }  

    public int Age { get; set; }
} 

class Lion
{
    public Animal Animal { get; set; }
}