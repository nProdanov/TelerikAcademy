using System;
using System.Collections.Generic;
using System.Linq;

namespace DancingMoves
{
    internal class DancingEngine
    {
        internal void Start()
        {
            var commands = this.Read();

            var dancer = this.ProcessCommands(commands);

            Console.WriteLine("{0:F1}", dancer.AveragePointsPerLine);
        }

        private IList<string> Read()
        {
            var lines = new List<string>();
            while (true)
            {
                var currLine = Console.ReadLine();
                if (currLine == "stop")
                {
                    break;
                }

                lines.Add(currLine);
            }

            return lines;
        }

        private Dancer ProcessCommands(IList<string> lines)
        {
            var stepsPath = this.GetStepsPath(lines[0]);
            var dancer = new Dancer(stepsPath);

            for (int i = 1; i < lines.Count; i++)
            {
                this.ProccessSingleCommand(lines[i], dancer);
            }

            return dancer;
        }

        private void ProccessSingleCommand(string currentLine, Dancer dancer)
        {
            var lineProperties = currentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int moves = int.Parse(lineProperties[0]);
            var direction = lineProperties[1];
            var step = int.Parse(lineProperties[2]);

            if (direction == "right")
            {
                dancer.MoveRight(moves, step);
            }
            else
            {
                dancer.MoveLeft(moves, step);
            }
        }

        private int[] GetStepsPath(string text)
        {
            var splitedText = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stepsPath = splitedText
                    .Select(int.Parse)
                    .ToArray();

            return stepsPath;
        } 
    }
}
