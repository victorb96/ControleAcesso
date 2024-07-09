CREATE DATABASE controle_acesso;

\c controle_acesso;

CREATE TABLE IF NOT EXISTS UsuarioPerfil (
    Id INTEGER PRIMARY KEY NOT NULL,
    Descricao VARCHAR(15)
);

CREATE TABLE IF NOT EXISTS Usuario (
    Id INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Nome VARCHAR(60) NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    Cep VARCHAR(8) NOT NULL,
    Logradouro VARCHAR(200) NOT NULL,
    Bairro VARCHAR(200) NOT NULL,
    Cidade VARCHAR(200) NOT NULL,
    UF VARCHAR(2) NOT NULL,
    Numero INTEGER NOT NULL,
    Complemento VARCHAR(200) NULL,
    IdUsuarioPerfil INTEGER NOT NULL,
    Email VARCHAR(200) NOT NULL,
    Senha VARCHAR(35),
    Celular VARCHAR(11),
    CONSTRAINT FK_UsuarioPerfil_Usuario FOREIGN KEY(IdUsuarioPerfil) REFERENCES Usuario(Id)
);

CREATE TABLE IF NOT EXISTS Funcionalidade (
    Id INTEGER PRIMARY KEY NOT NULL,
    Nome VARCHAR(60)
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

CREATE TABLE IF NOT EXISTS Menu (
    Id INTEGER PRIMARY KEY NOT NULL,
    Nome VARCHAR(60) NOT NULL,
    Icone VARCHAR(20) NULL,
    Rota VARCHAR(20) NULL,
    IdPai INTEGER NULL,
    IdFuncionalidade INTEGER NULL,
    CONSTRAINT FK_Funcionalidade_Menu FOREIGN KEY(IdFuncionalidade) REFERENCES Funcionalidade(Id)
);