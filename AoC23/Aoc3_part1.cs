﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC23
{
    internal class Aoc3_part1
    {
        /*
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Aoc_day3.txt"))
            {
                int numberOfRows = 140;
                int numberOfCols = 140;
                char[,] schematicArray = new char[numberOfRows, numberOfCols];
                int row = 0;
                int col = 0;
                int partnumberSum = 0;
                int numLen = 0;
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
                        if(schematicArray[i, j].Equals("*"))
                        {
                            //Check if adjecent numbers and multiply them together
                        }
                        if (Char.IsDigit(schematicArray[i, j]))
                        {
                            int wholeNumber = GetNumber(schematicArray, i, j);
                            numLen = wholeNumber.ToString().Length;
                            bool isAdjecent = CheckAdjecent(schematicArray, wholeNumber, i, j);
                            if(isAdjecent) 
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
        */
        private static bool CheckAdjecent(char[,] schematicArray, int wholeNumber, int row, int col)
        {
            int cols = schematicArray.GetLength(0);
            int rows = schematicArray.GetLength(1);
            int numberLen = wholeNumber.ToString().Length;
            //Case 5
            if((col - 1) > 0 && (row - 1) > 0 && (col + numberLen) < cols && (row + 1 < rows))
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check right
                if (schematicArray[row, col + numberLen] != '.')
                    return true;
                //Check above and below -1 -> numberLen +1
                for (int x = 0; x  < numberLen + 2; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }
            }

            //Case 2
            else if((col + numberLen) < cols && (row + 1) < rows && (col - 1) > 0)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check right
                if (schematicArray[row, col + numberLen] != '.')
                    return true;
                //Check below -1 -> numberLen+1
                for (int x = 0; x < numberLen + 1; x++)
                {
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }

            }
            //Case 4
            else if( (row - 1) > 0 && (col + numberLen) < cols && (row + 1) < rows)
            {
                //Check right
                if (schematicArray[row, col + numberLen] != '.')
                    return true;
                //Check above and below 0 -> numberLen +1
                for (int x = 0; x < numberLen + 1; x++)
                {
                    if (schematicArray[row - 1, col + x] != '.')
                        return true;
                    if (schematicArray[row + 1, col + x] != '.')
                        return true;
                }
            }
            //Case 8
            else if ((row - 1) > 0 && (col + numberLen) < cols && (cols - 1) > 0)
            {
                //Check right
                if (schematicArray[row, col + numberLen] != '.')
                    return true;
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check above 0 -> numberLen
                for (int x = 0; x < wholeNumber.ToString().Length + 2; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;

                }
            }
            //Case 6
            else if((cols - 1) > 0 && (row - 1) > 0 && (row + 1) < rows)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check above and below -1 -> numberLen
                for (int x = 0; x < wholeNumber.ToString().Length + 1; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }
            }


            //Case1
            if ((col + numberLen) < cols && (row + 1) < rows)
            {
                //Check right
                if (schematicArray[row, col + numberLen] != '.')
                    return true;
                //Check below 0 -> numberLen+1
                for (int x = 0; x < numberLen + 1; x++)
                {
                    if (schematicArray[row + 1, col + x] != '.')
                        return true;
                }
            }
            //Case 3
            else if((col - 1) > 0 && (row + 1) < rows)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check below -1 -> numberLen
                for (int x = 0; x < numberLen + 1; x++)
                {
                    if (schematicArray[row + 1, col - 1 + x] != '.')
                        return true;
                }
            }
            //Case 7
            else if((row - 1) > 0 && (col + numberLen) < cols)
            {
                //Check right
                if (schematicArray[row, col + numberLen] != '.')
                    return true;
                //Check above 0 -> numberLen
                for (int x = 0; x < wholeNumber.ToString().Length + 1; x++)
                {
                    if (schematicArray[row - 1, col + x] != '.')
                        return true;

                }
            }
            //Case 9
            else if((col - 1) > 0 && (row - 1) > 0)
            {
                //Check left
                if (schematicArray[row, col - 1] != '.')
                    return true;
                //Check above -1 -> numberLen
                for (int x = 0; x < wholeNumber.ToString().Length + 1; x++)
                {
                    if (schematicArray[row - 1, col - 1 + x] != '.')
                        return true;

                }
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
                if (col >= schematicArray.GetLength(0))
                    break;
            }
            sb.ToString().Trim();
            wholeNumber = int.Parse(sb.ToString());
            return wholeNumber;
        }
    }
}
