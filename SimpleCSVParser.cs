using Microsoft.VisualBasic.FileIO;

namespace ProgAssign1
{
    public class SimpleCSVParser
    {
        public List<int> parse(string fileName, List<int> countLines)
        {
            string outFilePath = @"..\\..\\..\\Output\\Output.txt";
            int skipRowCounter = 0;
            int acceptRowcounter = 0;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        List<string> liItems = new List<string>();
                        //Process row
                        string[] fields = parser.ReadFields();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            string field = fields[i];
                            liItems.Add(field);
                        }
                        if (liItems.Any(x => string.IsNullOrEmpty(x)))
                        {
                            skipRowCounter++;
                        }
                        else
                        {
                            acceptRowcounter++;
                            for (int i = 0; i < liItems.Count; i++)
                            {
                                using (StreamWriter writer = new StreamWriter(outFilePath, append: true))
                                {
                                    if (i != 9)
                                    {
                                        writer.Write(liItems[i] + ",");
                                    }
                                    else
                                    {
                                        writer.WriteLine(liItems[i]);
                                    }
                                }
                            }
                        }
                    }
                    skipRowCounter += countLines[0];
                    acceptRowcounter += countLines[1];
                    countLines.Clear();
                    countLines.Add(skipRowCounter);
                    countLines.Add(acceptRowcounter);
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
            return countLines;
        }
    }
}
