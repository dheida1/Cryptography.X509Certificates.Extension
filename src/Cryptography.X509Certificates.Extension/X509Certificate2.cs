﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace Cryptography.X509Certificates.Extension
{
    public class X509Certificate2 : System.Security.Cryptography.X509Certificates.X509Certificate2
    {
        /// <summary>
        /// Extension to search for X509Certificate in certifcate store.
        /// Ideal to use when in production mode on servers.
        /// </summary>
        /// <param name="value">The value of the certifcate FindType</param>
        /// <param name="storeName">The certificate store name</param>
        /// <param name="storeLocation">The certificate store name. Usually 'LocalMachine' or 'CurrentUser'</param>
        /// <param name="x509FindType">The value type. This could be the serial number, thumprint,..etc</param>
        /// <param name="validOnly"> indicates to only search for valid certificates. The default is se to 'true'</param>
        /// <returns>
        /// The certificate.
        /// </returns>
        /// <example>
        /// <code>
        /// X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2(
        ///                 "1E0001122AA33324CFE608FC2200000001122A",
        ///                 StoreName.My,
        ///                 StoreLocation.LocalMachine,
        ///                 X509FindType.FindBySerialNumber);
        /// </code>
        /// </example>
        public X509Certificate2(
           string value,
           StoreName storeName,
           StoreLocation storeLocation,
           X509FindType x509FindType,
           bool validOnly = true
           ) : base(GetCert(
                value,
                storeName,
                storeLocation,
                x509FindType,
                validOnly))
        { }

        private static System.Security.Cryptography.X509Certificates.X509Certificate2 GetCert(
            string value,
            StoreName storeName,
            StoreLocation storeLocation,
            X509FindType x509FindType,
            bool validOnly
            )
        {
            using (var store = new X509Store(storeName, storeLocation))
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection collection = store.Certificates.Find(x509FindType, value, validOnly);
                store.Close();
                if (collection.Count == 0)
                {
                    throw new InvalidOperationException("Service Provider certificate could not be found.");
                }
                if (collection.Count > 1)
                {
                    throw new InvalidOperationException("Multiple Service Provider certificates were found, must only provide one.");
                }
                System.Security.Cryptography.X509Certificates.X509Certificate2 x509Certificate2 = collection[0];

                if (x509Certificate2.PrivateKey == null)
                {
                    throw new InvalidOperationException("The certificate for this service providerhas no private key.");
                }
                return new System.Security.Cryptography.X509Certificates.X509Certificate2(x509Certificate2);
            }
        }
    }
}