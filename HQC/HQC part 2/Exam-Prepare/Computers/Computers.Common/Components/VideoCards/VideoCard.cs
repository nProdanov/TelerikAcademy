using System;

using Computers.Common.Contracts;

namespace Computers.Common.Components.VideoCards
{
    public abstract class VideoCard : IVideoCard
    {
        protected ConsoleColor graphicColour;

        public void Draw(string textToDraw)
        {
            Console.ForegroundColor = this.graphicColour;
            Console.WriteLine(textToDraw);
            Console.ResetColor();
        }
    }
}
