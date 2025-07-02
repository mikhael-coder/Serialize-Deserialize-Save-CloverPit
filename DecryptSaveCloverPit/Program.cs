using System;
using System.IO;

public static class SaveCrypto
{
    private const string GAME_PASSWORD = "uoiyiuh_+=-5216gh;lj??!/345";
    private const string ACHIEVEMENTS_PASSWORD = "afhjttiojd?s0989sdfl12";

    public static byte[] Decrypt(byte[] input, string password)
    {
        if (input == null || input.Length == 0 || string.IsNullOrEmpty(password))
            return Array.Empty<byte>();

        int shifts = CryptoShiftsNumber(password);
        byte[] data = (byte[])input.Clone();
        byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);

        byte[] tempKey = GenerateTempKey(pwdBytes);
        for (int j = 0; j < data.Length; j++)
        {
            data[j] = (byte)(data[j] ^ tempKey[j % tempKey.Length]);
        }
        return data;
    }

    private static int CryptoShiftsNumber(string password)
    {
        int shifts = 8;
        foreach (char c in password) shifts += c;
        while (shifts > 16 || shifts < 8)
        {
            if (shifts > 16) shifts -= 16;
            if (shifts < 8) shifts += 8;
        }
        return shifts;
    }

    private static byte[] GenerateTempKey(byte[] password)
    {
        byte[] temp = new byte[password.Length];
        for (int i = 0; i < password.Length; i++)
        {
            int index = Math.Abs(password[i] % password.Length);
            int newIndex = (i + index) % password.Length;
            temp[i] = password[newIndex];
            temp[i] = (byte)(temp[i] ^ password[i]);
        }
        return temp;
    }

    public static byte[] DecryptSaveFile(string filePath, bool isGameData = true)
    {
        byte[] encrypted = File.ReadAllBytes(filePath);
        string password = isGameData ? GAME_PASSWORD : ACHIEVEMENTS_PASSWORD;
        return Decrypt(encrypted, password);
    }
}

class Program
{
    static void Main()
    {
        byte[] encrypted = File.ReadAllBytes("GameDataDemo.json");

        byte[] decrypted = SaveCrypto.Decrypt(encrypted, "uoiyiuh_+=-5216gh;lj??!/345");

        File.WriteAllBytes("GameDataDemo.json", decrypted);
    }
}