using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private int health;
        private int experience;
        //Атрибутът [SetUp] означава, че методът Setup() ще се изпълни преди всяко тестване в класа.

        //В метода Setup() се инициализират четири променливи:
        
        //health - число, което показва живота на обекта dummy
        //experience - число, което показва опита на обекта dummy
        //dummy - обект от класа Dummy, който има живот и опит,     зададени от  health и experience съответно.Това е обектът, който ще бъде тестван.
        //deadDummy - обект от класа Dummy, който също има зададени  живот и  опит, но е бил убит преди теста да започне, като е  получил удар с голяма сила.
        //Обектът deadDummy се използва за тестване на метода TakeAttack(),който трябва да провери дали живота на обекта dummy ще бъде намален до 0, когато получи удар със сила по-голяма от текущия му живот.

       [SetUp]
        public void Setup()
        {
            health = 10;
            experience = 15;
            dummy = new Dummy(health,experience);
            deadDummy = new Dummy(health, experience);
            deadDummy.TakeAttack(health + 10);
        }
        //Assert.AreEqual сравнява двата обекта на база на тяхното съдържание, а не на тяхната референция. Това означава, че два обекта с еднакво съдържание, но различни референции, ще се считат за равни от Assert.AreEqual.

        [Test] 
        public void Test_DummyConstructorShouldSetDataCorectly()
        {
            Assert.AreEqual(health, dummy.Health);

        }

        //В този тест се извиква методът TakeAttack(int damage) на обекта dummy, който намалява живота му спрямо дадената му сила на удара - damage.
        //След това се използва методът Assert.AreEqual() за да се провери дали живота на обекта dummy се е намалил с точно 5 (което е дадено в удара). Ако живота е намален правилно, то очакваната стойност на живота ще бъде health - 5, където health е началната стойност на живота на dummy, която е зададена в SetUp() метода.Ако стойността на живота е различна, тестът ще фейлне и ще се даде съобщение за грешка.
        //Този тест проверява дали методът TakeAttack(int damage) на класа Dummy намалява правилно живота на обекта dummy, когато получи удар с дадената сила.
       
        [Test] //Dummy loses health if attacked
        public void Test_DummyLosesHealthWhenAttacked()
        {
            dummy.TakeAttack(5);
            Assert.AreEqual(health - 5, dummy.Health); 


        }

        //Този тест проверява дали методът TakeAttack(int attackPoints) на обект от тип dummy ще хвърли изключение от тип InvalidOperationException, когато му се подаде аргумент attackPoints, след като текущото му здраве е вече равно на нула. Тестът първо извиква метода TakeAttack на обекта dummy с аргумент равен на текущото му здраве, което трябва да го убие. След това, тестът очаква да види изключение от тип InvalidOperationException, когато се опита да извика отново TakeAttack с аргумент равен на 1.
        //Тестът се очаква да мине успешно(да не хвърли изключение), ако TakeAttack не хвърли изключение при първото му извикване или ако изключението, хвърлено при второто извикване е различно от InvalidOperationException.
       
        [Test] //Dead Dummy throws an exception if attacked
        public void Test_DummyShouldThrowExeptionWhenAttackedAndHealthIsZero()
        {
            dummy.TakeAttack(health);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        //Този тест проверява дали методът TakeAttack(int attackPoints) на обект от тип deadDummy ще хвърли изключение от тип InvalidOperationException, когато му се подаде аргумент attackPoints, по-голям от текущото му здраве, т.е. когато здравето му е по-малко от нула. Тестът се очаква да мине успешно (да не хвърли изключение), ако TakeAttack не хвърли изключение или ако хвърли изключение, различно от InvalidOperationException.

        [Test]//Dead Dummy throws an exception if attacked
        public void Test_DummyShouldThrowExeptionWhenAttackedAndHealthBelowZero()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(1);
            });
        }
        //Тестът започва като извиква метода GiveExperience() на обекта deadDummy, който се очаква да върне числовата стойност на опита, придобит след убиването на deadDummy. След това тестът сравнява върнатата стойност със стойността на променливата experience, която предварително е зададена. Ако двете стойности съвпадат, тестът се счита за успешен, в противен случай - за провален.

        [Test]//Dead Dummy can give XP
        public void Test_DummyShouldGiveExperienceWhenIsDead()
        {
            var dummyExperience = deadDummy.GiveExperience();
            Assert.AreEqual(experience, dummyExperience);
        }

        //Този тест проверява дали методът GiveExperience() на обект от тип dummy ще хвърли изключение от тип InvalidOperationException, когато се опита да се извика върху жив обект.
        //Тестът очаква да види изключение от тип InvalidOperationException, когато се опита да извика GiveExperience() върху обекта dummy, който все още е жив.Ако методът не хвърли изключение, или хвърли изключение от друг тип, тестът ще се провали.
       
        [Test] //Alive Dummy can't give XP
        public void Test_DummyGiveExperienceShouldThrowExeptions_WhenDummyIsAlve()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}