// Задача 2: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int Prompt(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,] GenerateArray(int row, int column, int min, int max)
{
    var array = new int[row, column];
    var rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}" + "\t");
        }
        Console.WriteLine();
    }
}

int[] CalcSumPerRow(int[,] arr)
{
    int[] sum = new int[arr.GetLength(0)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int result = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            result += arr[i, j];
        }
        sum[i] = result;
    }
    return sum;
}

int SearchRowWithSmallestSum(int[] arr)
{
    int min = arr[0];
    int index = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (min > arr[i])
        {
            min = arr[i];
            index = i;
        }
    }
    return index;
}

int row = Prompt("Введите количество строк: ");
int column = Prompt("Введите количество столбцов: ");
int min = 0;
int max = 10;
int[,] array  = GenerateArray(row, column, min, max);
PrintArray(array);
System.Console.WriteLine();

int[] sumInRows = CalcSumPerRow(array);
int rowWithSmallestSum = SearchRowWithSmallestSum(sumInRows);
System.Console.WriteLine($"Наименьшая сумма элементов в {rowWithSmallestSum + 1} строке");