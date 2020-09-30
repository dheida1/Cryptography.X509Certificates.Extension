## Nuget Installation 

[Link to Nuget page](https://www.nuget.org/packages/Cryptography.X509Certificates.Extension/)
```cs

PM> Install-Package Cryptography.X509Certificates.Extension

```


# To Use:

#### To only retrieve a valid matching certificate from the certificate store:

```
X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2(
                "1E0001122AA33324CFE608FC2200000001122A",
                StoreName.My,
                StoreLocation.LocalMachine,
                X509FindType.FindBySerialNumber);
```

#### To only retrieve ANY (does not have to be valid one) matching certificate from the certificate store:


```
X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2(
                "1E0001122AA33324CFE608FC2200000001122A",
                StoreName.My,
                StoreLocation.LocalMachine,
                X509FindType.FindBySerialNumber,
                false);
```

#### To only retrieve a valid matching certificate from the certificate store that does not have a private key:


```
X509Certificate2 cert = new Cryptography.X509Certificates.Extension.X509Certificate2(
                "1E0001122AA33324CFE608FC2200000001122A",
                StoreName.My,
                StoreLocation.LocalMachine,
                X509FindType.FindBySerialNumber,
                true, 
                true);
```

