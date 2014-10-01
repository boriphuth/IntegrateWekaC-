using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace IntegrateWeka
{
    internal class Program
    {
        private static void Main()
        {
            const string wekaPath = "C:\\Program Files\\Weka-3-6\\";
            const string cmd = "java -cp \"" + wekaPath + "weka.jar\"weka.clusterers.SimpleKMeans -N 2 -t \"" + wekaPath + "data\\weather.arff\"";
            var output = run_weka(cmd);
            MessageBox.Show(output);

        }

        private static string run_weka(String cmd)
        {
            var dir = new Process
            {
                StartInfo =
                {
                    FileName = "CMD.EXE",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            }; // Will run CMD.EXE for you 
            dir.Start(); // Runs CMD.exe
            var sw = dir.StandardInput;
            var sr = dir.StandardOutput;
            var err = dir.StandardError; 
            sw.AutoFlush = true;
            sw.WriteLine(cmd); // Sends strings to CMD.EXE
            var output = sr.ReadToEnd().ToString(CultureInfo.InvariantCulture);
            sw.Close();
            sr.Close(); 
            err.Close();
            return output;
        }
    }
}
