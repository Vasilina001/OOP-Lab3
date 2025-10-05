using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть кількість рядків n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців m: ");
        int m = int.Parse(Console.ReadLine());

        double[,] arr = new double[n, m];
        Random rnd = new Random();

        // Генерація чисел у сотих (діапазон [-4231; 703] → /100.0)
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int value = rnd.Next(-4231, 704);
                arr[i, j] = value / 100.0;
            }
        }

        // Виведення початкового масиву
        Console.WriteLine("\nПочатковий масив:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(arr[i, j] + "\t");
            Console.WriteLine();
        }

        // 1. Кількість рядків без від’ємних елементів
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < m; j++)
            {
                if (arr[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative) count++;
        }
        Console.WriteLine($"\nКількість рядків без від’ємних елементів: {count}");

        // 2. Перевернути порядок елементів у стовпцях
        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n / 2; i++)
            {
                double temp = arr[i, j];
                arr[i, j] = arr[n - 1 - i, j];
                arr[n - 1 - i, j] = temp;
            }
        }

        // Виведення масиву після перевертання
        Console.WriteLine("\nМасив після перевертання стовпців:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(arr[i, j] + "\t");
            Console.WriteLine();
        }
    }
}
