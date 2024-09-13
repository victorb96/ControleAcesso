CREATE DATABASE controle_acesso;

\c controle_acesso;

CREATE TABLE IF NOT EXISTS Perfil (
    Id INTEGER PRIMARY KEY NOT NULL,
    Descricao VARCHAR(15)
);

CREATE TABLE IF NOT EXISTS Usuario (
    Id INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    DataCadastro TIMESTAMP NOT NULL,
    DataAlteracao TIMESTAMP NULL,
    DataExclusao TIMESTAMP NULL,
    Ativo BOOLEAN NOT NULL DEFAULT FALSE,
    Nome VARCHAR(60) NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    Cep VARCHAR(8) NOT NULL,
    Logradouro VARCHAR(200) NOT NULL,
    Bairro VARCHAR(200) NOT NULL,
    Cidade VARCHAR(200) NOT NULL,
    UF VARCHAR(2) NOT NULL,
    Numero INTEGER NOT NULL,
    Complemento VARCHAR(200) NULL,
    IdPerfil INTEGER NOT NULL,
    Email VARCHAR(200) NOT NULL,
    Senha VARCHAR(35),
    Celular VARCHAR(11),
    CONSTRAINT FK_Perfil_Usuario FOREIGN KEY(IdPerfil) REFERENCES Perfil(Id)
);

CREATE TABLE IF NOT EXISTS Menu (
    Id INTEGER PRIMARY KEY NOT NULL,
    Nome VARCHAR(60) NOT NULL,
    Icone VARCHAR(20) NULL,
    Rota VARCHAR(20) NULL,
    IdPai INTEGER NULL
);

CREATE TABLE IF NOT EXISTS Funcionalidade (
    Id INTEGER PRIMARY KEY NOT NULL,
    Nome VARCHAR(60),
    IdMenu INT NULL,
    CONSTRAINT FK_Menu_Funcionalidade FOREIGN KEY(IdMenu) REFERENCES Menu(Id)
);

CREATE TABLE IF NOT EXISTS Acao (
    Id INTEGER PRIMARY KEY NOT NULL,
    Nome VARCHAR(12)
);

CREATE TABLE IF NOT EXISTS UsuarioFuncionalidadeAcao (
    Id INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    IdUsuario INTEGER,
    IdFuncionalidade INTEGER,
    IdAcao INTEGER,
    CONSTRAINT FK_Usuario_UsuarioFuncionalidadeAcao FOREIGN KEY(IdUsuario) REFERENCES Usuario(Id),
    CONSTRAINT FK_Funcionalidade_UsuarioFuncionalidadeAcao FOREIGN KEY(IdFuncionalidade) REFERENCES Funcionalidade(Id),
    CONSTRAINT FK_Acao_UsuarioFuncionalidadeAcao FOREIGN KEY(IdAcao) REFERENCES Acao(Id)
);

CREATE UNIQUE INDEX IDX_UsuarioFuncionalidadeAcao
ON UsuarioFuncionalidadeAcao(IdUsuario, IdFuncionalidade, IdAcao);

CREATE UNIQUE INDEX IDX_Usuario
ON Usuario(Email);