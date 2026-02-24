
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Crypto.Confidentiality;

internal class Program
{
    private static byte[] key;
    private static byte[] iv;

    static void Main(string[] args)
    {
        byte[] cipher = SymmZender();
        Console.WriteLine(Encoding.UTF8.GetString(cipher));
        SymmOntvanger(cipher);

        RSA ontvanger = RSA.Create();
        string pubKey = ontvanger.ToXmlString(false);

        cipher = AsymmZender(pubKey);
        Console.WriteLine(Encoding.UTF8.GetString(cipher));

        AsymmOntvanger(cipher, ontvanger);

    }

    private static void AsymmOntvanger(byte[] cipher, RSA ontvanger)
    {
        byte[] data = ontvanger.Decrypt(cipher, RSAEncryptionPadding.Pkcs1);
        Console.WriteLine(Encoding.UTF8.GetString(data));
    }

    private static byte[] AsymmZender(string publicKey)
    {
        string document = "Hello World";
        RSA rsa = RSA.Create();
        rsa.FromXmlString(publicKey);
        return rsa.Encrypt(Encoding.UTF8.GetBytes(document), RSAEncryptionPadding.Pkcs1);

    }

    private static void SymmOntvanger(byte[] cipher)
    {
        Aes alg = Aes.Create();
        alg.Key = key;
        //alg.Mode = CipherMode.ECB;
        alg.IV = iv;

        using (MemoryStream ms = new MemoryStream(cipher))
        using (CryptoStream crypto = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Read))
        using (StreamReader sr = new StreamReader(crypto))
        {
            string orig = sr.ReadToEnd();
            Console.WriteLine(orig);
        }

    }

    private static byte[] SymmZender()
    {
        string document = "Hello World";
        Aes alg = Aes.Create();
        key = alg.Key;
        //alg.Mode = CipherMode.ECB;
        iv = alg.IV;


        using (MemoryStream ms = new MemoryStream()) 
        {
            using (CryptoStream crypt = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using (StreamWriter sw = new StreamWriter(crypt))
                {
                    sw.WriteLine(document);
                }
            }
            return ms.ToArray();
        }
    }
}
