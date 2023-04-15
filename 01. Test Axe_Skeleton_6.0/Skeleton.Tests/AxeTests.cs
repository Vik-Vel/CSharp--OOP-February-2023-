using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private Axe axe;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(100, 100);
        }
        [Test]
        //Assert.AreEqual сравнява двата обекта на база на тяхното съдържание, а не на тяхната референция. Това означава, че два обекта с еднакво съдържание, но различни референции, ще се считат за равни от Assert.AreEqual.
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }


        //Този тест проверява дали брадва (axe) ще губи точки на здравето (DurabilityPoints) след всяка атака.
        // В теста се извършват 5 атаки от брадвата върху "dummy" обект.След това се проверява дали броят точки на здравето на брадвата са намалели с точно 5, като се използва Assert.AreEqual.
        //Ако брадвата губи точки на здравето след всяка атака, очакваната стойност (durabilityPoints - 5) ще бъде равна на актуалната стойност на DurabilityPoints на брадвата.В противен случай, тестът ще не успее и ще генерира грешка.
        [Test]
        public void Test_AxeShoultLooseDurabilityPointsAfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }


            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints);
        }

        /*Този тест, тества поведението на метода Attack от класа Axe, когато Durability на оръжието е 0. Тестът проверява дали при изпълнението на метода Attack с Durability равно на 0, се хвърля изключение от тип InvalidOperationException.

          По този начин тестът се уверява, че оръжието ще хвърли изключение, ако се използва след достигане на нулевата му устойчивост, за да се избегне дефектирането на кода, който използва оръжието.*/
        [Test]
        public void Test_AxeAttackShouldThrowExeption_WhenDurabilityIs0()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }

        /*Този тест, тества поведението на метода Attack от класа Axe, когато Durability на оръжието е отрицателно число. Тестът проверява дали при изпълнението на метода Attack с Durability равно на отрицателно число, се хвърля изключение от тип InvalidOperationException.

         По този начин тестът се уверява, че оръжието ще хвърли изключение, ако се използва след достигане на нулевата му устойчивост, за да се избегне дефектирането на кода, който използва оръжието.*/
        [Test]
        public void Test_AxeAttackShouldThrowExeption_WhenDurabilityIsNegative()
        {
            axe = new(10, -5);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }
    }
}