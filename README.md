# Crypto Service CSharp 

## Description
This is a small common crypto library to encrypt/decrypt secret data. You can decrypt data that's encrypted through [ Crypto Service Go ](https://github.com/itera-io/crypto-service-go) and vice versa

## Installation
Use [nuget](https://www.nuget.org/packages/CryptoServiceCSharp/) to install each version of CryptoServiceCSharp

## Usage
After installation you can register `services.AddTransient(ICryptoService, CryptoService)` in DI container and inject the interface wherever you want
