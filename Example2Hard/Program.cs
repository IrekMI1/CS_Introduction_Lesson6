// задача 2 HARD необязательная. Сгенерировать массив случайных целых чисел размерностью m*n 
// (размерность вводим с клавиатуры). Вывести на экран красивенько таблицей. Перемешать случайным образом 
// элементы массива, причем чтобы каждый гарантированно один раз переместился на другое место 
// и потом не участвовал никак (возможно для этого удобно будет использование множества) и выполнить 
// это за m*n / 2 итераций. То есть если массив три на четыре, то надо выполнить не более 6 итераций. 
// И далее в конце опять вывести на экран как таблицу.

int[,] FillSortedMatrixInt(int row, int col)
{
    int[,] matrix = new int[row, col];
    int num = 0;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            num++;
            matrix[i, j] = num;
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}

bool IsIndexInList(int[] indexArray, List<int[]> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        if (indexArray[0] == list[i][0]
            && indexArray[1] == list[i][1])
        {
            return true;
        }
    }
    return false;
}

int[,] GetRandomlyMixedMatrix(int[,] matrix)
{
    int row = matrix.GetLength(0);
    int col = matrix.GetLength(1);
    List<int[]> indexSet = new List<int[]>(row);

    Random random = new Random();
    int[] randomIndex;
    int[] randomRow = new int[2];
    int[] randomCol = new int[2];
    int temp;

    for (int i = 0; i < row * col / 2; i++)
    {
        for (int n = 0; n < 2; n++)
        {
            do
            {
                randomRow[n] = random.Next(row);
                randomCol[n] = random.Next(col);
                randomIndex = new int[2] { randomRow[n], randomCol[n] };
            } while (IsIndexInList(randomIndex, indexSet));
            indexSet.Add(randomIndex);
        }

        temp = matrix[randomRow[0], randomCol[0]];
        matrix[randomRow[0], randomCol[0]] = matrix[randomRow[1], randomCol[1]];
        matrix[randomRow[1], randomCol[1]] = temp;
    }
    return matrix;
}

try
{
    Console.Write("Введите число строк: \t");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите число столбцов:\t");
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = FillSortedMatrixInt(m, n);

    Console.WriteLine("Исходный массив:");
    PrintMatrix(matrix);
    Console.WriteLine("Перемешанный массив:");
    PrintMatrix(GetRandomlyMixedMatrix(matrix));
}
catch
{
    Console.WriteLine("Ошибка ввода!");
}