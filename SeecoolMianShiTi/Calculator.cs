using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    static class Calculator
    {
        public static int Calculate(string exp)
        {
            Stack<char> optr = new Stack<char>();
            Stack<int> opnd = new Stack<int>();
            optr.Push('#');
            exp += '#';
            char ch;
            int i = 0;
            ch = exp[i++];
            while (ch != '#' | optr.Peek() != '#')
            {
                if (isOptr(ch))
                {
                    switch (compare(ch, optr.Peek()))
                    {
                        case ">":
                            //入栈
                            optr.Push(ch);
                            ch = exp[i++];
                            break;
                        case "=":
                            optr.Pop();
                            ch = exp[i++];
                            //括号
                            break;
                        case "<":
                            //出栈，计算
                            char oper = optr.Pop();
                            int a = opnd.Pop();
                            int b = opnd.Pop();
                            int result = calculate(b, oper, a);
                            opnd.Push(result);
                            break;
                    }
                }
                else
                {
                    int a = 0;
                    while (!isOptr(ch))
                    {
                        a = a * 10 + ch - 48;
                        ch = exp[i++];
                    }
                    opnd.Push(a);
                }
            }
            return opnd.Peek();
        }

        private static int calculate(int num1, char oper, int num2)
        {
            switch (oper)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    throw new Exception($"erro,{oper} is not operator!");
            }
        }

        private static string compare(char oper1, char oper2)
        {
            int row = getIndex(oper1);
            int col = getIndex(oper2);
            return _operatorCompare[row, col];
        }

        private static int getIndex(char oper)
        {
            switch (oper)
            {
                case '+':
                    return 0;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 3;
                case '(':
                    return 4;
                case ')':
                    return 5;
                case '#':
                    return 6;
                default:
                    throw new Exception($"erro,{oper} is not operator!");
            }
        }

        private static string[,] _operatorCompare = new string[,]
        {
           //+    -   *   /   (   )   #
            {">",">","<","<",">","<",">" },//+
            {">",">","<","<",">","<",">" },//-
            {">",">",">",">",">","<",">" },//*
            {">",">",">",">",">","<",">" },///
            {">",">",">",">",">","=",">" },//(
            {"<","<","<","<","=","<",">" },//)
            {"<","<","<","<","<","<","=" },//#
        };

        private static bool isOptr(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '(' || ch == ')' || ch == '#';
        }
    }
}
