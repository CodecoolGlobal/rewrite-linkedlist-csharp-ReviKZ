using NUnit.Framework;
using System;

namespace Codecool.LinkedList.UnitTests
{
    [TestFixture]
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new SinglyLinkedList<int>();
        }

        [Test]
        public void Add_SingleElement_IncreaseSizeByOne()
        {
            //Act
            _list.Add(123);
            var expected = 1;

            //Assert
            Assert.AreEqual(expected, _list.Size);
        }

        [Test]
        public void Add_MultipleElements_SizeIncreasedAccordingly()
        {
            //Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);
            const int expectedSize = 3;

            //Act
            int result = _list.Size;

            //Assert
            Assert.AreEqual(expectedSize, result);
        }

        [Test]
        public void Size_EmptyList_ReturnsZero()
        {
            //Arrange
            const int expectedSize = 0;

            //Act
            int result = _list.Size;

            //Assert
            Assert.AreEqual(expectedSize, result);
        }

        [Test]
        public void Get_SingleElementInList_CanBeAccessedByIndexZero()
        {
            //Arrange
            _list.Add(123);

            //Act
            var result = _list.Get(0);

            //Assert
            Assert.AreEqual(123, result);
        }

        [Test]
        public void Get_MultipleElementsInList_CanBeAccessedByIndex()
        {
            //Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);

            //Act
            var one = _list.Get(0);
            var two = _list.Get(1);
            var three = _list.Get(2);

            //Assert
            Assert.AreEqual(123, one);
            Assert.AreEqual(234, two);
            Assert.AreEqual(345, three);
        }

        [Test]
        public void Get_IndexBiggerThanSize_ThrowsIndexOutOfRangeException()
        {
            //Arrange
            _list.Add(123);
            const int indexOutOfRange = 10;

            // Act
            var exception = Assert.Throws<IndexOutOfRangeException>(() => _list.Get(indexOutOfRange));

            // Assert
            Assert.NotNull(exception);
        }

        [Test]
        public void Get_IndexEqualsToSize_ThrowsIndexOutOfRangeException()
        {
            //Arrange
            _list.Add(123);
            int indexOutOfRange = _list.Size;

            // Act Assert
            var exception = Assert.Throws<IndexOutOfRangeException>(() => _list.Get(indexOutOfRange));
        }

        [Test]
        public void Insert_ElementAtZero_SetAsHeadAndCanBeAccessedByIndexZero()
        {
            //Arrange

            // Act
            _list.Insert(0, 123);
            var elementZero = _list.Get(0);

            // Assert
            Assert.AreEqual(123, elementZero);
        }

        [Test]
        public void Insert_ElementAtZeroIntoNonEmptyList_SetAsHeadAndOtherElementsShiftedAccordingly()
        {
            //Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);

            // Act
            _list.Insert(0, 999);
            var elementZero = _list.Get(0);
            var prevHead = _list.Get(1);

            // Assert
            Assert.AreEqual(999, elementZero);
            Assert.AreEqual(123, prevHead);
        }

        [Test]
        public void Insert_ElementInTheMiddle_ElementsShiftedAccordingly()
        {
            //Arrange
            _list.Add(999);
            _list.Add(123);
            _list.Add(234);

            // Act
            _list.Insert(1, -5);
            var insertedElement = _list.Get(1);
            var prevElementAtIndex = _list.Get(2);

            // Assert
            Assert.AreEqual(-5, insertedElement);
            Assert.AreEqual(123, prevElementAtIndex);
        }

        [Test]
        public void Insert_MultipleElementsAtFirst_CanBeAccessedInreversedOrder()
        {
            //Arrange

            // Act
            _list.Insert(0, 777);
            _list.Insert(0, 888);
            _list.Insert(0, 999);

            // Assert
            Assert.AreEqual(999, _list.Get(0));
            Assert.AreEqual(888, _list.Get(1));
            Assert.AreEqual(777, _list.Get(2));
        }

        [Test]
        public void Insert_MultipleElementsDifferentIndices_CanBeAccessedByIndex()
        {
            //Arrange

            // Act
            _list.Insert(0, 999);
            _list.Insert(0, 555);
            _list.Insert(1, 888);
            _list.Insert(1, 777);
            _list.Insert(1, 666);

            // Assert
            Assert.AreEqual(555, _list.Get(0));
            Assert.AreEqual(666, _list.Get(1));
            Assert.AreEqual(777, _list.Get(2));
            Assert.AreEqual(888, _list.Get(3));
            Assert.AreEqual(999, _list.Get(4));
        }

        [Test]
        public void Insert_NegativeIndex_ThrowsIndexOutOfRangeException()
        {
            //Arrange

            // Act Assert
            Assert.Throws<IndexOutOfRangeException>(() => _list.Insert(-1, 1));
        }

        [Test]
        public void Insert_IndexBiggerThanSize_ThrowsIndexOutOfRangeException()
        {
            //Arrange
            _list.Add(123);

            int indexOutOfRange = _list.Size + 1;

            // Act Assert
            Assert.Throws<IndexOutOfRangeException>(() => _list.Insert(indexOutOfRange, 1));
        }

        [Test]
        public void Remove_LastElement_DecreaseSize()
        {
            // Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);
            int lastIndex = _list.Size - 1;
            int expectedSize = _list.Size - 1;

            // Act
            _list.Remove(lastIndex);

            // Assert
            Assert.AreEqual(expectedSize, _list.Size);
        }

        [Test]
        public void Remove_Head_PreviouslySecondElementBecomesHead()
        {
            // Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);

            // Act
            _list.Remove(0);
            var newHead = _list.Get(0);

            // Assert
            Assert.AreEqual(234, newHead);
        }

        [Test]
        public void Remove_Head_DecreaseSize()
        {
            // Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);

            // Act
            _list.Remove(0);
            int actual = _list.Size;
            int expected = 2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_ElementInTheMiddle_RemainedElementsShiftedAccordingly()
        {
            // Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);
            _list.Add(456);

            // Act
            _list.Remove(1);

            // Assert
            var element1 = _list.Get(1);
            var element2 = _list.Get(2);
            Assert.AreEqual(345, element1);
            Assert.AreEqual(456, element2);
        }

        [Test]
        public void Remove_IndexBiggerThanSize_ThrowsIndexOutOfRangeException()
        {
            // Arrange
            _list.Add(123);
            _list.Add(234);
            int indexOutOfRange = _list.Size + 1;

            // Act Assert
            Assert.Throws<IndexOutOfRangeException>(() => _list.Remove(indexOutOfRange));
        }

        [Test]
        public void IndexOf_ExistingElement_ReturnsWithItsIndex()
        {
            // Arrange
            var existingElement = 963;
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);
            var expected = 2;
            _list.Insert(expected, existingElement);

            // Act
            int index = _list.IndexOf(existingElement);

            // Assert
            Assert.AreEqual(expected, index);
        }

        [Test]
        public void IndexOf_NonExistingElement_ReturnsWithMinusOne()
        {
            // Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);
            var expected = -1;

            // Act
            int index = _list.IndexOf(404);

            // Assert
            Assert.AreEqual(expected, index);
        }

        [Test]
        public void IndexOf_EmptyList_ReturnsWithMinusOne()
        {
            // Arrange
            var expected = -1;

            // Act
            int index = _list.IndexOf(404);

            // Assert
            Assert.AreEqual(expected, index);
        }

        [Test]
        public void ToString_MultipleElements_ElementsInBrackets()
        {
            //Arrange
            _list.Add(123);
            _list.Add(234);
            _list.Add(345);
            var expected = "[123, 234, 345]";

            //Act
            string actual = _list.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyList_OnlyBrackets()
        {
            //Arrange
            var expected = "[]";

            //Assert
            string actual = _list.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}