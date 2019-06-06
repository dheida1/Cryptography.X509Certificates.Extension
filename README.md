# To Use:

#### To only retriveve a valid matching certificate from the certificate store:

```
X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2(
                "1E0001122AA33324CFE608FC2200000001122A",
                StoreName.My,
                StoreLocation.LocalMachine,
                X509FindType.FindBySerialNumber);
```

#### To only retriveve ANY (does not have to be valid one) matching certificate from the certificate store:


```
X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2(
                "1E0001122AA33324CFE608FC2200000001122A",
                StoreName.My,
                StoreLocation.LocalMachine,
                X509FindType.FindBySerialNumber,
                false);
```

