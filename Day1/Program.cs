namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            int total = 0;

            foreach (string line in lines)
            {
                string numberString = "";
                int tempNumber = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out tempNumber)) 
                    {
                        break;
                    }
                    
                    if (CheckNumbers(line, i, out tempNumber)) 
                    {
                        break;
                    }
                }

                numberString += tempNumber.ToString();

                for (int i = (line.Length - 1); i >= 0; i--)
                {
                    if (int.TryParse(line[i].ToString(), out tempNumber))
                    {
                        break;
                    }

                    if (line.Length - i >= 3)
                    {
                        if (CheckNumbers(line, i, out tempNumber))
                        {
                            break;
                        }
                    }
                }

                numberString += tempNumber.ToString();

                total += int.Parse(numberString);
            }

            Console.WriteLine(total);
        }

        public static bool CheckNumbers(string fullLine, int startIndex, out int tempNumber)
        {
            try
            {
                string line = fullLine.Substring(startIndex);

                if (line.Substring(0, 3) == "one")
                {
                    tempNumber = 1;
                    return true;
                }
                else if (line.Substring(0, 3) == "two")
                {
                    tempNumber = 2;
                    return true;
                }
                else if (line.Substring(0, 3) == "six")
                {
                    tempNumber = 6;
                    return true;
                }
                else if (line.Substring(0, 4) == "four")
                {
                    tempNumber = 4;
                    return true;
                }
                else if (line.Substring(0, 4) == "five")
                {
                    tempNumber = 5;
                    return true;
                }
                else if (line.Substring(0, 4) == "nine")
                {
                    tempNumber = 9;
                    return true;
                }
                else if (line.Substring(0, 5) == "seven")
                {
                    tempNumber = 7;
                    return true;
                }
                else if (line.Substring(0, 5) == "eight")
                {
                    tempNumber = 8;
                    return true;
                }
                else if (line.Substring(0, 5) == "three")
                {
                    tempNumber = 3;
                    return true;
                }
                else
                {
                    tempNumber = 0;
                    return false;
                }
            }
            catch (ArgumentOutOfRangeException error)
            {
                tempNumber = 0;
                return false;
            }
        }
    }
}