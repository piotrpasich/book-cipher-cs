# Book cipher - Book crypto encoder and decoder in c#

![Checkers](/docs/example.jpg)

## Usage

### -e Encryption 

Encryption of a file with a default book included into the code can be done with -e parameter or without any parameters

```
TextEncryptor.exe "Ala ma kota"
```

```
TextEncryptor.exe -e Ala ma kota
```

Should return: 
```
Loaded Book File: C:\Users\papi\source\repos\TextEncryptor\TextEncryptor\bin\Debug\Resources\Books\book.pdf
Text to encode: Ala ma kota
Encoded text: 226:118,187:184,187:25,187:64,187:97,35:25,35:42,35:70,35:59,35:62,120:25
```

### -d Decryption

Decryption of encoded a text with a default book included into the code can be executed with `-d` or `--decrypt` parameter

```
TextEncryptor.exe -d 226:118,187:184,187:25,187:64,187:97,35:25,35:42,35:70,35:59,35:62,120:25
```

Result: 

```
Loaded Book File: C:\Users\papi\source\repos\TextEncryptor\TextEncryptor\bin\Debug\Resources\Books\book.pdf
Text to decode: 226:118,187:184,187:25,187:64,187:97,35:25,35:42,35:70,35:59,35:62,120:25
Decoded text: Ala ma kota
```

### -b Usage of different book file

Options `-b` and `--book=` overload a PDF book file:

```
TextEncryptor.exe -b C:\Users\papi\Downloads\ppp.pdf Ala ma kota
```

```
TextEncryptor.exe -book=C:\Users\papi\Downloads\ppp.pdf Ala ma kota
```

Result: 

```
Loaded Book File: C:\Users\papi\Downloads\ppp.pdf
Text to encode: Ala ma kota
Encoded text: 11:203,7:47,7:7,5:7,5:4,5:5,5:7,5:11,5:10,5:6,5:5
```

### -b -d Decoding with external PDF file

```
TextEncryptor.exe -d -book=C:\Users\papi\Downloads\ppp.pdf 11:203,7:47,7:7,5:7,5:4,5:5,5:7,5:11,5:10,5:6,5:5
```

Result: 

```
Loaded Book File: C:\Users\papi\Downloads\ppp.pdf
Text to decode: 11:203,7:47,7:7,5:7,5:4,5:5,5:7,5:11,5:10,5:6,5:5
Decoded text: Ala ma kota
```

### -t Text

Text to encode or encode it loaded from a set of extra options like in previous examples, but can be also loaded from the `-t` or `--text=` parameter: 

```
TextEncryptor.exe  --text="overriten"
```

```
TextEncryptor.exe  -t "overriten"
```