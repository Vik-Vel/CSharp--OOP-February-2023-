using System;



namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defDb;
        //private int[] data;
        ///private int count;

        [SetUp]
        public void Setup()
        {
            this.defDb = new Database();

        }

        //Edge cases -> valid and invalid
        //Valid cases(1 Main Case + 2 Ege Case)
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldInitializedDataWithCorrectCount(int[] data)
        {
            //Arrage

            //Act
            Database db = new Database(data);

            //Assert
            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        // 1 Edge Invalid Case +1 Main Invalid Case 
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]

        public void ConstructorShouldThrowExceptionWhenInputDataIsAbove16Count(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //We will assume that Fetch() method is working just fine!
        //Този тест е за метод с име "ConstructorShouldAddElementsIntoDataField", който приема масив от цели числа като параметър и създава нов обект от класа "Database", като използва подадения масив като данни. Тестът проверява дали методът коректно добавя елементите от подадения масив в полето "data" на създадения обект.
        //Тестът използва атрибута "[TestCase]" за да определи три различни тестови случая.В първия случай подава празен масив, във втория случай подава масив от числата от 1 до 5, а в третия случай подава масив от числата от 1 до 16.
        //След това тестът използва метода "CollectionAssert.AreEqual()", за да сравни очакваните данни(подадения масив) със стойностите, върнати от метода "db.Fetch()", който връща копие на полето "data" в създадения обект.Ако двата масива са еднакви, тестът ще премине успешно.

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsIntoDataField(int[] data)
        {
            Database db = new Database(data);
            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        //I assume that Count property is tested and working fine!
        [Test]
        public void AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;
            //Arrange + Act
            for (int i = 1; i <= expectedCount; i++)
            {
                this.defDb.Add(i);
            }

            int actualCount = this.defDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        /*Този тест проверява дали методът "Add" на тестовия клас "defDb" коректно добавя елементи в масива, съхранен в обекта на "defDb".
         * Тестът първо инициализира очакваните данни като създава масив от 5 цели числа, като стойността на всеки елемент се задава от 1 до 5. След това тестът извиква метода "Add" на обекта "defDb" за да добави всеки елемент от 1 до 5 в масива.
         * След добавянето на всички елементи тестът извиква метода "Fetch" на обекта "defDb" и създава масив от получените данни. Той сравнява този масив с очакваните данни, използвайки метода "CollectionAssert.AreEqual".*/
        [Test]
        public void AddingElementsShouldAddThemToTheDataCollection()
        {
            int[] expectedData = new int[5];
            for (int i = 1; i <= 5; i++)
            {
                this.defDb.Add(i);
                expectedData[i - 1] = i;
            }
            //Тук копира данните от defDb, които сме взели от добавянето -> this.defDb.Add(i) и си правим нов масив, който да сравним
            int[] actualData = this.defDb.Fetch();
            CollectionAssert.AreEqual(expectedData, actualData);
        }


        [Test]
        public void AddingMoreThan16ElementsShouldThrowExeption()
        {
            //Adding elements to the full capacity
            for (int i = 1; i <= 16; i++)
            {
                this.defDb.Add(i);
            }

            //Ful capacity
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovingElementShouldDecreaseCount()
        {
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defDb.Remove();
            }
            int expectedCount = initialCount - removeCount;
            int actualCount = this.defDb.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void RemovingElementShouldRemoveItFromTheDataCollection()
        {

            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defDb.Remove();
            }
            int[] expectedData = new int[] {1, 2, 3 };
            int[] actualData = this.defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);

        }

        [Test]
        public void RemoveShouldThrowExceptionWhenThereAreNoElementsInDb()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Remove();
            }, "The collection is empty!");
        }

        //I assume that the constructor is working just fine!
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCollectionWithElementsInTheDb(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
