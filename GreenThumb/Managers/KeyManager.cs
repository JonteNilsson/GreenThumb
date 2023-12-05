
using System.IO;
using System.Security.Cryptography;

namespace GreenThumb.Managers
{
    public static class KeyManager
    {
        public static string GetEncryptionKey()
        {
            if (File.Exists("C:\\Users\\jonte\\OneDrive\\Skrivbord\\Key.txt"))
            {
                string Key = File.ReadAllText("C:\\Users\\jonte\\OneDrive\\Skrivbord\\Key.txt");

                return Key;

            }
            else
            {
                string key = GenerateEncryptionKey();
                File.WriteAllText("C:\\Users\\jonte\\OneDrive\\Skrivbord\\Key.txt", key);

                return key;
            }

        }

        public static string GenerateEncryptionKey()
        {
            var rng = new RNGCryptoServiceProvider();
            var byArray = new byte[16];
            rng.GetBytes(byArray);
            return Convert.ToBase64String(byArray);

        }
    }
}
