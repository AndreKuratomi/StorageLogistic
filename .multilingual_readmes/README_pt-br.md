# StorageLogistic

- [Traduções](#traduções)
- [Sobre](#sobre)
- [Instalação](#instalação)
- [Referências](#referências)
- [Termos de uso](#termos-de-uso)

<br>

## Traduções

- [🇬🇧 / 🇺🇸 English / Inglês](https://github.com/AndreKuratomi/StorageLogistic)
- [🇧🇷 Português brasileiro / Brazilian portuguese](./README_pt-br.md)

<br>

## Sobre

<p>A aplicação <b>StorageLogistic</b> se propõe a ser um protótipo de controle de estoque de produtos, possibulitando cadastro, manipulação e geração de relatórios em PDF. Esta aplicação utiliza o padrão <b>MVC</b>.

Esta aplicação utiliza a linguagem <strong>[C#](https://dotnet.microsoft.com/pt-br/download/)</strong>, seu framework <strong>[dotnet](https://dotnet.microsoft.com/pt-br/download/)</strong> e o banco de dados <strong>[SQLite3](https://docs.python.org/3/library/sqlite3.html)</strong>.</p>

<br>

## Instalação


<h3>0. Primeiramente, é necessário já ter instalado na própria máquina:</h3>

- O versionador de codigo <b>[Git](https://git-scm.com/downloads)</b>.

- A linguagem de programação <b>[C#](https://dotnet.microsoft.com/pt-br/download/)</b>.

- O <b>editor de código</b>, conhecido também como <b>IDE</b>, <b>[Visual Studio Code (VSCode)](https://code.visualstudio.com/)</b>.

<br>

<h3>1. Fazer o clone do reposítório <b>StorageLogistic</b> na sua máquina pelo terminal do computador ou pelo do IDE:</h3>

```
git clone https://github.com/AndreKuratomi/StorageLogistic.git
```

WINDOWS:

Obs: Caso apareca algum erro semelhante a este: 

```
unable to access 'https://github.com/AndreKuratomi/StorageLogistic.git': SSL certificate problem: self-signed certificate in certificate chain
```

Configure o git para desabilitar a certificação SSL:

```
git config --global http.sslVerify "false"
```


<p>Entrar na pasta criada:</p>

```
cd StorageLogistic
```
<br>


<h3>2. Abrir a aplicação no IDE:</h3>

```
code .
```

<h4>Instalar suas dependências:</h4>

```
dotnet restore
```

<br>

<h3>3. E executar o projeto:</h3>

```
dotnet watch run
```

<br>

## Referências

- [C#](https://dotnet.microsoft.com/pt-br/download/)
- [Git](https://git-scm.com/downloads)
- [SQLite3](https://docs.python.org/3/library/sqlite3.html)
- [Visual Studio Code (VSCode)](https://code.visualstudio.com/)

<br>

## Termos de uso

Esse projeto atende a fins exclusivamente didáticos e sem nenhum intuito comercial.
