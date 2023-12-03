using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC23
{
    internal class Aoc2_part1
    {
        /*
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Aoc_day2_part1.txt"))
            {
                int acceptedGame = 0;
                int redCubesLimit = 12;
                int greenCubesLimit = 13;
                int blueCubesLimit = 14;
                int gameIndex = 1;
                while (sr.Peek() != -1)
                {
                    bool possibleGame = true;
                    String game = sr.ReadLine();
                    string[] gameResults = game.Split(":");
                    string[] setPerGame = gameResults[1].Split(";");
                    foreach(var set in setPerGame)
                    {
                        string[] colorsPerSet = set.Split(",");
                        for(int i = 0; i < colorsPerSet.Length; i++)
                        {
                            string[] cubesPerColor = colorsPerSet[i].Split(" ");
                            byte[] asciiBytes = Encoding.ASCII.GetBytes(cubesPerColor[1]);
                            string color = cubesPerColor[2];


                            //int numberOfCubes = (int)ConvertLittleEndian(asciiBytes) - 48;
                            string numberInText = cubesPerColor[1];
                            int numberOfCubes = int.Parse(numberInText);
                            if (color.Equals("green") && numberOfCubes > greenCubesLimit)
                                possibleGame = false;
                            else if (color.Equals("red") && numberOfCubes > redCubesLimit)
                                possibleGame = false;
                            else if (color.Equals("blue") && numberOfCubes > blueCubesLimit)
                                possibleGame = false;
                        }
                    }
                    if(possibleGame)
                        acceptedGame += gameIndex;
                    gameIndex++;
                }
                Console.WriteLine(acceptedGame);
            }

        }
        */
        static ulong ConvertLittleEndian(byte[] array)
        {
            int pos = 0;
            ulong result = 0;
            foreach (byte by in array)
            {
                result |= ((ulong)by) << pos;
                pos += 8;
            }
            return result;
        }
    }
}
