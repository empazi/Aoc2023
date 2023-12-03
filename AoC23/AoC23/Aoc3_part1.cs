using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC23
{
    internal class Aoc3_part1
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Aoc_day3.txt"))
            {
                int acceptedGame = 0;
                int redCubesLimit = 12;
                int greenCubesLimit = 13;
                int blueCubesLimit = 14;
                //int powerPerGame = 0;
                int gameIndex = 1;
                int numberOfRows = 10;
                int numberOfCols = 10;
                char[,] schematicArray = new char[numberOfRows, numberOfCols];
                int row = 0;
                int col = 0;
                int partnumberSum = 0;
                while (sr.Peek() != -1)
                {
                    String readRow = sr.ReadLine();
                    for(int i = 0; i < readRow.Length; i++)
                    {
                        schematicArray[row, i] = readRow[i]; 
                    }
                    row++;
                }
                for(int i = 0; i < numberOfRows; i++)
                {
                    for(int j = 0; j < numberOfCols; j++)
                    {
                        if (Char.IsDigit(schematicArray[i, j]))
                        {
                            int wholeNumber = GetNumber(schematicArray, i, j);
                            bool isAdjecent = CheckAdjecent(schematicArray, wholeNumber, i, j);
                            if(isAdjecent) 
                            {
                                partnumberSum += wholeNumber;
                            }
                        }

                    }
                }
                Console.WriteLine(partnumberSum);
            }

        }

        private static bool CheckAdjecent(char[,] schematicArray, int wholeNumber, int row, int col)
        {
            //Can we check left?
            if((col-1) > 0)
            {
                //Left
                if (schematicArray[row, col - 1] != '.')
                    return true;
            }
            //Can we check right?
            if(col + 1 < schematicArray.GetLength(0))
            {
                //Right
                if (schematicArray[row, col + 1] != '.')
                    return true;
            }
            //Can we check top left?
            if(row - 1 > 0 && col - 1 > 0)
            {
                if (schematicArray[row - 1, col - 1] != '.')
                    return true;
            }
            //Top Left
            else if (schematicArray[i-1, j - 1] != '.' && (j - 1) > 0 && (i-1) > 0)
                return true;
            //Top Right
            else if (schematicArray[i - 1, j + 1] != '.' && 
                (j + 1) < schematicArray.GetLength(0) && 
                (i - 1) > 0)
                return true;
            //Bottom Left
            else if (schematicArray[i + 1, j - 1] != '.' &&
                (j - 1) > 0 &&
                (i + 1) < schematicArray.GetLength(1))
                return true;
            //Bottom Right
            else if (schematicArray[i + 1, j + 1] != '.' &&
                (j + 1) < schematicArray.GetLength(0) &&
                (i + 1) < schematicArray.GetLength(1))
                return true;
            //Top and Bottom
            for(int k = 0; k < wholeNumber.ToString().Length; k++)
            {
                if (schematicArray[i - 1, j + k] != '.' && (i - 1) > 0)
                    return true;
                else if(schematicArray[i + 1, j + k] != '.' && (i - 1) < schematicArray.GetLength(1))
                    return true;
            }
            return false;
        }

        private static int GetNumber(char[,] schematicArray, int row, int col)
        {
            int wholeNumber = 0;
            StringBuilder sb = new StringBuilder();
            while (Char.IsDigit(schematicArray[row,col]) && col < schematicArray.GetLength(0))
            {
                sb.Append(schematicArray[row, col]);
                col++;
            }
            sb.ToString().Trim();
            wholeNumber = int.Parse(sb.ToString());
            return wholeNumber;
        }
    }
}
