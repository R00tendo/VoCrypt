using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoCryptLib;

namespace VoCryptCli
{
    internal class Operations
    {
        public static void CreateFile(string input, string output)
        {
            if (!File.Exists(input)) { Console.WriteLine("Input file doesn't exist"); return; }
            string password = "";
            Console.Write("Password protect? (y/n):");
            string? passProtect = Console.ReadLine();
            if (passProtect != null && passProtect.ToLower().Contains("y"))
            {
                bool passwordSet = false;
                List<string> _passwords = new List<string>();
                while (!passwordSet)
                {
                    if (_passwords.Count == 0)
                    {
                        Console.Write("Enter password:");
                    }
                    else
                    {
                        Console.Write("\nRepeat password:");
                    }
                    string _password = CliUtils.GetPassword();
                    if (_password == string.Empty)
                    {
                        Console.Write("\nPassword cannot be empty.\n");
                        continue;
                    }
                    _passwords.Add(_password);
                    if (_passwords.Count == 2)
                    {
                        if (_passwords[0] == _passwords[1])
                        {
                            break;
                        }
                        Console.Write("\nPasswords do not match.\n\n");
                        _passwords.Clear();
                        continue;
                    }
                }
                password = _passwords[0];
                _passwords.Clear();
            }


            Console.Write("\nCreating VoCr file...\n");

            var progress = ReadWrite.WriteFile(input, output, password);
            if (CliUtils.ProgressBar(progress))
                Console.WriteLine("File created!");
        }
        public static void OpenFile(string input, string output)
        {
            if (!File.Exists(input)) { Console.WriteLine("Input file doesn't exist"); return; }
            Console.Write("Password (empty for no password):");
            string password = CliUtils.GetPassword();

            Console.Write("\nOpening VoCr file...\n");

            var progress = ReadWrite.ReadFile(input, output, password);
            if (CliUtils.ProgressBar(progress))
                Console.WriteLine("File decrypted!");
            else
                if (File.Exists(output))
                File.Delete(output);
        }
        public static void DestroyFile(string input, bool keyOnly, string[] timer)
        {
            string[] files = [input];
            if (Directory.Exists(input))
            {
                files = Directory.GetFiles(input,
                    "*.VoCr",
                    SearchOption.AllDirectories);

            }
            else if (!File.Exists(input)) { Console.WriteLine("Input file doesn't exist"); return; }

            int deadTimer = 0;
            for (int i = 0; i < timer.Length; i++)
            {
                int parsedValue = int.Parse(timer[i]);
                switch (i)
                {
                    case 0:
                        deadTimer += parsedValue;
                        break;
                    case 1:
                        deadTimer += parsedValue * 60;
                        break;
                    case 2:
                        deadTimer += parsedValue * 60 * 60;
                        break;
                    case 3:
                        deadTimer += parsedValue * 60 * 60 * 24;
                        break;
                }
            }

            if (deadTimer > 0)
            {
                Console.WriteLine("Close Window to stop the timer.");
                for (int i = 0; i < deadTimer; i++)
                {
                    Console.Write($"{deadTimer - i} seconds left!{new string(' ', $"{deadTimer}".Length - $"{i}".Length)}\r");
                    Thread.Sleep(1000);
                }
            }

            foreach (string file in files)
            {
                Console.WriteLine($"Wiping: {file}");
                var progress = ReadWrite.Destroy(file, keyOnly);
                if (CliUtils.ProgressBar(progress))
                    Console.WriteLine("File destroyed!");
            }
        }
    }
}
