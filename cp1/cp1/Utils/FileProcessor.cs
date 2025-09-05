using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cp1.Model;

namespace cp1.Utils
{
    public static class FileProcessor
    {
      public static async Task<FileResult> AsyncProcessing(string fileDirectory)
        {
            string name = Path.GetFileName(fileDirectory);
            Console.WriteLine($"Processando arquivo {name}...");

            string[] lines = await File.ReadAllLinesAsync(fileDirectory);

            int linesCount= lines.Length;
            int wordsCount = 0;

            foreach(string line in lines)
            {
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                wordsCount += words.Length;
            }

            var result = new FileResult(name, linesCount, wordsCount);
            Console.WriteLine($"✔ {result}");
            return result;
        }
    }
}
