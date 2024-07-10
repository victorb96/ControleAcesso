\c controle_acesso;

INSERT INTO Perfil (Id, Descricao)
    VALUES(1, 'Administrador'),
        (2, 'Operador'),
        (3, 'Técnico')
    ON CONFLICT (Id) DO NOTHING;

INSERT INTO Usuario (DataCadastro,
        Ativo,
        Nome, 
        Cpf, 
        Cep, 
        Logradouro, 
        Bairro, 
        Cidade, 
        UF, 
        Numero, 
        Complemento, 
        IdPerfil,
        Email,
        Senha,
        Celular)
    VALUES(NOW(),
        TRUE,
        'admin', 
        '00000000000', 
        '00000000', 
        'Rua x', 
        'Bairro y', 
        'São Paulo', 
        'SP', 
        111, 
        '', 
        1,
        'admin@email.com',
        'admin',
        '11900000000');

INSERT INTO Funcionalidade (Id, Nome)
    VALUES(1, 'Usuário'),
        (2, 'Produto'),
        (3, 'Serviço')
    ON CONFLICT (Id) DO NOTHING;

INSERT INTO Acao (Id, Nome)
    VALUES(1, 'Consultar'),
        (2, 'Cadastrar'),
        (3, 'Alterar'),
        (4, 'Deletar')
    ON CONFLICT (Id) DO NOTHING;

INSERT INTO UsuarioFuncionalidadeAcao (IdUsuario, IdFuncionalidade, IdAcao)
    VALUES(1, 1, 1),
        (1, 1, 2),
        (1, 1, 3),
        (1, 1, 4),
        (1, 2, 1),
        (1, 2, 2),
        (1, 2, 3),
        (1, 2, 4),
        (1, 3, 1),
        (1, 3, 2),
        (1, 3, 3),
        (1, 3, 4)
    ON CONFLICT(IdUsuario, IdFuncionalidade, IdAcao) DO NOTHING;

INSERT INTO Menu (Id, Nome, Icone, Rota, IdPai, IdFuncionalidade)
    VALUES(1000, 'Cadastro', null, null, null, null),
        (1005, 'Usuário', null, '/usuario', 1000, 1),
        (1010, 'Produto', null, '/produto', 1000, 2),
        (1015, 'Serviço', null, '/servico', 1000, 3)
    ON CONFLICT (Id) DO NOTHING;