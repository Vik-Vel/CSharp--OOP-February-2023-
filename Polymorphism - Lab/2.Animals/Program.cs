



using _2.Animals;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {

            Animal animal = new Cat("Koti", "negativni emocii");
            Console.WriteLine(animal.ExplainSelf());

            animal = new Dog("Kuchi", "pozitivni emocii i salam");
            Console.WriteLine(animal.ExplainSelf());


        }
    }
}
