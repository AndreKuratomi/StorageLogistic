# StorageLogistic

- [Translations](#translations)
- [About](#about)
- [Installation](#installation)
- [References](#references)
- [Terms of use](#terms-of-use)

<br>

## Translations

- [Português brasileiro / Brazilian portuguese](https://github.com/AndreKuratomi/StorageLogistic)
- [English](./README_en-uk.md)

<br>

## About

<p>The application <b>StorageLogistic</b> is purposed to be a simple products storage base, with products register, manipulation and creation of PDF reports. This application uses the <b>MVC</b> pattern.

This application uses the language <strong>[C#](https://dotnet.microsoft.com/pt-br/download/)</strong>, its framework <strong>[dotnet](https://dotnet.microsoft.com/pt-br/download/)</strong> and the database <strong>[SQLite3](https://docs.python.org/3/library/sqlite3.html)</strong>.</p>

<br>

## Installation:

<h3>0. It is first necessary to have instaled the following devices:</h3>

- The code versioning <b>[Git](https://git-scm.com/downloads)</b>.

- A <b>code editor</b>, also known as <b>IDE</b>, <strong>[Visual Studio Code (VSCode)](https://code.visualstudio.com/)</strong>.

- The programming language <strong>[C#](https://dotnet.microsoft.com/pt-br/download/)</strong>.

<br>

<h3>1. Clone the repository <b>StorageLogistic</b> by your machine terminal or by the IDE's:</h3>

```
git clone https://github.com/AndreKuratomi/StorageLogistic.git
```

WINDOWS:

Obs: In case of any error message similar to this one: 

```
unable to access 'https://github.com/AndreKuratomi/StorageLogistic.git/': SSL certificate problem: self-signed certificate in certificate chain
```

Configure git to disable SSL certification:

```
git config --global http.sslVerify "false"
```

<p>Enter the directory:</p>

```
cd StorageLogistic
```
<br>

<h3>2. Open the aplication with your IDE:</h3>

```
code .
```
<br>

<h4>Install its dependencies:</h4>

```
dotnet restore
```

<h3>3. And run the application:</h3>

```
dotnet watch run
```

<br>

## References

- [C#](https://dotnet.microsoft.com/pt-br/download/)
- [Git](https://git-scm.com/downloads)
- [SQLite3](https://docs.python.org/3/library/sqlite3.html)
- [Visual Studio Code (VSCode)](https://code.visualstudio.com/)

<br>

## Terms of use

This project is exclusively for didatic purposes and has no commercial intent.
