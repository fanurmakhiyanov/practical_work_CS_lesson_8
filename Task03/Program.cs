// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int[,] GenerateMatrix(string message)
{
    System.Console.WriteLine($"Введите количество строк в матрице {message}: ");
    int row = int.Parse(Console.ReadLine());
    System.Console.WriteLine($"Введите количество столбцов в матрице {message}: ");
    int column = int.Parse(Console.ReadLine());
    int min  = 0;
    int max = 10;
    int[,] array = GenerateArray(row, column, min, max);
    return array;
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

int[,] MultiplicationOfTwoMatrices(int[,] arrA, int[,] arrB)
{
    int[,] arrC = new int[arrA.GetLength(0), arrB.GetLength(1)];
    for (int i = 0; i < arrC.GetLength(0); i++)
    {
        for (int j = 0; j < arrC.GetLength(1); j++)
        {
            arrC[i, j] = CalcElementInProductMatrix(arrA, arrB, i, j);
        }
    }
    return arrC;
}

int CalcElementInProductMatrix(int[,] arrA, int[,] arrB, int rowInMtrxA, int columnInMtrxB)
{
    int result = 0;
    for (int i = 0; i < arrA.GetLength(1); i++)
    {
        result += arrA[rowInMtrxA, i] * arrB[i, columnInMtrxB];
    }
    return result;
}

int[,] matrixA = GenerateMatrix("A");
int[,] matrixB = GenerateMatrix("B");
System.Console.WriteLine("Матрица 1: ");
PrintArray(matrixA);
System.Console.WriteLine();
System.Console.WriteLine("Матрица 2: ");
PrintArray(matrixB);
System.Console.WriteLine();

if (matrixA.GetLength(1) != matrixB.GetLength(0))
{
    System.Console.WriteLine("Количество столбцов первой матрицы должно быть равно количеству строк во второй матрице");
    Environment.Exit(0);
}

int[,] matrixC  = MultiplicationOfTwoMatrices(matrixA, matrixB);
System.Console.WriteLine("Произведение матриц: ");
PrintArray(matrixC);