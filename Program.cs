using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\alina\\OneDrive\\Рабочий стол\\2 курс\\4 семестр\\Инструментал\\17.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);

        // Находим минимальное трехзначное число, делящееся на 7
        int minThreeDigitDivBy7 = numbers.Where(n => n >= 100 && n <= 999 && n % 7 == 0).Min();

        // Находим минимальное четырехзначное число в последовательности
        int minFourDigit = numbers.Where(n => n >= 1000 && n <= 9999).Min();
        int lastDigit = Math.Abs(minFourDigit % 10); // Последняя цифра минимального четырехзначного числа

        int count = 0;
        int maxSum = int.MinValue;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int a = numbers[i];
            int b = numbers[i + 1];

            // Проверяем, что хотя бы одно число меньше minThreeDigitDivBy7
            if (a < minThreeDigitDivBy7 || b < minThreeDigitDivBy7)
            {
                int product = a * b;
                int productLastDigit = Math.Abs(product % 10);

                // Проверяем, что последняя цифра произведения совпадает с lastDigit
                if (productLastDigit == lastDigit)
                {
                    count++;
                    int currentSum = a + b;
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
        }

        Console.WriteLine($"Кол-во пар:{count},  Максимальныя сумма элементов: {maxSum}");
    }
}
