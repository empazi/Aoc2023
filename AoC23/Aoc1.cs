using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC23
{
    class Aoc1
    {
        /*
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Aoc_day1_part1.txt"))
            {
                int ack = 0;
                while (sr.Peek() != -1)
                {
                    int firstDigit = -1;
                    int secondDigit= -1;
                    int[] digit = new int[2];
                    String line = sr.ReadLine();
                    StringBuilder sb = new StringBuilder();
                    List<int> listOfDigits = new List<int>();
                    if (line == null)
                        break;
                    for(int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];
                        if(c == 'o' || c == 't' || c == 'f' || c == 's' || c == 'e' || c == 'n')
                        {
                            digit = checkSpelledDigit(line, i);
                            if (digit[0] != -1)
                            {
                                listOfDigits.Add(digit[0]);
                                //i += digit[1] - 1;
                            }
                        }
                        if (Char.IsDigit(c))
                            listOfDigits.Add((c-48));
                        digit[0] = -1;
                        digit[1] = -1;
                    }
                    
                    sb.Append(listOfDigits.First<int>());
                    sb.Append(listOfDigits.Last<int>());
                    int twoDigitNumber = int.Parse(sb.ToString());
                    ack += twoDigitNumber;
                }
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(ack);
            }

        }

        private static int[] checkSpelledDigit(string line, int i)
        {
            int[] digitAndSkip = { -1, -1 };
            if (line.Length - i >= 3)
            {
                string s3 = line.Substring(i, 3);

                if (s3.Equals("one"))
                { 
                    digitAndSkip[0] = 1;
                    digitAndSkip[1] = 3;
                    return digitAndSkip;
                }
                else if(s3.Equals("two"))
                {
                    digitAndSkip[0] = 2;
                    digitAndSkip[1] = 3;
                    return digitAndSkip;
                }
                else if (s3.Equals("six"))
                {
                    digitAndSkip[0] = 6;
                    digitAndSkip[1] = 3;
                    return digitAndSkip;
                }
            }
            else
                return digitAndSkip;
            if (line.Length - i >= 4)
            {
                string s4 = line.Substring(i, 4);

                if (s4.Equals("four"))
                {
                    digitAndSkip[0] = 4;
                    digitAndSkip[1] = 4;
                    return digitAndSkip;
                }
                else if (s4.Equals("five"))
                {
                    digitAndSkip[0] = 5;
                    digitAndSkip[1] = 4;
                    return digitAndSkip;
                }
                else if (s4.Equals("nine"))
                {
                    digitAndSkip[0] = 9;
                    digitAndSkip[1] = 4;
                    return digitAndSkip;
                }
            }
            else
                return digitAndSkip;


            if (line.Length - i >= 5)
            {
                string s5 = line.Substring(i, 5);

                if (s5.Equals("seven"))
                {
                    digitAndSkip[0] = 7;
                    digitAndSkip[1] = 5;
                    return digitAndSkip;
                }
                else if (s5.Equals("eight"))
                {
                    digitAndSkip[0] = 8;
                    digitAndSkip[1] = 5;
                    return digitAndSkip;
                }
                else if (s5.Equals("three"))
                {
                    digitAndSkip[0] = 3;
                    digitAndSkip[1] = 5;
                    return digitAndSkip;
                }

            }
            else
                return digitAndSkip;

            return digitAndSkip;
        }
        */
    }
}
