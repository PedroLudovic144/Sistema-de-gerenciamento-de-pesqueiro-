IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Pesqueiros] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Pesqueiros] PRIMARY KEY ([Id])
);

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Quantidade] int NOT NULL,
    [Valor] float NOT NULL,
    [Fornecedor] nvarchar(max) NOT NULL,
    [PesqueiroId] int NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Pesqueiros_PesqueiroId] FOREIGN KEY ([PesqueiroId]) REFERENCES [Pesqueiros] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Produtos_PesqueiroId] ON [Produtos] ([PesqueiroId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250620192641_InitialCreate', N'9.0.6');

COMMIT;
GO

