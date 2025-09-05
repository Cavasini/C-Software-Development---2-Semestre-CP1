using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cp1.Model;

namespace cp1.Utils
{
    public static class ReportManager
    {
        public static async Task SafeReportAsync(IEnumerable<FileResult> results)
        {
            string exportDir = Path.Combine(AppContext.BaseDirectory, "export");
            Directory.CreateDirectory(exportDir);

            string reportPath = Path.Combine(exportDir, "relatorio.txt");

            var lines = results.Select(x => x.ToString());
            await File.WriteAllLinesAsync(reportPath, lines);

            Console.WriteLine($"\n✅ Relatório salvo em: {reportPath}");
        }
    }
}
