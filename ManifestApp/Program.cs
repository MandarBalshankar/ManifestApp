//Manifest Utility
//Author: Mandar Balshankar
//Date: 16/05/2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ManifestApp
{
    class ManifestAppProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\t\tMANIFEST FILE GENERATION UTILITY \n");
            Console.WriteLine("Enter the entire path of the patch folder: ");
            string ManifestPath = Console.ReadLine();

            if (!string.IsNullOrEmpty(ManifestPath))
            {
                //This will delete the existing ManifestFile.csv if present in the directory
                if (File.Exists(ManifestPath + "\\ManifestFile.csv"))
                {
                    File.Delete(ManifestPath + "\\ManifestFile.csv");
                }

                string[] files = Directory.GetFiles(ManifestPath, "*", SearchOption.AllDirectories);

                List<string> outputFile = new List<string>();

                outputFile.Add("File Path,Full Name,Extension,Size in bytes, Last Modified");

                foreach (string file in files)
                {
                    FileInfo f = new FileInfo(file);
                    outputFile.Add(file + "," + f.Name + "," + f.Extension + "," + f.Length.ToString() + "," + f.LastWriteTimeUtc);
                }

                File.WriteAllText(ManifestPath + "\\ManifestFile.csv", string.Join(Environment.NewLine, outputFile));

                Console.WriteLine("\nTotal number of files found in the patch: {0}", files.Length, "\n");
                Console.WriteLine("\nDetails saved in ManifestFile.csv\n");
            }
            else
            {
                Console.WriteLine("Invalid path...");
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

    }
}