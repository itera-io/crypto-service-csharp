using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CryptoServiceCSharp;

public class CryptoService : ICryptoService
{
    // This constant is used to determine the keysize of the encryption algorithm in bits.
    private const int Keysize = 256;


    public string Encrypt(string plainText, string passPhrase)
    {
        var key = Encoding.UTF8.GetBytes(passPhrase);
        var iv = RandomNumberGenerator.GetBytes(Keysize / 16);
        using var aes = Aes.Create("AesManaged");
        aes.KeySize = Keysize;
        aes.Mode = CipherMode.CBC;
        aes.Key = key;
        aes.IV = iv;
        using var transform = aes.CreateEncryptor();
        var toEncodeByte = Encoding.UTF8.GetBytes(plainText);
        var encrypted = transform.TransformFinalBlock(toEncodeByte, 0, toEncodeByte.Length);
        var hexEncrypted = BitConverter.ToString(iv).Replace("-", "") + BitConverter.ToString(encrypted).Replace("-", "");
        return hexEncrypted;

    }

    public string Decrypt(string cypherText, string passPhrase)
    {
        var key = Encoding.UTF8.GetBytes(passPhrase);
        var iv = StringToByteArray(cypherText[..(Keysize / 8)]);
        cypherText = cypherText[(Keysize / 8)..];

        using var aes = Aes.Create("AesManaged");
        aes.KeySize = Keysize;
        aes.Mode = CipherMode.CBC;
        aes.Key = key;
        aes.IV = iv;
        using var decryptor = aes.CreateDecryptor();
        var hex = StringToByteArray(cypherText);

        using MemoryStream memoryStream = new(hex);
        using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new(cryptoStream);
        var decrypted = streamReader.ReadToEnd();

        return decrypted;
    }

    private static byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
    }
}
