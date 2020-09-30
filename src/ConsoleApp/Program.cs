using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2
                (
                "78f8cfe93a00f2f2d0e54cd94883cbff92dbb401",
                StoreName.Root,
                StoreLocation.LocalMachine,
                X509FindType.FindByThumbprint,
                true,
                false
                );

            Console.WriteLine(cert.GetPublicKeyString());
        }
    }
}
