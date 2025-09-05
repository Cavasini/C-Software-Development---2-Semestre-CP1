using cp1.Model;
using cp1.Utils;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== Processador de Arquivos TXT ===");

Console.Write("Informe o caminho da pasta com arquivos .txt: ");
string? path = Console.ReadLine();

if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
{
    Console.WriteLine("❌ Diretório inválido!");
    return;
}

var arquivos = Directory.GetFiles(path, "*.txt");
if (arquivos.Length == 0)
{
    Console.WriteLine("⚠ Nenhum arquivo .txt encontrado.");
    return;
}

Console.WriteLine("\nArquivos encontrados:");
foreach (var arq in arquivos)
    Console.WriteLine($"- {Path.GetFileName(arq)}");

Console.WriteLine("\nIniciando processamento...\n");

var tarefas = arquivos.Select(FileProcessor.AsyncProcessing).ToArray();
FileResult[] resultados = await Task.WhenAll(tarefas);

await ReportManager.SafeReportAsync(resultados);

Console.WriteLine("\n✅ Processamento concluído!");