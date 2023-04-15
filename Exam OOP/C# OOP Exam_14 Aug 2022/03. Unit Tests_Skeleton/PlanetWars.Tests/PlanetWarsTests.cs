using NUnit.Framework;
using System;
using System.Numerics;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;
            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Mars", 200);
                weapon = new Weapon("Pushka", 400, 3);
            }


            [Test]
            public void ConstructorShouldSetNameCorrectly()
            {
                var planet = new Planet("Venus", 120);
                var expectedName = "Venus";

                Assert.That(planet.Name, Is.EqualTo(expectedName));
            }

            [Test]
            public void ConstructorShouldSetBudgetCorrectly()
            {
                var planet = new Planet("Venus", 200);
                double expectedBudget = 200;

                Assert.That(planet.Budget, Is.EqualTo(expectedBudget));
            }

            [TestCase(null)]
            [TestCase("")]
            public void NameSetterThrowsExceptionWhenValueIsNullOrEmpty(string fullName)
            {
                Assert.Throws<ArgumentException>(() => new Planet(fullName, 100));
            }

            [TestCase(-1)]
            [TestCase(-10)]
            public void BudgetSetterThrowsExceptionWhenValueIsNullOrWhiteSpace(double budget)
            {
                Assert.Throws<ArgumentException>(() => new Planet("Ploton", budget));
            }


        }
    }
}
