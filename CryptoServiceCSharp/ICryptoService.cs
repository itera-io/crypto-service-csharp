namespace CryptoServiceCSharp;

public interface ICryptoService
{
    string Encrypt(string plainText, string passPhrase);
    string Decrypt(string cypherText, string passPhrase);
}
