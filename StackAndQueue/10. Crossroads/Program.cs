namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLineInSec = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int leftGreenLine = 0;
            string input ;
            //int passedCars = 0;

            Queue<string> cars = new Queue<string>();

            //seconds each car needs is the length of their name
            while ((input = Console.ReadLine()) != "END")
            {
                int secNeedEachCar = input.Length;
                cars.Enqueue(input);
                
                if (input == "green")
                {
                    greenLineInSec += freeWindow;
                    leftGreenLine = greenLineInSec;
                }

                if (greenLineInSec > secNeedEachCar)
                {
                    cars.Enqueue(input);
                    leftGreenLine -= secNeedEachCar;
                }

            }


        }
    }
}