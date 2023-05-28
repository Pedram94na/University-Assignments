using NUnit.Framework;
using Task4;
using System.Collections.Generic;

namespace MatriceUnitTest
{
    public class MatriceTest
    {
        private Matrice matriceTest { get; set; } = null;
        private Menu menuTest { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            matriceTest = new Matrice();
            menuTest = new Menu();
        }

        #region Matrice - Valid Test Cases

        [TestCase(5, 2, 3)]
        [TestCase(9, 4, 5)]

        [Test]
        public void BoundCheckTestValid(int n, int b1, int b2)
            => Assert.IsFalse(matriceTest.BoundCheck(n, b1, b2));

        [TestCase(2, 3)]
        [TestCase(4, 5)]

        [Test]
        public void OrderCheckTestValid(int b1, int b2)
            => Assert.IsFalse(matriceTest.OrderCheck(b1, b2));

        [TestCase(5, 2, 3)]
        [TestCase(9, 4, 5)]

        [Test]
        public void SumCheckTestValid(int n, int b1, int b2)
            => Assert.IsFalse(matriceTest.SumCheck(n, b1, b2));

        [Test]
        public void EntryCheckValid()
        {
            List<int> inputList = new List<int> { 1, 2, 3 };

            Assert.IsFalse(matriceTest.EntryCheck(inputList, 0, 1));
        }
        #endregion

        #region Matrice - Invalid Test Case

        [TestCase(-2 ,5, 4)]
        [TestCase(0 ,100, 99)]

        [Test]
        public void BoundCheckTestInvalid(int n, int b1, int b2)
            => Assert.IsTrue(matriceTest.BoundCheck(n, b1, b2));

        [TestCase(5, 4)]
        [TestCase(100, 99)]

        [Test]
        public void OrderCheckTestInvalid(int b1, int b2)
            => Assert.IsTrue(matriceTest.OrderCheck(b1, b2));

        [TestCase(3, 5, 10)]
        [TestCase(7, 2, 4)]

        [Test]
        public void SumCheckTestInvalid(int n, int b1, int b2)
            => Assert.IsTrue(matriceTest.SumCheck(n, b1, b2));

        [Test]
        public void EntryCheckInvalid()
        {
            List<int> inputList = new List<int> { 1, 2, 3 };

            Assert.IsTrue(matriceTest.EntryCheck(inputList, 6, 8));
        }
        #endregion

        #region Menu - Valid Test Cases
        [TestCase("5 2 3")]
        [TestCase("9 4 5")]

        [Test]
        public void MatriceInputCheckValid(string input)
            => Assert.IsTrue(menuTest.MatriceInputCheck(input));

        [TestCase("2" ,0)]
        [TestCase("5", 0)]

        [Test]
        public void MatriceInputCheckValid(string input, out int menuInput)
            => Assert.IsTrue(menuTest.MenuInputCheck(input, out menuInput));
        #endregion

        #region Menu - Invalid Test Cases
        [TestCase(" ")]
        [TestCase("e w 5")]

        [Test]
        public void MatriceInputCheckInvalid(string input)
            => Assert.IsFalse(menuTest.MatriceInputCheck(input));

        [TestCase("e", 0)]
        [TestCase("", 0)]

        [Test]
        public void MatriceInputCheckInvalid(string input, out int menuInput)
            => Assert.IsFalse(menuTest.MenuInputCheck(input, out menuInput));
        #endregion
    }
}