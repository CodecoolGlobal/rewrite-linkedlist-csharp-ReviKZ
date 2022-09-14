using System;

namespace Codecool.LinkedList
{
    /// <summary>
    /// Generic singly linked list implementation.
    /// </summary>
    public class SinglyLinkedList
    {
        private Link _head;

        /// <summary>
        /// Gets the size of the list.
        /// </summary>
        public int Size { get; private set; } = 0;

        /// <summary>
        /// Add a new element to the LinkedList.
        /// The new element is appended to the current last item.
        /// </summary>
        /// <param name="data">Value to be appended.</param>
        public void Add(int data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back a certain element at a requested index.
        /// </summary>
        /// <param name="index">Index of requested element.</param>
        /// <returns>Value of requested element.</returns>
        public int Get(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts 'data' at 'index' into the list shifting elements if necessary.
        /// e.g. the result of inserting 42 at index 3 into [0, 1, 2, 3, 4] is [0, 1, 2, 42, 3, 4]
        /// </summary>
        /// <param name="index">Index of inserted element.</param>
        /// <param name="data">Value to be inserted.</param>
        public void Insert(int index, int data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the element at 'index' from the list.
        /// e.g. the result of deleting index 2 from [0, 1, 2, 3, 4] is [0, 1, 3, 4]
        /// </summary>
        /// <param name="index">Index of element to be removed</param>
        public void Remove(int index)
        {
            if (index == 0)
            {
                _head = _head.Next;
                Size--;
                return;
            }

            var currentNode = _head;
            var counter = 0;
            while (counter < index - 1)
            {
                currentNode = currentNode.Next;
                ++counter;

                if (currentNode.Next == null)
                {
                    throw new IndexOutOfRangeException("Tried to remove an invalid item!");
                }
            }

            currentNode.Next = currentNode.Next.Next;
            Size--;
        }

        /// <summary>
        /// Gives back the first index of the given value in the list.
        /// </summary>
        /// <param name="value">Value to search.</param>
        /// <returns>First index of elements equals to given value.</returns>
        public int IndexOf(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back the string representation of the LinkedList
        /// e.g. A LinkedList which contains the following elements: [2,5,543,21]
        /// results the following string "[2, 5, 543, 21]"
        /// </summary>
        /// <returns>String representation of LinkedList</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        private class Link
        {
            /// <summary>
            /// Gets or sets the node data
            /// </summary>
            public int Data { get; set; }

            /// <summary>
            /// Gets or sets the next node reference
            /// </summary>
            public Link Next { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Link"/> class.
            /// </summary>
            /// <param name="data">Value to store</param>
            public Link(int data)
            {
                Data = data;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }
    }
}
