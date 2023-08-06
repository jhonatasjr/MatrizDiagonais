// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

public class MatrixOperations
{
    // Questão 1: Função para inverter as diagonais de uma matriz quadrada
    public static void InvertDiagonals(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, size - 1 - i];
            matrix[i, size - 1 - i] = temp;
        }
    }

    // Questão 2: Função para contar quantas vezes uma submatriz B pode ser encontrada em uma matriz A
    public static int CountSubmatrixOccurrences(int[,] matrixA, int[,] submatrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = submatrixB.GetLength(0);
        int colsB = submatrixB.GetLength(1);
        int count = 0;

        for (int i = 0; i <= rowsA - rowsB; i++)
        {
            for (int j = 0; j <= colsA - colsB; j++)
            {
                bool isSubmatrix = true;

                for (int k = 0; k < rowsB; k++)
                {
                    for (int l = 0; l < colsB; l++)
                    {
                        if (matrixA[i + k, j + l] != submatrixB[k, l])
                        {
                            isSubmatrix = false;
                            break;
                        }
                    }

                    if (!isSubmatrix)
                        break;
                }

                if (isSubmatrix)
                    count++;
            }
        }

        return count;
    }

    public static void Main()
    {
        // Exemplo de uso da função InvertDiagonals:
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        Console.WriteLine("Inversão das diagonais.");

        Console.WriteLine("\nMatriz original:");
        PrintMatrix(matrix);

        InvertDiagonals(matrix);

        Console.WriteLine("\nMatriz com diagonais invertidas:");
        PrintMatrix(matrix);

        // Exemplo de uso da função CountSubmatrixOccurrences:
        int[,] matrixA = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 6, 7, 8},
            {1, 2, 3, 4}
        };

        int[,] submatrixB = {
            {6, 7},
            {2, 3}
        };

        Console.WriteLine("\n----------------------------------");
        Console.WriteLine("\nRetorno de quantas vezes a submatriz B pode ser encontrada na matriz A.");

        Console.WriteLine("\nMatriz A:");
        PrintMatrix(matrixA);

        Console.WriteLine("\nMatriz B:");
        PrintMatrix(submatrixB);

        int occurrences = CountSubmatrixOccurrences(matrixA, submatrixB);

        Console.WriteLine("\nNúmero de ocorrências da submatriz B na matriz A: " + occurrences);
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}