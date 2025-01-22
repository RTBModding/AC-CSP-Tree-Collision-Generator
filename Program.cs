using System;
using System.Globalization;
using System.IO; // For file operations
using System.Windows.Forms;

namespace treecollider
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Made by SLX.");
            string fileName = OpenInputFile();

            if (string.IsNullOrEmpty(fileName))
            {
                ExitWithMessage("No file was selected.");
            }

            string outputText = "";

            try
            {
                foreach (string line in File.ReadLines(fileName)) // Efficient for large files
                {
                    if (line.StartsWith("tree:"))
                    {
                        string[] coords;
                        try
                        {
                            string cleanLine = line.Remove(0, 5);
                            coords = cleanLine.Split(";")[1].Split(",");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Line does not follow expected pattern. Skipping:");
                            Console.WriteLine(line);
                            continue;
                        }


                        if (coords.Length != 3)
                        {
                            Console.WriteLine("Coordinate missing on tree. Skipping:");
                            Console.WriteLine(line);
                            continue;
                        }

                        outputText += addColliderText(coords);
                    }
                }

                File.WriteAllText(Path.Combine(Path.GetDirectoryName(fileName), "treecollider.txt"), outputText);
                ExitWithMessage("treecollider.txt has been created/updated next to your input file.");
            }
            catch (Exception ex)
            {
                ExitWithMessage($"Error reading file: {ex.Message}");
            }

        }

        public static string OpenInputFile()
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dlg.Title = "Select trees.txt in your Assetto Corsa map";

            // Show the dialog and check if the user clicked OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName; // Return the selected file name
            }
            return "";
        }

        public static string addColliderText(string[] coords)
        {
            string multilineString = $@"
[COLLIDER_CAPSULE_...]
RADIUS = 0.5
POSITION = {coords[0].ToString()}, {coords[1].ToString()}, {coords[2].ToString()}
DIRECTION = 0, 1, 0
LENGTH = 10
";

            return multilineString;
        }


        public static void ExitWithMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
