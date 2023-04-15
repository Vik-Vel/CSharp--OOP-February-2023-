using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        //Задаваме си помощна променлива от клас Хотел
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            //Имплементираме и дефолтни стойности
            hotel = new("Blu", 5);
        }

        //Тестваме конструктора и дали сетърите сетват името и категорията правилно
        [Test]
        public void ConstructorSetsFullNameAndCategoryCorrectly()
        {
            string expectedFullName = "Blu";
            int expectedCategory = 3;

            Hotel hotel = new(expectedFullName, expectedCategory);

            Assert.That(hotel.FullName, Is.EqualTo(expectedFullName));
            Assert.That(hotel.Category, Is.EqualTo(expectedCategory));
        }
        //тестваме дали сетъра на името ще хвърли грешка, ако е някой от следните кейсове:
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("       ")]
        public void FullNameSetterThrowsExceptionWhenValueIsNullOrWhiteSpace(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 5));
        }

        //тестваме дали сетъра на категорията ще хвърли грешка, ако е някой от следните кейсове:
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(6)]
        [TestCase(10)]
        public void CategorySetterThrowsExceptionWhenValueOutOfRange(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Bly", category));
        }

        //тестваме дали се добавя стая правилно
        [Test]
        public void AddRoomAddsRoomCorrectly()
        {
            Room room = new(3, 100);

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        //тестваме дали хвърля грешка, когато се регистрира стая без възрастни със следните кейсове:
        [TestCase(0)]
        [TestCase(-10)]
        public void BookRoomThrowsExceptionWhenThereAreNoAdults(int adults)
        {
            Room room = new(3, 100);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 3, 200));
        }
        //тестваме дали хвърля грешка, когато се регистрира стая без деца със отрицателни числа със следните кейсове:
        [TestCase(-1)]
        [TestCase(-10)]
        public void BookRoomThrowsExceptionWhenChildrenAreLessThanZero(int children)
        {
            Room room = new(3, 100);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, children, 3, 200));
        }

        //тестваме дали хвърля грешка, когато се регистрира стая без продължителност:
        [TestCase(0)]
        [TestCase(-10)]
        public void BookRoomThrowsExceptionWhenThereIsNoResidenceDuration(int residenceDuration)
        {
            Room room = new(3, 55);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 1, residenceDuration, 200));
        }

        //тестваме дали получаваме оборот, ако няма достатъчно легла
        [Test]
        public void BookRoomNoTurnoverWhenNotEnoughBeds()
        {
            Room room = new(3, 100);

            hotel.AddRoom(room);
            hotel.BookRoom(4,1,2,200);

            Assert.That(hotel.Turnover.Equals(0));
        }
        //тестваме дали добавяме стая, ако бюджета е по-малък 
        [Test]
        public void BookRoomNoBookingWhenBudgetTooLow()
        {
            Room room = new(5, 70);

            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 100);

            double expectedTurnover = 0;

            Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
            Assert.That(hotel.Bookings.Count,Is.EqualTo(0));
            Assert.That(hotel.Rooms.Count,Is.EqualTo(1));
        }

        //тестваме дали всичко е нарред 
        [Test]
        public void BookRoomBooksRoomProperly()
        {
            Room room = new(5, 70);

            hotel.AddRoom(room);
            hotel.BookRoom(4,1,2,150);

            double expectedTurnover = 140;

            Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }
    }
}