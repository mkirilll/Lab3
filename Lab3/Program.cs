using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Input a set: ");
            string str = Console.ReadLine();
            int[] set1 = str.Split(" ").Select(Int32.Parse).ToArray();*/
            Console.Write("Input quantity of elements: ");
            int elementsQuantity = int.Parse(Console.ReadLine());

            Console.Write("\nInput quantity of combinations: ");
            int combinationsQuantity = int.Parse(Console.ReadLine());

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] set = GetRandomArray(elementsQuantity);
            stopwatch.Stop();
            Console.WriteLine($"\nSet: {string.Join(", ", set)}");
            Console.WriteLine($"\nTime efficiency: {stopwatch.ElapsedMilliseconds} ms\n");

            Console.WriteLine("Ordinary combinations:\n");
            stopwatch.Restart();
            ShowAllCombinations(set);
            stopwatch.Stop();
            Console.WriteLine($"\nTime efficiency: {stopwatch.ElapsedMilliseconds} ms\n");

            Console.WriteLine($"K - combinations: \n");
            stopwatch.Restart();
            PrintCombination(set, combinationsQuantity);
            stopwatch.Stop();
            Console.WriteLine($"\nTime efficiency: {stopwatch.ElapsedMilliseconds} ms");
        }

        static int[] GetRandomArray(int elementsQuantity)
        {
            int[] result = new int[elementsQuantity];
            Random random = new Random();
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.Next(0, 100);
            }

            return BubbleSort(result);
        }

        static int[] BubbleSort(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }              
            }

            return arr;
        }       

        static void ShowAllCombinations<T>(IList<T> arr, string current = "")
        {
            if (arr.Count == 0) //если все элементы использованы, выводим на консоль получившуюся строку и возвращаемся
            {
                Console.WriteLine(current);
                return;
            }
            //в цикле для каждого элемента прибавляем его к итоговой строке, создаем новый список из оставшихся элементов, 
            //и вызываем эту же функцию рекурсивно с новыми параметрами. Каждый раз переставляем элемент
            for (int i = 0; i < arr.Count; i++) 
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);              
                ShowAllCombinations(lst,  current +  arr[i].ToString() + "   ");
            }
        }

        static void CombinationUtil(int[] arr, int[] data, int start, int end, int index, int r)
        {
            //Выводим получившийся массив в строку
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                {
                    Console.Write(data[j] + "   ");
                }      
                
                Console.WriteLine();
                return;
            }
            //перебираем с помощья рекурсии элементы, каждый раз заменяя следующий с конца
            for (int i = start; i <= end; i++)
            {
                data[index] = arr[i];
                CombinationUtil(arr, data, i + 1, end, index + 1, r);
            }
        }

        static void PrintCombination(int[] arr, int r)
        {
            int[] data = new int[r]; 
            CombinationUtil(arr, data, 0, arr.Length - 1, 0, r);
        }
    }
}
