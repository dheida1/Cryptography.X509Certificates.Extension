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

Cryptography.X509Certificates.Extension.X509Certificate2 inherits from System.Security.Cryptography.X509Certificates.X509Certificate2 to create a new 
Cryptography.X509Certificates.Extension.X509Certificate2 type certificate.



#  To create an Nuget package via Nuget CLI: 

## Install nuget.exe CLI

- Install nuget.exe CLI at https://www.nuget.org/downloads
- Select NuGet 3.3 or higher (2.8.6 is not compatible with Mono). The latest version is always recommended, and 4.1.0+ is required to publish packages to nuget.org.
- Each download is the nuget.exe file directly. Instruct your browser to save the file to a folder of your choice. The file is not an installer; you won't see anything if you run it directly from the browser.
- Add the folder where you placed nuget.exe to your PATH environment variable to use the CLI tool from anywhere.

### Tip:
Use nuget update -self on Windows to update an existing nuget.exe to the latest version.

## Create a nuspec file:

run this code to create a *.nuspec file:

`nuget spec`

Here's an example of wht it would need to look like :

```<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
  <metadata>
    <id>ESBService</id>
    <version>1.0.9.0</version>
    <title>Enterprise Service Bus Service</title>
    <authors>Dina Heidar</authors>
    <owners>OTS</owners>
    <language>en-US</language>
    <projectUrl>https://git.la.gov/OTS/ESBService</projectUrl>
    <iconUrl>file:///C:/Users/dinah/source/repos/ESBService/ESBService/favicon.ico</iconUrl>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>This package facilitates communication between .Net Core applications and OTS Enterprise Architecture (EA) Enterprise Service Bus (ESB) component  </description>
    <releaseNotes>New updates and changes to package.</releaseNotes>
    <copyright>OTS Copyright 2019</copyright>    
    <dependencies>
      <group targetFramework=".NETStandard2.0">
        <dependency id="Microsoft.Extensions.DependencyInjection.Abstractions" version="2.2.0" exclude="Build,Analyzers" />
        <dependency id="Microsoft.IdentityModel.Tokens" version="5.3.0" exclude="Build,Analyzers" />
        <dependency id="System.Security.Cryptography.Xml" version="4.5.0" exclude="Build,Analyzers" />
      </group>
    </dependencies>    
  </metadata>
  <files>
    <file src="readme.txt" target="" />
    <file src="bin\Debug\netstandard2.0\*.dll" target="lib\netstandard2.0" />
  </files>
</package>
````

##### Make sure to include the assembly or it will NOT work. In this example it is: 

**`<file src="bin\Debug\netstandard2.0\*.dll" target="lib\netstandard2.0" />`**

Use the this command to pack your nuget project

`nuget pack [nameof your project].nuspec -OutputDirectory [your output directory]`
-OutputDirectory [your output directory] is optional

###### Example:

```
C:\Users\dinah\source\repos\ESBService\ESBService>nuget pack ESBService.nuspec -OutputDirectory ./nuget
Attempting to build package from 'ESBService.nuspec'.
Successfully created package './nuget\ESBService.1.0.9.nupkg'.
```


##### Deploy the package
Push your nuget package to OTS Nuget Server or whatever server you wan to push it to. You'll need identify the correct *.nupkg and the key:
```
C:\Users\dinah\source\repos\ESBService\ESBService>nuget push ./nuget/ESBService.1.0.9.nupkg DgeousPiNTIcTideStrIenTa -Source http://s-pmas-wwb01.swe.la.gov/nuget
Pushing ESBService.1.0.9.nupkg to 'http://s-pmas-wwb01.swe.la.gov/nuget'...
  PUT http://s-pmas-wwb01.swe.la.gov/nuget/
  Created http://s-pmas-wwb01.swe.la.gov/nuget/ 84ms
Your package was pushed.
```

##### Finally

Open a project=> Nuget package manager and browse to see if your package is available

![alt text](./Images/NugetPackageManager.png)