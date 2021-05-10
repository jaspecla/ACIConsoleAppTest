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

      var outputFileName = Path.Combine(path, "acitest.log");

      Console.WriteLine($"Writing to file {outputFileName}");

      using (StreamWriter outputFile = new StreamWriter(outputFileName))
      {
        while (max == -1 || counter < max)
        {
          var output = $"Counter: {++counter}";

          outputFile.WriteLine(output);

          await Task.Delay(1000);

          outputFile.Flush();
        }
      }
    }
  }
}
