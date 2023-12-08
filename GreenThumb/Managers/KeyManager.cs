namespace GreenThumb.Managers
{
    public static class KeyManager
    {


        // Har lagt nyckeln direkt i constructor istället för att ha den på en filväg i datorn för det ska bli enklare
        // att kolla funktioner i koden.
        // Kollade lite på Mehdi´s kod för han hade gjort en annan metod för att lägga textfilen i programmet istället, ville ha liknande men ville ej kopiera kod.!



        //public static string GetEncryptionKey()
        //{
        //    if (File.Exists("C:\\Users\\jonte\\OneDrive\\Skrivbord\\Key.txt"))
        //    {
        //        string Key = File.ReadAllText("C:\\Users\\jonte\\OneDrive\\Skrivbord\\Key.txt");

        //        return Key;

        //    }
        //    else
        //    {
        //        string key = GenerateEncryptionKey();
        //        File.WriteAllText("C:\\Users\\jonte\\OneDrive\\Skrivbord\\Key.txt", key);

        //        return key;
        //    }

        //}

        //public static string GenerateEncryptionKey()
        //{
        //    var rng = new RNGCryptoServiceProvider();
        //    var byArray = new byte[16];
        //    rng.GetBytes(byArray);
        //    return Convert.ToBase64String(byArray);

        //}
    }
}
