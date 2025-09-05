using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp1.Model
{
    public class FileResult
    {
        public string Name { get; set; }
        public int Lines { get; set; }
        public int Words { get; set; }

        public FileResult(string name, int lines, int words)
        {
            Name = name;
            Lines = lines;
            Words = words;
        }

        public override string ToString()
        {
            return $"{Name} - {Lines} linhas - {Words} palavras";
        }
    }
}
