namespace Day16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");  
            List<int> tilesList = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                List<Beam> beams = new List<Beam>();
                NewBeamRight(lines, 0, i, beams);
                int energizedTiles = 0;


                for (int k = 0; k < lines.Length; k++)
                {
                    for (int j = 0; j < lines[0].Length; j++)
                    {
                        if (beams.Exists(x => x.Energized(j, k)))
                        {
                            energizedTiles++;
                            //Console.Write("#");
                        }
                        else
                        {
                            //Console.Write(".");
                        }


                    }

                    //Console.WriteLine();
                }

                tilesList.Add(energizedTiles);

                //Part 1: Console.WriteLine("Number of energized tiles: " + energizedTiles);
            }

            for (int i = 0; i < lines.Length; i++)
            {
                List<Beam> beams = new List<Beam>();
                NewBeamLeft(lines, lines[0].Length - 1, i, beams);
                int energizedTiles = 0;


                for (int k = 0; k < lines.Length; k++)
                {
                    for (int j = 0; j < lines[0].Length; j++)
                    {
                        if (beams.Exists(x => x.Energized(j, k)))
                        {
                            energizedTiles++;
                            //Console.Write("#");
                        }
                        else
                        {
                            //Console.Write(".");
                        }


                    }

                    //Console.WriteLine();
                }

                tilesList.Add(energizedTiles);
            }

            for (int i = 0; i < lines[0].Length; i++)
            {
                List<Beam> beams = new List<Beam>();
                NewBeamDown(lines, i, 0, beams);
                int energizedTiles = 0;


                for (int k = 0; k < lines.Length; k++)
                {
                    for (int j = 0; j < lines[0].Length; j++)
                    {
                        if (beams.Exists(x => x.Energized(j, k)))
                        {
                            energizedTiles++;
                            //Console.Write("#");
                        }
                        else
                        {
                            //Console.Write(".");
                        }


                    }

                    //Console.WriteLine();
                }

                tilesList.Add(energizedTiles);
            }

            for (int i = 0; i < lines[0].Length; i++)
            {
                List<Beam> beams = new List<Beam>();
                NewBeamUp(lines, i, lines.Length - 1, beams);
                int energizedTiles = 0;


                for (int k = 0; k < lines.Length; k++)
                {
                    for (int j = 0; j < lines[0].Length; j++)
                    {
                        if (beams.Exists(x => x.Energized(j, k)))
                        {
                            energizedTiles++;
                            //Console.Write("#");
                        }
                        else
                        {
                            //Console.Write(".");
                        }


                    }

                    //Console.WriteLine();
                }

                tilesList.Add(energizedTiles);
            }

            Console.WriteLine($"Maximum number of energized tiles: " + tilesList.Max());


        } //Wrong answers: 4544 (low) (downward beams reflected the wrong way

        public static void NewBeamRight(string[] lines, int startX, int startY, List<Beam> beams)
        {
            int xPos = startX;

            if (!(startY > -1 && startY < lines.Length && startX > -1 && startX < lines[0].Length))
            {
                return;
            }

            while ((lines[startY][xPos] == '.'
                || lines[startY][xPos] == '-')
                && xPos < lines[0].Length - 1)
            {
                xPos++;
            }

            Beam newBeam = new HorizontalBeam(startY, startX, xPos);
            if (!beams.Exists(x => x.Equals(newBeam)))
            {
                beams.Add(newBeam);
                if (lines[startY][xPos] == '/')
                {
                    NewBeamUp(lines, xPos, startY - 1, beams);
                }
                else if (lines[startY][xPos] == '\\')
                {
                    NewBeamDown(lines, xPos, startY + 1, beams);
                }
                else if (lines[startY][xPos] == '|')
                {
                    NewBeamDown(lines, xPos, startY + 1, beams);
                    NewBeamUp(lines, xPos, startY - 1, beams);
                }
            }

            

        }

        public static void NewBeamUp(string[] lines, int startX, int startY, List<Beam> beams)
        {
            int yPos = startY;

            if (!(startY > -1 && startY < lines.Length && startX > -1 && startX < lines[0].Length))
            {
                return;
            }

            while (yPos > 0
                && (lines[yPos][startX] == '.'
                || lines[yPos][startX] == '|'))
            {
                
                yPos--;
            }


            Beam newBeam = (new VerticalBeam(startX, startY, yPos));
            if (!beams.Exists(x => x.Equals(newBeam)))
            {
                beams.Add(newBeam);

                if (lines[yPos][startX] == '/')
                {
                    NewBeamRight(lines, startX + 1, yPos, beams);
                }
                else if (lines[yPos][startX] == '\\')
                {
                    NewBeamLeft(lines, startX - 1, yPos, beams);
                }
                else if (lines[yPos][startX] == '-')
                {
                    NewBeamRight(lines, startX + 1, yPos, beams);
                    NewBeamLeft(lines, startX - 1, yPos, beams);
                }
            }

            
        }

        public static void NewBeamLeft(string[] lines, int startX, int startY, List<Beam> beams)
        {
            int xPos = startX;

            if (!(startY > -1 && startY < lines.Length && startX > -1 && startX < lines[0].Length))
            {
                return;
            }

            while (xPos > 0 && 
                (lines[startY][xPos] == '.'
                || lines[startY][xPos] == '-'))
            {
                xPos--;
            }

            Beam newBeam = new HorizontalBeam(startY, startX, xPos);
            if (!beams.Exists(x => x.Equals(newBeam)))
            {
                beams.Add(newBeam);

                if (lines[startY][xPos] == '/')
                {
                    NewBeamDown(lines, xPos, startY + 1, beams);
                }
                else if (lines[startY][xPos] == '\\')
                {
                    NewBeamUp(lines, xPos, startY - 1, beams);
                }
                else if (lines[startY][xPos] == '|')
                {
                    NewBeamDown(lines, xPos, startY + 1, beams);
                    NewBeamUp(lines, xPos, startY - 1, beams);
                }
            }

            
        }

        public static void NewBeamDown(string[] lines, int startX, int startY, List<Beam> beams)
        {
            int yPos = startY;

            if (!(startY > -1 && startY < lines.Length && startX > -1 && startX < lines[0].Length))
            {
                return;
            }

            while (yPos < lines.Length - 1               
                && 
                (lines[yPos][startX] == '.'
                || lines[yPos][startX] == '|'))
            {
                char test = lines[yPos][startX];
                yPos++;
            }

            Beam newBeam = new VerticalBeam(startX, startY, yPos);
            if (!beams.Exists(x => x.Equals(newBeam)))
            {
                beams.Add(newBeam);

                if (lines[yPos][startX] == '/')
                {
                    NewBeamLeft(lines, startX - 1, yPos, beams);
                }
                else if (lines[yPos][startX] == '\\')
                {
                    NewBeamRight(lines, startX + 1, yPos, beams);
                }
                else if (lines[yPos][startX] == '-')
                {
                    NewBeamRight(lines, startX + 1, yPos, beams);
                    NewBeamLeft(lines, startX - 1, yPos, beams);
                }
            }

            
        }
    }
}