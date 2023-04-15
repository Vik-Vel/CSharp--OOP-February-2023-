using System.Linq;
using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("Kaproni", 15);
        }

        [Test]
        public void ConstructorSetsFullNameAndCapacityCorrectly()
        {
            string expectedName = "Kaproni";
            int expectedCapacity = 15;

            Factory factory = new Factory(expectedName, expectedCapacity);

            Assert.That(factory.Name, Is.EqualTo(expectedName));
            Assert.That(factory.Capacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        public void ProduceRobotValidParams()
        {
            Factory factory = new Factory("Kaproni", 15);

            string actualResult = factory.ProduceRobot("Chico", 2500, 22);
            string expected = "Produced --> Robot model: Chico IS: 22, Price: 2500.00";

            Assert.AreEqual(expected, actualResult);
        }

        [Test]
        public void ProduceRobot_CheckAdding()
        {
            Factory factory = new Factory("Kaproni", 15);

            int expectedCountBeffore = 0;
            int actualResultBefore = factory.Robots.Count;

            factory.ProduceRobot("Chico", 2500, 22);

            int expecteAfter = 1;
            int actualResultAfter = factory.Robots.Count;

            Assert.AreEqual(expectedCountBeffore, actualResultBefore);
            Assert.AreEqual(expecteAfter, actualResultAfter);
        }

        [Test]
        public void ProduceRobot_CapacityFull()
        {
            Factory factory = new Factory("Kaproni", 1);

            factory.ProduceRobot("Chico", 2500, 22);

            string actualResultAfter = factory.ProduceRobot("Chico", 2500, 22);
            string expecteResult = "The factory is unable to produce more robots for this production day!";

            Assert.AreEqual(expecteResult, actualResultAfter);
        }

        [Test]
        public void ProduceSupplementsValidParams()
        {
            Factory factory = new Factory("Kaproni", 15);

            string actualResult = factory.ProduceSupplement("SpecialzedArm", 15);
            string expected = "Supplement: SpecialzedArm IS: 15";

            Assert.AreEqual(expected, actualResult);
        }

        [Test]
        public void ProduceSupplements_CheckAdding()
        {
            Factory factory = new Factory("Kaproni", 15);

            int expectedCountBeffore = 0;
            int actualResultBefore = factory.Supplements.Count;

            factory.ProduceSupplement("Chico", 22);

            int expecteAfter = 1;
            int actualResultAfter = factory.Supplements.Count;

            Assert.AreEqual(expectedCountBeffore, actualResultBefore);
            Assert.AreEqual(expecteAfter, actualResultAfter);
        }

        [Test]
        public void UpgradeRobot_Succesfull()
        {
            Factory factory = new Factory("Kaproni", 15);

            factory.ProduceRobot("Chico", 2500, 22);
            factory.ProduceSupplement("Chico", 22);

            var actualResult =
                factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void UpgradeRobot_AlredyUpgraded()
        {
            Factory factory = new Factory("Kaproni", 15);

            factory.ProduceRobot("Chico", 2500, 22);
            factory.ProduceSupplement("Chico", 22);

            factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            var actualResult =
                factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void UpgradeRobot_DifferentStandards()
        {
            Factory factory = new Factory("Kaproni", 11);

            factory.ProduceRobot("Chico", 2500, 22);
            factory.ProduceSupplement("Chico", 21);

            var actualResult =
                factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void SellRobot_Successful()
        {
            Factory factory = new Factory("Kaproni", 10);

            factory.ProduceRobot("Robo", 2000, 22);
            factory.ProduceRobot("Robo", 2500, 22);
            factory.ProduceRobot("Robo", 3000, 22);

            Robot robot = factory.Robots.FirstOrDefault(r=>r.Price == 2000);

            var robotSold = factory.SellRobot(2499);
            Assert.AreSame(robot,robotSold);
        }
    }
}