using System.IO.Compression;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using System.Text;

namespace VoCryptLib
{
    /// <summary>
    /// Contains all encryption related stuff for the VoCrypt program.
    /// Ciphertext format: IV (16 bytes) + encrypted data
    /// </summary>
    public class Encryption
    {
        private byte[] Key;
        private byte[] IV;

        /// <summary>
        /// Creates encryption key and generates IV.
        /// Methods:
        /// <list type="bullet">
        ///   <item>Encrypt</item>
        ///   <item>Decrypt</item>
        /// </list>
        /// <example>
        /// For example:
        /// <code>
        /// Encryption cipher = new(Encoding.UTF8.GetBytes("password1234"));
        /// byte[] cipherText = cipher.Encrypt(...);
        /// byte[] clearText = cipher.Decrypt(...);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="_Key"></param>
        public Encryption(byte[] _Key)
        {
            _Key = Encoding.UTF8.GetBytes("--VOCRYPT SALT 1.0--").Concat(_Key.Concat(Encoding.UTF8.GetBytes("::VOCRYPT SALT 1.1::"))).ToArray();
            var hash = new Argon2id(_Key);
            hash.Iterations = 50000;
            hash.MemorySize = 4;
            hash.DegreeOfParallelism = 1;
            hash.Salt = Encoding.UTF8.GetBytes("||VOCRYPT SALT 2.0||");
            this.Key = hash.GetBytes(32);
            using Aes aes = Aes.Create();
            this.IV = aes.IV;
        }

        /// <summary>
        /// <example>
        /// For example:
        /// <code>
        /// byte[] cipherText = cipher.Encrypt(...);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public byte[] Encrypt(byte[] plainText)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));

            byte[] encrypted;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (BinaryWriter swEncrypt = new(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            using (var output = new MemoryStream())
            {
                return this.IV.Concat(encrypted).ToArray();
            }
        }

        /// <summary>
        /// <example>
        /// For example:
        /// <code>
        /// byte[] clearText = cipher.Decrypt(...);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="_cipherText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public byte[] Decrypt(byte[] _cipherText)
        {
            if (_cipherText == null || _cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(_cipherText));
            byte[] cipherText = _cipherText;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = cipherText[..16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText[16..]))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream srDecrypt = new())
                        {
                            csDecrypt.CopyTo(srDecrypt);
                            return srDecrypt.ToArray();
                        }
                    }
                }
            }
        }
    }
}