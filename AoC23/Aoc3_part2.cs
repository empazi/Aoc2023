using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC23
{
    internal class Aoc3_part2
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Aoc_day3.txt"))
            {
                int numberOfRows = 140;
                int numberOfCols = 140;
                char[,] schematicArray = new char[numberOfRows, numberOfCols];
                int[] numbersToMultiply = { 0, 0 };
                int row = 0;
                int col = 0;
                int partnumberSum = 0;
                int numLen = 0;
                while (sr.Peek() != -1)
                {
                    String readRow = sr.ReadLine();
                    for (int i = 0; i < readRow.Length; i++)
                    {
                        schematicArray[row, i] = readRow[i];
                    }
                    row++;
                }
                for (int i = 0; i < numberOfRows; i++)
                {
                    for (int j = 0; j < numberOfCols; j++)
                    {
                        if (schematicArray[i, j].Equals("*"))
                        {
                            //Check if adjecent numbers and multiply them together
                            bool isAdjecent = CheckAdjecent(schematicArray, numbersToMultiply, i, j);
                        }
                        if (Char.IsDigit(schematicArray[i, j]))
                        {
                            int wholeNumber = GetNumber(schematicArray, i, j);
                            numLen = wholeNumber.ToString().Length;
                            
                            if (isAdjecent)
                            {
                                partnumberSum += wholeNumber;
                            }
                            j += numLen - 1;
                        }

                    }
                }
                Console.WriteLine(partnumberSum);
            }

        }

        private static int[] CheckAdjecent(char[,] schematicArray, int[] numbersToMultiply, int row, int col)
        {
            int cols = schematicArray.GetLength(0);
            int rows = schematicArray.GetLength(1);
            bool foundFirst = false;
            bool foundSecond = false;
            //Case 5
            if ((col - 1) > 0 && (row - 1) > 0 && (col + 1) < cols && (row + 1 < rows))
            {
                //Check left
                if (Char.IsDigit(schematicArray[row, col - 1]))
                {
                    numbersToMultiply[0] = GetNumberLeft(schematicArray, row, col - 1);
                }
                //Check right
                if (Char.IsDigit(schematicArray[row, col + 1]))
                    numbersToMultiply[0] = GetNumberRight(schematicArray, row, col + 1);
                //Check above and below - 1 -> numberLen +1
                for (int x = 0; x < 1 + 2; x++)
                {
                    if (Char.IsDigit(schematicArray[row - 1, col - 1 + x]))
                        return true;
                    if ((Char.IsDigit(schematicArray[row + 1, col - 1 + x])
                        return true;
                }
            }

            //Case 2
            else if ((col + 1) < cols && (row + 1) < rows && (col - 1) > 0)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check right
                if (schematicArray[row, col + 1] != '.')
                    return true;
                //Check below -1 -> numberLen+1
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }

            }
            //Case 4
            else if ((row - 1) > 0 && (col + 1) < cols && (row + 1) < rows)
            {
                //Check right
                if (schematicArray[row, col + 1] != '.')
                    return true;
                //Check above and below 0 -> numberLen +1
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row - 1, col + x] != '.')
                        return true;
                    if (schematicArray[row + 1, col + x] != '.')
                        return true;
                }
            }
            //Case 8
            else if ((row - 1) > 0 && (col + 1) < cols && (cols - 1) > 0)
            {
                //Check right
                if (schematicArray[row, col + 1] != '.')
                    return true;
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check above 0 -> numberLen
                for (int x = 0; x < 1.ToString().Length + 2; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;

                }
            }
            //Case 6
            else if ((cols - 1) > 0 && (row - 1) > 0 && (row + 1) < rows)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check above and below -1 -> numberLen
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }
            }


            //Case1
            if ((col + 1) < cols && (row + 1) < rows)
            {
                //Check right
                if (schematicArray[row, col + 1] != '.')
                    return true;
                //Check below 0 -> numberLen+1
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row + 1, col + x] != '.')
                        return true;
                }
            }
            //Case 3
            else if ((col - 1) > 0 && (row + 1) < rows)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check below -1 -> numberLen
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }
            }
            //Case 7
            else if ((row - 1) > 0 && (col + 1) < cols)
            {
                //Check right
                if (schematicArray[row, col + 1] != '.')
                    return true;
                //Check above 0 -> numberLen
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row - 1, col + x] != '.')
                        return true;

                }
            }
            //Case 9
            else if ((col - 1) > 0 && (row - 1) > 0)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check above -1 -> numberLen
                for (int x = 0; x < 1 + 1; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;

                }
            }
            return false;
        }

        private static int GetNumber(char[,] schematicArray, int row, int col)
        {
            int wholeNumber1 = 0;
            int wholeNumber2 = 0;
            int max = 0;
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            //Go Right
            while (Char.IsDigit(schematicArray[row, col]) && col < schematicArray.GetLength(0))
            {

                sb1.Append(schematicArray[row, col]);
                col++;
                if (col >= schematicArray.GetLength(0))
                    break;
            }
            //Go Left
            while (Char.IsDigit(schematicArray[row, col]) && col > 0)
            {
                sb2.Append(schematicArray[row, col]);
                col--;
                if (col <= 0)
                    break;
            }
            sb1.ToString().Trim();
            wholeNumber1 = int.Parse(sb1.ToString());
            wholeNumber2 = int.Parse(sb2.ToString());
            if (wholeNumber1 == wholeNumber2)
                return wholeNumber1;
            else if (wholeNumber2 > wholeNumber1)
                return wholeNumber2;
            else
                return wholeNumber1;
        }
        private static int GetNumberLeft(char[,] schematicArray, int row, int col)
        {
            StringBuilder sb1 = new StringBuilder();
            //Go Left
            while (Char.IsDigit(schematicArray[row, col]) && col > 0)
            {
                sb1.Append(schematicArray[row, col]);
                col--;
                if (col <= 0)
                    break;
            }
            sb1.ToString().Trim();
                return int.Parse(sb1.ToString());
        }
        private static int GetNumberRight(char[,] schematicArray, int row, int col)
        {
            StringBuilder sb1 = new StringBuilder();
            //Go Right
            while (Char.IsDigit(schematicArray[row, col]) && col < schematicArray.GetLength(0))
            {
                
                sb1.Append(schematicArray[row, col]);
                col++;
                if (col >= schematicArray.GetLength(0))
                    break;
            }
            sb1.ToString().Trim();
            return int.Parse(sb1.ToString());
        }
    }
}
