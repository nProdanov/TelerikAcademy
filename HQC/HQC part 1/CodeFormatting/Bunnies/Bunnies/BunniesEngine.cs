namespace Bunnies
{
    using System.Collections.Generic;
    using System.IO;

    using Bunnies.Contracts;
    using Bunnies.Loggers;
    using Bunnies.Models;
    using Bunnies.Types;

    public class BunniesEngine
    {
        public BunniesEngine(ICollection<IBunny> bunnies, string bunniesFilePath)
        {
            this.Bunnies = bunnies;
            this.ConsoleWriter = new ConsoleWriter();
            this.BunniesFilePath = bunniesFilePath;
            this.CreateBunniesTextFile();
            this.StreamWriter = new StreamWriter(bunniesFilePath);
        }

        public ICollection<IBunny> Bunnies { get; set; }

        public ConsoleWriter ConsoleWriter { get; set; }

        public string BunniesFilePath { get; set; }

        public FileStream FileStream { get; set; }

        public StreamWriter StreamWriter { get; set; }

        public void IntroduceBunnies()
        {
            foreach (var bunny in this.Bunnies)
            {
                bunny.Introduce(this.ConsoleWriter);
            }
        }

        public void SaveBunniesToATextFile()
        {
            using (this.StreamWriter)
            {
                foreach (var bunny in this.Bunnies)
                {
                    StreamWriter.WriteLine(bunny.ToString());
                }
            }
        }

        private void CreateBunniesTextFile()
        {
            var fileStream = File.Create(this.BunniesFilePath);
            fileStream.Close();
        }
    }
}
