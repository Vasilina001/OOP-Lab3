using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть кількість елементів масиву n: ");
        int n = int.Parse(Console.ReadLine());

        double[] arr = new double[n];
        Random rnd = new Random();

        // Генерація масиву в межах [-7.51; 3.59]
        for (int i = 0; i < n; i++)
        {
            int value = rnd.Next(-751, 360); // [min, max)
            arr[i] = value / 100.0;
        }

        Console.WriteLine("\nПочатковий масив:");
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + "\t");
        Console.WriteLine();

        // 1. Сума модулів елементів з дробовою частиною < 0.5
        double sum = arr
            .Where(x => Math.Abs(x - Math.Truncate(x)) < 0.5)
            .Sum(x => Math.Abs(x));

        Console.WriteLine($"\nСума модулів елементів з дробовою частиною < 0.5 = {sum:F2}");

        // 2. Сортування елементів після мінімального за спаданням
        int minIndex = Array.IndexOf(arr, arr.Min());
        if (minIndex < arr.Length - 1)
        {
            var part = arr.Skip(minIndex + 1).OrderByDescending(x => x).ToArray();
            for (int i = minIndex + 1, j = 0; i < arr.Length; i++, j++)
                arr[i] = part[j];
        }

        Console.WriteLine("\nМасив після сортування елементів після мінімального:");
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + "\t");
        Console.WriteLine();
    }
}
