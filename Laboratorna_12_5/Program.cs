using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    // Функція створення стеку з першими літерами слів текстового файлу
    public static void CreateStack(string filename, Stack<char> stack)
    {
        string[] words = File.ReadAllText(filename).Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            stack.Push(word[0]);
        }
    }

    // Функція упорядкування елементів стеку
    public static Stack<char> OrderStack(Stack<char> stack)
    {
        Stack<char> sortedStack = new Stack<char>();

        while (stack.Count > 0)
        {
            char current = stack.Pop();

            // Поки відсортований стек не порожній і верхній елемент менший за поточний, переносимо його назад у вихідний стек
            while (sortedStack.Count > 0 && sortedStack.Peek() < current)
            {
                stack.Push(sortedStack.Pop());
            }

            sortedStack.Push(current);
        }

        return sortedStack;
    }

    // Функція для виведення стеку на екран
    public static void PrintStack(Stack<char> stack)
    {
        Stack<char> tempStack = new Stack<char>(stack);

        while (tempStack.Count > 0)
        {
            Console.Write(tempStack.Pop() + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Stack<char> stack = new Stack<char>();
        CreateStack("text.txt", stack);

        Console.WriteLine("Зміст файлу:");
        // Виведення змісту файлу
        Console.WriteLine(File.ReadAllText("text.txt"));
        Console.WriteLine();

        Console.WriteLine("Стек:");
        // Виведення стеку
        PrintStack(stack);
        Console.WriteLine();

        // Упорядковання стеку
        Stack<char> sortedStack = OrderStack(stack);

        Console.WriteLine("Упорядкований стек:");
        // Виведення упорядкованого стеку
        PrintStack(sortedStack);
    }
}