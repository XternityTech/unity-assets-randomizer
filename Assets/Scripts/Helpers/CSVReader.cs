using System.Collections.Generic;
using System.IO;

namespace Xternity.Helpers
{
    public static class CSVReader
    {
        private const char lineSeperater = '\n'; // It defines line seperate character
        private const char fieldSeperator = ','; // It defines field seperate chracter
        
        public static List<List<string>> ParseFile(string path)
        {
            var lists = new List<List<string>>();

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var list = new List<string>();
                
                var values = line.Split(',');

                foreach (var value in values)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        list.Add(value);
                    }
                }
                
                lists.Add(list);
            }
            
            return lists;
        }
    }
}