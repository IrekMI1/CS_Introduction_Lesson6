// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, 
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
// решение:
// k1 * x + b1 = k2 * x + b2
// k1 * x - k2 * x = b2 - b1
// x * (k1 - k2) = b2 - b1
// x = (b2 - b1) / (k1 - k2)
// y = k1 * x + b1

float[] GetIntersectionPointArray(float[,] coeff)
{
    float[] point = new float[2];
    point[0] = (coeff[1, 0] - coeff[0, 0]) / (coeff[0, 1] - coeff[1, 1]);
    point[1] = coeff[0, 1] * point[0] + coeff[0, 0];
    return point;
}

try
{
    float[,] coefficients = new float[2,2];
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            if (j == 0) Console.Write($"Введите коэффициент b{i + 1}:\t");
            else Console.Write($"Введите коэффициент k{i + 1}:\t");
            coefficients[i,j] = Convert.ToSingle(Console.ReadLine());
        }
    }
    float[] result = GetIntersectionPointArray(coefficients);
    Console.Write($"Точка пересечения прямых: x = {result[0]}, y = {result[1]}");
}
    
catch 
{
    Console.WriteLine("Неверный ввод!");
}