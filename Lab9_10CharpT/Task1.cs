using System;
using System.Collections.Generic;

public class ReverseCheck
{
    public bool IsReverse(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            throw new ReverseCheckException($"'{s2}' та '{s1}' не протилежні");


        Stack<char> stack = new Stack<char>();

        foreach (char c in s1)
        {
            stack.Push(c);
        }

        foreach (char c in s2)
        {
            if (stack.Count == 0 || c != stack.Pop())
            {
                return false;
            }
        }

        return true;
    }

    public void Run()
    {
        try
        {
            string s1 = "Hello";
            string s2 = "olleH";

            bool result = IsReverse(s1, s2);

            Console.WriteLine($"'{s2}' протилежниий до '{s1}'? {result}");

            string s1_1 = "Hello";
            string s2_1 = "ogHsl";

            bool result1 = IsReverse(s1_1, s2_1);

            Console.WriteLine($"'{s2_1}' протилежниий до '{s1_1}'? {result1}");
        }
        catch (ReverseCheckException ex)
        {
            Console.WriteLine($"ReverseCheckException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}