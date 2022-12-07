# Crypto Service CSharp 

This is a small common crypto library to encrypt/decrypt secret data. You can decrypt data that's encrypted through [ Crypto Service Go ](https://github.com/itera-io/crypto-service-go) and vice versa

## Installation
Use NuGet 
```
Install-Package CryptoServiceCSharp
```

[Link](https://www.nuget.org/packages/CryptoServiceCSharp/) to install each version of CryptoServiceCSharp

## Usage
After installation, you can register
 ```
services.AddTransient(ICryptoService, CryptoService)
``` 
in the DI container and inject the interface wherever you want.\
Make sure that you've specified `crypto-key` as either an environment variable or a secret key. Example:
```
var encryptedData = _cryptoService.Encrypt(data, cryptoKey);
// var data = _cryptoService.Decrypt(encryptedData, cryptoKey);
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.
