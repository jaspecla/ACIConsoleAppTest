using System;
using System.IO;
using System.Threading.Tasks;

namespace ACIConsoleAppTest
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var counter = 0;
      var max = args.Length != 0 ? Convert.ToInt32(args[0]) : -1;

      string path;
      if (args.Length > 1)
      {
        path = args[1];
      }
      else
      {
        path = Path.GetTempPath();
      }

      // format the date/time in a sortable way, but one that's also acceptable for a filename
      var today = DateTime.Now;
      var formattedDateTime = today.ToString("s").Replace(':', '-');

      var outputPath = Path.Combine(path, $"acitest.{formattedDateTime}.log");

      Console.WriteLine($"Writing to file {outputPath}");

      using (StreamWriter outputFile = new StreamWriter(outputPath))
      {
        while (max == -1 || counter < max)
        {
          var timestamp = DateTime.Now;
          var output = $"Counter: {++counter}: {timestamp.ToString("s")}";

          outputFile.WriteLine(output);

          await Task.Delay(1000);

          outputFile.Flush();
        }
      }
    }
  }
}
