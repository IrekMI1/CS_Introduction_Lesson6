// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

int GetPositiveCount()
{
    int[] numbers = Console.ReadLine().Split(", ").Select(x => Convert.ToInt32(x)).ToArray();
    int count = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > 0) count++;
    }
    return count;
}

try
{
    Console.Write("Введите числа через ', ': \t");
    Console.WriteLine($"Количество положительных чисел:\t{GetPositiveCount()}");
}
catch
{
    Console.WriteLine("Неверный ввод!");
}

