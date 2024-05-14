# Cadastro de Livro (Book)

A API foi desenvolvida para realiza��o de cadastro de novos livros, contendo t�tulo, autor, ano de publica��o e g�nero, permitindo assim que seja sempre realizada a atualiza��o e dele��o dessas iforma��es. 
 
# Tecnologias Utilizadas

- .NET 8.0
- SQL Server LocalDB
- Entity Framework

# Requisitos

- [SDK do .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)


## Configuração do Banco de Dados

1. Abra o Visual Studio Code ou sua IDE preferida.
2. Abra o arquivo `appsettings.json` na pasta raiz do projeto e configure a string de conexão com o SQL Server LocalDB de acordo com suas preferências:

```json
"ConnectionStrings": {
   "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TechChallenge;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server             
   Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
}
```

### Executando as Migrações do Banco de Dados
Para criar ou atualizar o banco de dados, você precisa executar as migrações. Siga as etapas abaixo:

1 - Abra o Visual Studio.

2 - Abra o Console do Gerenciador de Pacotes do NuGet no Visual Studio. Você pode fazer isso indo em "Ferramentas" -> "Gerenciador de Pacotes do NuGet" -> "Console do Gerenciador de Pacotes".

3- Para aplicar a última verssãop da migração ao banco de dados utilize o seguinte comando:

```
Update-Database
```

# Executando a API
Abra um terminal na pasta TechChallenge4.Api do projeto. Execute o seguinte comando para iniciar a API:

```
dotnet run
```

A API estará disponível em http://localhost:5177/swagger/index.html. Você pode acessar os endpoints da API para realizar o gerenciamento das informações dos livros.

