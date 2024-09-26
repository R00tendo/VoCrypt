# VoCrypt
[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white)](https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white)
[![Windows](https://img.shields.io/badge/Windows-0078D6?style=flat&logo=windows&logoColor=white)](https://img.shields.io/badge/Windows-0078D6?style=flat&logo=windows&logoColor=white)
[![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=flat&logo=csharp&logoColor=white)](https://img.shields.io/badge/c%23-%23239120.svg?style=flat&logo=csharp&logoColor=white)

Software level Cryptographic Erase (CE) program and API written in C# to instantly wipe **semi** securely terabytes worth of data. Encryption standard: AES-256.

## Installation / Usage
Download the exe(s) from the releases tab.

## How it works?
VoCrypt encrypts the selected file using a very long key that is appended to the beginning of the .VoCr file. When you want to destroy the file, VoCrypt just overwrites the key.

## How secure is it?
I wasn't able to recover it using any software, but due to how HDDs and flash memory works, it's **most likely possible to recover the original key in a lab**, so use a strong password or consider using Luks (and luks header erase for destruction) if your threat model includes your devices getting analysed in a lab.

## Screenshots
<img src="https://github.com/user-attachments/assets/afe1e198-2270-4a34-8cb3-11fe9181289a" width=400>
