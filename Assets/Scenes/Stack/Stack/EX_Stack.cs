using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Stack<T>
{
    const int maxSize = 100;
    T[] items = new T[maxSize];
    int top = 0;

    public Stack()
    {
        top = 0;
    }

    public int Count { get; internal set; }

    public void Clear()
    {
        top = -1;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < top; i++)
        {
            if (items[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public T Peek()
    {
        if (top > 0)
        {
            return items[top - 1];
        }
        else
        {
            throw new InvalidOperationException("Stack is empty");
        }
    }

    public T Pop()
    {
        if (top > 0)
        {
            T item = items[top - 1];
            top--;
            return item;
        }
        else
        {
            throw new InvalidOperationException("Stack is empty");
        }
    }

    public void Push(T item)
    {
        if (top < maxSize)
        {
            items[top] = item;
            top++;
        }
        else
        {
            throw new StackOverflowException("Stack is full");
        }
    }
}

public class EX_Stack : MonoBehaviour
{
    void Start()
    {
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < 5; i++)
        {
            stack.Push(i);
        }

        for (int i = 0; i < 5; i++)
        {
            int item = stack.Pop();
            Debug.Log("Popped item: " + item);
        }
    }
}
