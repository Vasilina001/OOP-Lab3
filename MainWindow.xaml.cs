using System;
using System.Linq;
using System.Windows;

namespace WpfArrayApp
{
    public partial class MainWindow : Window
    {
        double[] arr;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Генерація масиву
        private void GenerateArray_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(InputN.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введіть коректне число n!");
                return;
            }

            arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                int value = rnd.Next(-751, 360); // [-7.51; 3.59]
                arr[i] = value / 100.0;
            }

            ShowArray();
            ResultText.Text = "Масив згенеровано.";
        }

        // Обчислення суми модулів (дробова частина < 0.5)
        private void CalcSum_Click(object sender, RoutedEventArgs e)
        {
            if (arr == null)
            {
                MessageBox.Show("Спочатку згенеруйте масив!");
                return;
            }

            double sum = arr
                .Where(x => Math.Abs(x - Math.Truncate(x)) < 0.5)
                .Sum(x => Math.Abs(x));

            ResultText.Text = $"Сума модулів елементів (дробова частина < 0.5) = {sum:F2}";
        }

        // Сортування після мінімального
        private void SortAfterMin_Click(object sender, RoutedEventArgs e)
        {
            if (arr == null)
            {
                MessageBox.Show("Спочатку згенеруйте масив!");
                return;
            }

            int minIndex = Array.IndexOf(arr, arr.Min());
            if (minIndex < arr.Length - 1)
            {
                var part = arr.Skip(minIndex + 1).OrderByDescending(x => x).ToArray();
                for (int i = minIndex + 1, j = 0; i < arr.Length; i++, j++)
                    arr[i] = part[j];
            }

            ShowArray();
            ResultText.Text = "Масив впорядковано після мінімального.";
        }

        // Допоміжний метод для показу масиву
        private void ShowArray()
        {
            ArrayList.Items.Clear();
            foreach (var x in arr)
                ArrayList.Items.Add(x);
        }
    }
}
