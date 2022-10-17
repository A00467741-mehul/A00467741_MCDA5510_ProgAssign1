namespace ProgAssign1
{
    public class DirWalker
    {
        public void walk(string path, List<int> liVal)
        {
            string[] list = Directory.GetDirectories(path);

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath, liVal);
                }
            }

            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                SimpleCSVParser simpleCSVParser = new SimpleCSVParser();
                liVal = simpleCSVParser.parse(filepath, liVal);
            }
        }
    }
}
