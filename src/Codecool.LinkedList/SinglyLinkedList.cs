using System;
using System.Drawing;

namespace Codecool.LinkedList
{
    /// <summary>
    /// Generic singly linked list implementation.
    /// </summary>
    public class SinglyLinkedList<T>
    {
        private Link? _head;

        /// <summary>
        /// Gets the size of the list.
        /// </summary>
        public int Size { get; private set; } = 0;

        /// <summary>
        /// Add a new element to the LinkedList.
        /// The new element is appended to the current last item.
        /// </summary>
        /// <param name="data">Value to be appended.</param>
        public void Add(T data)
        {
            Link added = new Link(data); 
            added.next = _head; 
            _head = added; 
            Size++;
        }

        /// <summary>
        /// Gives back a certain element at a requested index.
        /// </summary>
        /// <param name="index">Index of requested element.</param>
        /// <returns>Value of requested element.</returns>
        public T Get(int index)
        {
            if (index >= Size || index < 0)
            {
                throw new IndexOutOfRangeException("Tried to get an invalid item!");
            }

            var counter = 0;
            var currentNode = _head;

            while (counter < (Size - 1 - index))
            {
                currentNode = currentNode.next;
                counter++;
            }

            return currentNode.data;

        }

        /// <summary>
        /// Inserts 'data' at 'index' into the list shifting elements if necessary.
        /// e.g. the result of inserting 42 at index 3 into [0, 1, 2, 3, 4] is [0, 1, 2, 42, 3, 4]
        /// </summary>
        /// <param name="index">Index of inserted element.</param>
        /// <param name="data">Value to be inserted.</param>
        public void Insert(int index, T data)
        {
            if (index > Size || index < 0)
            {
                throw new IndexOutOfRangeException("Tried to insert an invalid item!");
            }

            if (Size == 0)
            {
                Link added = new Link(data);
                added.next = null;
                _head = added;
                Size++;
            }
            else
            {
                var counter = 0;
                var currentNode = _head;

                while (counter < Size - 1 - index)
                {
                    currentNode = currentNode.next;
                    counter++;
                }

                Link added = new Link(data);
                added.next = currentNode.next;
                currentNode.next = added;
                Size++;
            }
        }

        /// <summary>
        /// Deletes the element at 'index' from the list.
        /// e.g. the result of deleting index 2 from [0, 1, 2, 3, 4] is [0, 1, 3, 4]
        /// </summary>
        /// <param name="index">Index of element to be removed</param>
        public void Remove(int index)
        {
            if (index >= Size || index < 0)
            {
                throw new IndexOutOfRangeException("Tried to remove an invalid item!");
            }

            if (index == 0)
            {
                Size--;
            }
            else
            {
                var currentNode = _head;
                var counter = 0;
                while (counter < Size - 1 - index)
                {
                    currentNode = currentNode.next;
                    ++counter;
                }

                currentNode.next = currentNode.next.next;
                Size--;
            }
        }

        /// <summary>
        /// Gives back the first index of the given value in the list.
        /// </summary>
        /// <param name="value">Value to search.</param>
        /// <returns>First index of elements equals to given value.</returns>
        public int IndexOf(T value)
        {
            if (Size != 0)
            {
                var counter = 0;
                var currentNode = _head;

                while (currentNode.next != null)
                {
                    if (Equals(currentNode.data, value))
                    {
                        return Size - 1 - counter;
                    }
                    currentNode = currentNode.next;
                    counter++;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gives back the string representation of the LinkedList
        /// e.g. A LinkedList which contains the following elements: [2,5,543,21]
        /// results the following string "[2, 5, 543, 21]"
        /// </summary>
        /// <returns>String representation of LinkedList</returns>
        public override string ToString()
        {
            if (Size == 0)
            {
                return "[]";
            }

            string returnString = "[";
            int counter = 0;
            var currentNode = _head;
            while (counter < Size)
            {
                if (counter == Size - 1)
                {
                    returnString += currentNode.data;
                    returnString += "]";
                    counter++;
                }
                else
                {
                    returnString += currentNode.data;
                    returnString += ", ";
                    currentNode = currentNode.next;
                    counter++;
                }
            }

            return returnString;
        }

        private class Link
        {
            /// <summary>
            /// Gets or sets the node data
            /// </summary>
            private T Data;

            public T data
            {
                get { return Data; }
                set { Data = value; }
            }

            /// <summary>
            /// Gets or sets the next node reference
            /// </summary>
            private Link? Next;
            public Link? next
            {
                get { return Next;}
                set { Next = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Link"/> class.
            /// </summary>
            /// <param name="data">Value to store</param>
            public Link(T data)
            {
                Next = null;
                Data = data;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        public SinglyLinkedList()
        {
            _head = null;
        }
    }
}
