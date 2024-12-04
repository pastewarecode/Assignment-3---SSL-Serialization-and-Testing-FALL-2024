using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class SLL : ILinkedListADT
    {
        //declaring variables for the list
        private Node head;
        private Node tail;
        private int size;

        //create the constuctor
        public SLL()
        {
            head = null;
            tail = null;
            size = 0;
        }

        //checks if the list is empty
        public bool IsEmpty()
        {
            return size == 0;
        }


        //o Prepend an item to the beginning of the linked list.
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);

            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            size++;
        }


        //o Append an item to the end of the linked list.
        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            size++;
        }


        //o Remove an item at an index in the linked list.
        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Index is out of range.");

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == size - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
                size--;
            }
        }


        //o Remove an item from the start of the linked list.
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from an empty list.");

            head = head.Next;
            size--;

            if (size == 0)
                tail = null;
        }


        //o Remove an item from the end of the linked list.
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from an empty list.");

            if (size == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node current = head;

                while (current.Next != tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                tail = current;
            }
            size--;
        }


        //o Insert an item at a specific index in the linked list.
        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
                throw new IndexOutOfRangeException("Index is out of range.");

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == size)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
                size++;
            }
        }


        //o Replace an item in the linked list.
        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Index is out of range.");

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }

        //o Get an item at an index in the linked list.
        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Index is out of range.");

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }


        //o Get the index of an item in the linked list.
        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }


        //o Check if the linked list has an item.
        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }


        //o Clear all items in the linked list.
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }


        //o Get the number of items in the linked list.
        public int Count()
        {
            return size;
        }

        public void Reverse()
        {
            //vairables to be used
            Node prev = null;
            Node current = head;
            Node next = null;

            //while current is NOT null we move each node backwards and cycle it
            while (current != null)
            {
                next = current.Next;  
                current.Next = prev;
                prev = current;       
                current = next;
            }

            //note the tail as the new head
            tail = head;
            head = prev;
        }

    }
}
