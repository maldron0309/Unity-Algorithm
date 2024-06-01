using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Stack<T>
{
    private T[] items;
    private int top;
    private int maxSize;


    /// <summary>
    /// 생성자
    /// </summary>
    public Stack(int size = 100)
    {
        maxSize = size;
        top = -1;
        items = new T[maxSize];
    }

    public int Count { get { return top + 1; } }


    /// <summary>
    ///  개체를 모두 제거
    /// </summary>
    public void Clear()
    {
        top = -1;
    }

    /// <summary>
    /// 요소가 있는지 여부 확인
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        // 스택 맨 위에서부터 순회
        for (int i = top; i >= 0; i--)
        {
            if (items[i].Equals(item))
            {
                return true; // 요소를 찾으면 true 
            }
        }
        return false;
    }

    /// <summary>
    /// 스택의 요소 복사
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        CheckArrayArgument(array, arrayIndex);

        for (int i = 0; i <= top && arrayIndex < array.Length; i++)
        {
            array[arrayIndex++] = items[i];
        }
    }

    private void CheckArrayArgument(T[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));

        if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

        if (array.Length - arrayIndex < this.Count) throw new ArgumentException("The target array is not large enough.");
    }

    public int EnsureCapacity(int capacity)
    {
        if (items.Length < capacity)
        {
            int newCapacity = items.Length * 2;
            if (newCapacity < capacity) newCapacity = capacity;

            T[] item = new T[newCapacity];
            for (int i = 0; i <= top; i++)
            {
                item[i] = items[i];
            }

            items = item;
        }
        return EnsureCapacity(capacity);
    }


    /// <summary>
    ///  맨 위 요소 반환
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        return items[top];
    }

    /// <summary>
    /// 맨 위 요소 삭제 후 반환
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is Empty");
        }
        return items[top--];
    }

    /// <summary>
    /// 요소 추가
    /// </summary>
    /// <param name="item"></param>
    public void Push(T item)
    {
        if (top == maxSize - 1)
        {
            throw new InvalidCastException("Stack is Full");
        }

        items[++top] = item;
    }
}
public class EX_Stack : MonoBehaviour
{
    void Start()
    {
        Stack<int> stack = new Stack<int>();

        // 스택에 요소 추가
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // 스택의 요소 수 출력
        Debug.Log("Count: " + stack.Count);

        // 스택의 맨 위 요소 확인
        Debug.Log("Peek: " + stack.Peek());

        // 스택에서 요소 제거하고 반환
        Debug.Log("Pop: " + stack.Pop());

        // 스택에 요소 추가
        stack.Push(4);

        // 스택의 요소를 배열로 복사하여 출력
        int[] array = new int[stack.Count];
        stack.CopyTo(array, 0);
        Debug.Log("Copied Array: " + string.Join(", ", array));

        // 스택 비우기
        stack.Clear();

        // 스택이 비었는지 확인
        Debug.Log("Is Stack Empty: " + (stack.Count == 0));
    }
}

