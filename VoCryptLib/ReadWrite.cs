using System.Security.Cryptography;
using System.Text;

namespace VoCryptLib
{
    public class ReadWrite
    {

        public static byte[] pattern = [50, 0, 25, 0, 25, 0, 25, 0, 25, 0, 25, 0, 25, 0, 50];
        public static long ChunkSize = 1048576;
        public static byte[] ReadBlock(BinaryReader reader, Encryption? cipher)
        {
            ArgumentNullException.ThrowIfNull(reader);

            List<byte> buffer = [];
            while (true)
            {
                if (buffer.Count > pattern.Length
                    ? buffer
                    .GetRange(buffer.Count - pattern.Length, pattern.Length)
                    .ToArray()
                    .SequenceEqual(pattern) : false)
                {
                    var block = buffer.ToArray()[..^pattern.Length];
                    if (cipher != null)
                    {
                        return cipher.Decrypt(block);
                    }
                    return block;
                }

                byte @byte = reader.ReadByte();
                buffer.Add(@byte);
            }
        }
        public static byte[] ReadKey(BinaryReader reader)
        {
            ArgumentNullException.ThrowIfNull(reader);
            var oldLoc = reader.BaseStream.Seek(0, SeekOrigin.Current);

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[]? key = ReadBlock(reader, null);
            ArgumentNullException.ThrowIfNull(key);

            reader.BaseStream.Seek(oldLoc, SeekOrigin.Begin);
            return key;
        }
        public static IEnumerable<int> ReadFile(string input, string output, string password)
        {
            if (!File.Exists(input))
            {
                throw new Exception("file not found");
            }

            using (BinaryWriter writer = new(File.Open(output, FileMode.Create)))
            using (BinaryReader reader = new(File.Open(input, FileMode.Open)))
            {
                long fileSize = new System.IO.FileInfo(input).Length;
                long totalRead = 0;

                byte[] key = ReadKey(reader);
                ReadBlock(reader, null);

                if (password != String.Empty)
                {
                    Encryption keyCipher = new(Encoding.UTF8.GetBytes(password));
                    key = keyCipher.Decrypt(key);
                }
                Encryption cipher = new(key);

                while (true)
                {
                    try
                    {
                        byte[] block = ReadBlock(reader, cipher);
                        writer.Write(block);
                        totalRead += block.Length;
                    }
                    catch (EndOfStreamException _)
                    {
                        break;
                    }
                    yield return (int)(((double)totalRead / (double)fileSize) * 100);
                }
                if (totalRead == 0)
                {
                    throw new CryptographicException("no blocks read");
                }
            }
            yield return 100;
        }

        public static (byte[], byte[]) GenKey(string password)
        {
            using var cryptoProvider = RandomNumberGenerator.Create();
            byte[] largePass = new byte[1024];
            cryptoProvider.GetNonZeroBytes(largePass);
            if (largePass == null)
            {
                throw new Exception("could not generate secure randomness");
            }
            byte[] beginning = largePass;
            if (password != String.Empty)
            {
                Encryption passCipher = new(Encoding.UTF8.GetBytes(password));
                beginning = passCipher.Encrypt(largePass);
            }
            return (beginning, largePass);
        }

        public static byte[] GenKey()
        {
            using var cryptoProvider = RandomNumberGenerator.Create();
            byte[] largePass = new byte[1024];
            cryptoProvider.GetNonZeroBytes(largePass);
            return largePass;
        }

        public static IEnumerable<int> WriteFile(string input, string output, string password)
        {

            if (!File.Exists(input))
            {
                throw new Exception("file not found");
            }

            var (beginning, largePass) = GenKey(password);

            Encryption cipher = new(largePass);

            using (BinaryWriter writer = new(File.Open(output, FileMode.Create)))
            using (BinaryReader reader = new(File.Open(input, FileMode.Open)))
            {
                long fileSize = new System.IO.FileInfo(input).Length;
                long totalRead = 0;
                writer.Write(beginning.Concat(pattern).ToArray());

                while (true)
                {
                    byte[] buffer = new byte[ChunkSize];
                    int n = reader.Read(buffer);
                    if (n == 0) { break; }
                    totalRead += n;
                    writer.Write(cipher.Encrypt(buffer[..n]).Concat(pattern).ToArray());
                    yield return (int)(((double)totalRead / (double)fileSize) * 100);
                }
            }
            yield return 100;
        }

        public static IEnumerable<int> Destroy(string input, bool keyOnly)
        {
            if (!File.Exists(input))
            {
                throw new Exception("file not found");
            }

            using (Stream writer = new FileStream(input, FileMode.Open))
            {
                long fileSize = new System.IO.FileInfo(input).Length;

                writer.Seek(0, SeekOrigin.Begin);
                var randomBytes = Enumerable.Range(1, 10).Select(_ => GenKey()).SelectMany(x => x).ToArray();
                writer.Write(randomBytes);
                if (!keyOnly)
                {
                    long curLoc;
                    var rnd = new Random();
                    while (true)
                    {
                        try
                        {
                            int randLoc = rnd.Next(randomBytes.Length - 5);
                            writer.Write(randomBytes[randLoc..(randLoc+rnd.Next(1,5))]);
                            curLoc = writer.Seek(rnd.Next(200, 1000), SeekOrigin.Current);
                            if (writer.Seek(0, SeekOrigin.Current) > fileSize) { break; }
                        }
                        catch
                        {
                            break;
                        }
                        yield return (int)(((double)curLoc / (double)fileSize) * 100);
                    }
                }
            }
            yield return 100;
        }
    }
}
