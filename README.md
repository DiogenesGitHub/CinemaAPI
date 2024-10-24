# CinemaAPI

Esta é uma aplicação RESTful desenvolvida em .NET Core 8 utilizando o padrão MVC em C#. O objetivo da aplicação é gerenciar informações sobre Filmes, Salas, Exibições e Sessões em um cinema.

## Estrutura do Banco de Dados

A aplicação utiliza um banco de dados SQL Server com as seguintes tabelas:

### Tabelas

1. **Filmes**
   ```sql
   CREATE TABLE [dbo].[Filmes](
       [Id] [int] IDENTITY(1,1) NOT NULL,
       [Titulo] [nvarchar](255) NOT NULL,
       [Genero] [nvarchar](100) NULL,
       [Duracao] [int] NULL,
       [AnoLancamento] [int] NULL,
       PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
   );
   ```
	
2. **Salas**
   ```sql
	CREATE TABLE [dbo].[Salas](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Nome] [nvarchar](100) NOT NULL,
		[Capacidade] [int] NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
	);
   ```
   
3. **Exibições**
   ```sql
	CREATE TABLE [dbo].[Exibicoes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[FilmeId] [int] NULL,
		[SalaId] [int] NULL,
		[DataExibicao] [datetime] NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY],
		FOREIGN KEY([FilmeId]) REFERENCES [dbo].[Filmes] ([Id]),
		FOREIGN KEY([SalaId]) REFERENCES [dbo].[Salas] ([Id])
	);
   );
   ```
   
4. **Sessões**
   ```sql
	CREATE TABLE [dbo].[Sessoes](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ExibicaoId] [int] NOT NULL,
		[DataHora] [datetime] NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY],
		FOREIGN KEY([ExibicaoId]) REFERENCES [dbo].[Exibicoes] ([Id])
	);
	```