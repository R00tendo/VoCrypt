internal class CliUtils
{
    public static bool ProgressBar(IEnumerable<int> progress)
    {
        try
        {
            string bar = "Progress: [" + new string('.', 100) + "] 0%";
            Console.Write(bar + "\r");
            foreach (int percentage in progress)
            {
                bar = "Progress: [" + new string('#', percentage) + new string('.', 100 - percentage) + $"] {percentage}%";
                Console.Write(bar + "\r");
            }
            Console.WriteLine(bar + " COMPLETED!");
        }
        catch
        {
            Console.Write("\nSomething went wrong!\nIf you were opening a file, make sure the password is correct.\n");
            return false;
        }
        return true;
    }
    public static string GetPassword()
    {
        var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
        return pass;
    }
}