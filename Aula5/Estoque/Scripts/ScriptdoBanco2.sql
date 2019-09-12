Nome do Banco Estoque

CREATE TABLE [dbo].[CategoriaDoProduto]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Nome] NVARCHAR (MAX) NULL, 
    [Descricao] NVARCHAR(MAX) NULL,
	CONSTRAINT [PK_dbo.CategoriaDoProduto] PRIMARY KEY CLUSTERED ([Id] ASC)

);

GO;

CREATE TABLE [dbo].[Produtoes]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Nome] NVARCHAR (MAX) NULL, 
	[Preco] REAL NULL,
	[CategoriaId] INT NOT NULL,	
    [Descricao] NVARCHAR(MAX) NULL,
	[Quantidade] INT NULL,
	CONSTRAINT [PK_dbo.Produtoes] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.Produtos_dbo.CategoriaDoProduto_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[CategoriaDoProduto] ([Id])

);
GO
CREATE NONCLUSTERED INDEX [IX_CategoriaId]
ON [dbo].[Produtos]([CategoriaId] ASC);

GO;

CREATE TABLE [dbo].[Usuarioes]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Nome] NVARCHAR (MAX) NULL, 
    [Senha] NVARCHAR(MAX) NULL,
	CONSTRAINT [PK_dbo.Usuarioes] PRIMARY KEY CLUSTERED ([Id] ASC)

);

INSERT INTO dbo.CategoriaDoProduto
(
    Nome,
    Descricao
)
VALUES
(  'Eletrodomesticos', -- Nome - nvarchar(max)
    'Tudo para sua cozinha'  -- Descricao - nvarchar(max)
    )

	INSERT INTO dbo.Produtoes
	(
	    Nome,
	    Preco,
	    CategoriaId,
	    Descricao,
	    Quantidade
	)
	VALUES
	(   'Fritadeira Elétrica', -- Nome - nvarchar(max)
	    200.0, -- Preco - real
	    1,   -- CategoriaId - int
	    'Frita tudo sem óleo', -- Descricao - nvarchar(max)
	    20    -- Quantidade - int
	    )
	INSERT INTO dbo.Usuarioes
	(
	    Nome,
	    Senha
	)
	VALUES
	(   'Admin', -- Nome - nvarchar(max)
	    '123'  -- Senha - nvarchar(max)
	    )