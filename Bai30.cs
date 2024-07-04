// EditNumber.cs
using System;
using System.IO;

public class EditNumbers
{
    public static int InputPositiveInteger()
    {
        int n = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter a positive integer:");
                n = int.Parse(Console.ReadLine());
                if (n > 0)
                    break;
                else
                    Console.WriteLine("Please enter a positive integer!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return n;
    }

    public static float Input4ByteFloat()
    {
        float x = 0.0f;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter a 4-byte floating point number:");
                x = float.Parse(Console.ReadLine());
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return x;
    }
}

public class ArrayFloat2D
{
    private float[,] array;

    public void Input2DFloatArray(int rows, int columns)
    {
        array = new float[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Enter element [{i},{j}]: ");
                array[i, j] = float.Parse(Console.ReadLine());
            }
        }
    }

    public void Display2DFloatArray()
    {
        if (array == null)
        {
            Console.WriteLine("The array has not been initialized.");
            return;
        }

        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        Console.WriteLine("Displaying 2D array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Save2DFloatArrayToCSV(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                int rows = array.GetLength(0);
                int columns = array.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        writer.Write(array[i, j]);
                        if (j < columns - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine($"Array saved to file {fileName} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public float[,] Read2DFloatArrayFromCSV(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            int rows = lines.Length;
            int columns = lines[0].Split(',').Length;

            float[,] arrayFromFile = new float[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < columns; j++)
                {
                    arrayFromFile[i, j] = float.Parse(values[j]);
                }
            }

            Console.WriteLine($"Array read from file {fileName} successfully.");
            return arrayFromFile;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from file: {ex.Message}");
            return null;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int rows = EditNumbers.InputPositiveInteger();
        int columns = EditNumbers.InputPositiveInteger();
        float x = EditNumbers.Input4ByteFloat();

        Console.WriteLine($"Value of rows: {rows}");
        Console.WriteLine($"Value of columns: {columns}");
        Console.WriteLine($"Value of x: {x}");

        ArrayFloat2D array = new ArrayFloat2D();
        array.Input2DFloatArray(rows, columns);

        array.Display2DFloatArray();

        array.Save2DFloatArrayToCSV("array2d.csv");

        float[,] arrayFromFile = array.Read2DFloatArrayFromCSV("array2d.csv");
        if (arrayFromFile != null)
        {
            Console.WriteLine("Array from file:");
            int rowsFromFile = arrayFromFile.GetLength(0);
            int columnsFromFile = arrayFromFile.GetLength(1);
            for (int i = 0; i < rowsFromFile; i++)
            {
                for (int j = 0; j < columnsFromFile; j++)
                {
                    Console.Write(arrayFromFile[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
