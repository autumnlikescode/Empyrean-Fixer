using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordInjectionsRemover
{
    internal class EmpyreanRemover
    {
        public static int EmpyreanCounter = 0;
        public static void removeEmpyrean()
        {
            string startupDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            bool EmpyreanFound = false;
            
            if (Directory.Exists(startupDirectory))
            {
                string[] files = Directory.GetFiles(startupDirectory, "*.exe", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    if (FileContainsText(file, "pyinstaller"))
                    {
                        EmpyreanCounter++;
                        EmpyreanFound = true;
                        string fileName = Path.GetFileName(file);
                        Logger.Warn("Potential Empyrean Found: Startup\\" + fileName); // Some LEGITIMATE companies use pyinstaller, added check to see if it is a required file or not.
                        Logger.Warn("Deleted: Startup\\" + fileName); // Some LEGITIMATE companies use pyinstaller, added check to see if it is a required file or not.
                        File.Delete(file);

                        System.Threading.Thread.Sleep(1000);
                    }

                }

                if (!EmpyreanFound)
                    Logger.Info("Empyrean Not Found.");


            }
            else
            {
                Console.WriteLine("Startup directory not found.");
            }

            Console.Clear();
            if (EmpyreanCounter <= 0)
            {
                Logger.Info("Empyrean Not Found.");
            }
            else
            {
                Logger.Info($"Deleted {EmpyreanCounter} Suspicious File(s)");
            }
            
        }

        // Create a check to see if it contains pyinstaller in the strings.
        static bool FileContainsText(string filePath, string searchText)
        {
            try
            {
                string fileContent = System.IO.File.ReadAllText(filePath);
                return fileContent.Contains(searchText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Handle any exceptions that occur during file reading
            }

            return false;
        }
    }
}
