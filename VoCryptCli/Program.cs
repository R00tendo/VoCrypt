using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using VoCryptLib;

namespace VoCryptCli
{ 

    public class VoCryptCli
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine(usage);
                return;
            }
            args[1] = args[1].ToLower();
            switch (args[0])
            {
                case "create":
                    if (args.Length < 3)
                    {
                        Console.WriteLine(usage);
                        return;
                    }
                    Operations.CreateFile(args[1], args[2]);
                    break;
                case "open":
                    if (args.Length < 3)
                    {
                        Console.WriteLine(usage);
                        return;
                    }
                    Operations.OpenFile(args[1], args[2]);
                    break;
                case "destroy":
                    Operations.DestroyFile(args[1],
                        (args.Length > 2 && args[2].ToLower() == "true")
                        ? true
                        : false, 
                        args.Length > 3
                        ? args[3..]
                        : []);
                    break;
                default:
                    Console.WriteLine(usage);
                    return;
            }
        }

        public static string usage = @"Usage: <command> <command argument>


Examples:
    VoCryptCli.exe create archive.tar archive.tar.VoCr

    VoCryptCli.exe open archive.tar.VoCr archive.tar

    VoCryptCli.exe destroy archive.tar.VoCr : 
        Overwrites bits and pieces everwhere in the file making it 
        impossible to decrypt even with the right key.

    VoCryptCli.exe destroy archive.tar.VoCr true :
        Only wipes the decryption key without scrambling encrypted data itself
        (faster but little less secure).


Commands:
    create <input file> <output file>

    open <input file> <output file>

    destroy <input file or folder> <optional: keyonly> <dead man's switch timer (seconds)> <minutes> <hours> <days>
";
        
    }
}