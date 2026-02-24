
using System;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Crypto.Hash;

internal class Program
{
    static void Main(string[] args)
    {
        (string Document, byte[] Hash) tuple = CreateMessage();
        Console.WriteLine(Convert.ToBase64String(tuple.Hash));
        tuple.Document += ".";
        Ontvanger(tuple);

        tuple = Zender();
        Console.WriteLine(Convert.ToBase64String(tuple.Hash));
        Receiver(tuple);

        (string Document, byte[] Signature, string PubKey) pakketje = Sender();
        Thuis(pakketje);
    }

    private static void Thuis((string Document, byte[] Signature, string PubKey) pakketje)
    {
        DSA alg = DSA.Create();
        alg.FromXmlString(pakketje.PubKey);
        SHA1 sha1 = SHA1.Create();
        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pakketje.Document));
        bool isOk = alg.VerifySignature(hash, pakketje.Signature);
        Console.WriteLine(isOk? "Origineel": "Gerommel");
    }

    private static (string Document, byte[] Signature, string PubKey) Sender()
    {
        string document = "Hello World";
        DSA alg = DSA.Create();
        string pubpriv = alg.ToXmlString(true);
        string pub = alg.ToXmlString(false);
        Console.WriteLine(pub);

        SHA1 sha1 = SHA1.Create();
        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(document));
        byte[] signature = alg.CreateSignature(hash);

        return (document, signature, pub);
    }

    private static void Receiver((string Document, byte[] Hash) tuple)
    {
        HMACSHA256 alg = new HMACSHA256();
        alg.Key = Encoding.UTF8.GetBytes("MySecret");
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(tuple.Document)); 
        Console.WriteLine(Convert.ToBase64String(hash));

    }

    private static (string Document, byte[] Hash) Zender()
    {
        string document = "Hello World";
        HMACSHA256 alg = new HMACSHA256();
        alg.Key = Encoding.UTF8.GetBytes("MySecret");
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(document));
        return (document, hash);

    }

    private static void Ontvanger((string Document, byte[] Hash) tuple)
    {
        SHA1 sha1 = SHA1.Create();
        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(tuple.Document));
        Console.WriteLine(Convert.ToBase64String(hash));

    }

    private static (string Document, byte[] Hash) CreateMessage()
    {
        string document = "Hello World";
        SHA1 sha1 = SHA1.Create();
        byte[] hash =sha1.ComputeHash(Encoding.UTF8.GetBytes(document));
        return (document, hash);
        
    }
}
