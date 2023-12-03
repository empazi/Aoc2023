using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC23
{
    internal class Aoc2_part2
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
                //int powerPerGame = 0;
                int gameIndex = 1;
                while (sr.Peek() != -1)
                {
                    int[] minimumColors = { 1, 1, 1 };
                    bool possibleGame = true;
                    String game = sr.ReadLine();
                    string[] gameResults = game.Split(":");
                    string[] setPerGame = gameResults[1].Split(";");
                    foreach (var set in setPerGame)
                    {
                        string[] colorsPerSet = set.Split(",");
                        for (int i = 0; i < colorsPerSet.Length; i++)
                        {
                            string[] cubesPerColor = colorsPerSet[i].Split(" ");
                            byte[] asciiBytes = Encoding.ASCII.GetBytes(cubesPerColor[1]);
                            string color = cubesPerColor[2];


                            //int numberOfCubes = (int)ConvertLittleEndian(asciiBytes) - 48;
                            string numberInText = cubesPerColor[1];
                            int numberOfCubes = int.Parse(numberInText);
                            if (color.Equals("green"))
                            {
                                //Set the new minimumReq of green...
                                if(numberOfCubes > minimumColors[0])
                                    minimumColors[0] = numberOfCubes;
                            }
                            else if (color.Equals("red"))
                            {
                                //Set the new minimumReq of green...
                                if (numberOfCubes > minimumColors[1])
                                    minimumColors[1] = numberOfCubes;
                            }
                            else if (color.Equals("blue"))
                            {
                                    if (numberOfCubes > minimumColors[2])
                                        minimumColors[2] = numberOfCubes;
                            }
                        }
                    }
                    int powerPerGame = 1;
                    for(int i = 0; i < minimumColors.Length; i++)
                        powerPerGame *= minimumColors[i];
                    acceptedGame += powerPerGame;
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
