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
        //Assert.AreEqual �������� ����� ������ �� ���� �� ������� ����������, � �� �� ������� ����������. ���� ��������, �� ��� ������ � ������� ����������, �� �������� ����������, �� �� ������ �� ����� �� Assert.AreEqual.
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }


        //���� ���� ��������� ���� ������ (axe) �� ���� ����� �� �������� (DurabilityPoints) ���� ����� �����.
        // � ����� �� ��������� 5 ����� �� �������� ����� "dummy" �����.���� ���� �� ��������� ���� ����� ����� �� �������� �� �������� �� �������� � ����� 5, ���� �� �������� Assert.AreEqual.
        //��� �������� ���� ����� �� �������� ���� ����� �����, ���������� �������� (durabilityPoints - 5) �� ���� ����� �� ���������� �������� �� DurabilityPoints �� ��������.� �������� ������, ������ �� �� ����� � �� �������� ������.
        [Test]
        public void Test_AxeShoultLooseDurabilityPointsAfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }


            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints);
        }

        /*���� ����, ������ ����������� �� ������ Attack �� ����� Axe, ������ Durability �� �������� � 0. ������ ��������� ���� ��� ������������ �� ������ Attack � Durability ����� �� 0, �� ������ ���������� �� ��� InvalidOperationException.

          �� ���� ����� ������ �� �������, �� �������� �� ������ ����������, ��� �� �������� ���� ��������� �� �������� �� �����������, �� �� �� ������� ������������� �� ����, ����� �������� ��������.*/
        [Test]
        public void Test_AxeAttackShouldThrowExeption_WhenDurabilityIs0()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }

        /*���� ����, ������ ����������� �� ������ Attack �� ����� Axe, ������ Durability �� �������� � ����������� �����. ������ ��������� ���� ��� ������������ �� ������ Attack � Durability ����� �� ����������� �����, �� ������ ���������� �� ��� InvalidOperationException.

         �� ���� ����� ������ �� �������, �� �������� �� ������ ����������, ��� �� �������� ���� ��������� �� �������� �� �����������, �� �� �� ������� ������������� �� ����, ����� �������� ��������.*/
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