namespace Space3D
{
    using System.IO;

    public static class PathStorage
    {
           public static void SavePath(Path path, string fileName)
        {
            string filePath = string.Format("..//..//{0}.txt",fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < path.Count; i++)
                {
                    writer.WriteLine(path[i]);
                }
            }
        }

        public static Path LoadPath(string filePath)
        {
            var pathFromFile = new Path();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.EndOfStream ==false)
                {
                    string point = reader.ReadLine();
                    pathFromFile.Add(Point3D.Parse(point));
                    
                }
            }

            return pathFromFile;
        }
    }
}
