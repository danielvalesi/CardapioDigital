create database cardapioDigital
GO

use cardapioDigital
GO

CREATE TABLE Pessoas
(
	id		int				not null primary key identity,
	nome	varchar(50)		not null,
	email	varchar(100)	not null,
	senha	varchar(32)		not null,
	cpf		varchar(16)		not null
)
GO

CREATE TABLE ClientesVIP
(
	--id						int				not null identity,
	pessoa_id				int				not null ,
	porcentagemDesconto		decimal(4,2)	not null
	primary key(pessoa_id),
	foreign key(pessoa_id)	references Pessoas(id)
)
GO

CREATE TABLE Funcionarios
(
	pessoa_id		int				not null primary key,
	cargo			varchar(24)		not null,
	salario			decimal(10,2)	not null,
	horarioEntrada	datetime			null,
	horarioSaida	datetime			null
		
	foreign key(pessoa_id)	references Pessoas(id)
)
GO

CREATE TABLE Produtos
(
	id				int				not null primary key identity,
	nome			varchar(100)	not null,
	preco			decimal(10,2)	not null,
	descricao		varchar(max)		null,
	categoria		int				not null,
	imagem			varchar(max)		null,
	tempoPreparo	int					null,
	estoque			int					null
)
GO

CREATE TABLE Localizacoes
(
	numero		int			not null primary key identity,
	qtdLugares	int				null,
	descricao	varchar(max)	null,
	status		int			not null
)
GO


CREATE TABLE Contas
(
	id				int			not null identity,
	localizacao_id	int			not null,
	cliente_id		int				null,
	dataAbertura	datetime	not null,
	dataFechamento	datetime		null,
	status			int			not null,
	valor			decimal(15,2)	null,
	formaPagamento	int			not null

	PRIMARY KEY(id),
	foreign key(localizacao_id) references Localizacoes(numero),
	foreign key(cliente_id) references ClientesVIP(pessoa_id)
	
)
GO

CREATE TABLE Pedidos
(
	id			int				not null primary key identity,
	conta_id	int				not null,
	status		int				not null,
	dataEntrega datetime			null
	foreign key(conta_id) references Contas(id)
)

CREATE TABLE Itens
(
	produto_id			int				not null,
	funcionario_id		int				not	null,
	pedido_id			int				not null,
	qtd					int				not null,
	preco				decimal(10,2)	not null,
	dataEntrega			datetime			null,
	status				int				not null
	PRIMARY KEY(produto_id, pedido_id, funcionario_id),
	FOREIGN KEY(produto_id) references Produtos(id),
	FOREIGN KEY(funcionario_id) references Funcionarios(pessoa_id),
	FOREIGN KEY(pedido_id) references Contas(id)
)
GO

INSERT INTO Localizacoes VALUES(4, 'mesa do fundo', 2)
INSERT INTO Localizacoes VALUES(3, 'mesa do inicio', 1)
go


INSERT INTO Pessoas	VALUES('DIOGO', 'DIOGO@GMAIL.COM', '654321', '321.321.321-21')
INSERT INTO Funcionarios VALUES(@@IDENTITY, 'GARÇOM', 350.00, GETDATE(), NULL)
go

INSERT INTO Pessoas	VALUES('DANIEL LEITE', 'DANIEL@GMAIL.COM', '123456', '123.123.123-12')
INSERT INTO ClientesVIP VALUES(@@IDENTITY, 0.2)
go

INSERT INTO Pessoas	VALUES('GUSTAVO', 'GUSTAVO@GMAIL.COM', '123456', '123.132.123-12')
INSERT INTO ClientesVIP VALUES(@@IDENTITY, 0.4)
go

INSERT INTO Contas VALUES(1, 2, getdate(), null, 0, null, 0)
go
INSERT INTO Produtos VALUES ('coca-cola', 4.50, 'refrigerante sabor cola da marca coca cola', 0, null, 0, 10)
INSERT INTO Produtos VALUES ('cheddar com cheddar cheddar', 25.50, 'o sanduba mais gostoso do rolê', 1, null, 30, null)
go

INSERT INTO Pedidos(conta_id, status, dataEntrega) VALUES(1, 0, GETDATE())
INSERT INTO Pedidos(conta_id, status, dataEntrega) VALUES(1, 1, GETDATE())
INSERT INTO Itens VALUES(2, 1, 1, 4, 120, getdate(), 1)






/*
create procedure cadcliente
(
	@nome					varchar(50),
	@email					varchar(100),
	@senha					varchar(32),
	@cpf					varchar(16),
	@porcentagemDesconto	decimal(4,2)	
)
as
begin
	INSERT INTO Pessoas	VALUES(@nome, @email, @senha, @cpf)
	INSERT INTO ClientesVIP VALUES(@@IDENTITY, @porcentagemDesconto)
end


go
create procedure cadfuncionario
(
	@nome					varchar(50),
	@email					varchar(100),
	@senha					varchar(32),
	@cpf					varchar(16),
	@cargo					varchar(24),
	@salario				decimal(10,2),
	@horarioEntrada			datetime,
	@horarioSaida			datetime	
)
as
begin
	INSERT INTO Pessoas	VALUES(@nome, @email, @senha, @cpf)
	INSERT INTO ClientesVIP VALUES(@@IDENTITY, @cargo, @salario, @horarioEntrada, @horarioSaida)
end 


-- cadastrar Localizações	INSERT INTO Localizacoes	VALUES (@qtdLugares, @descricao, @status)
-- cadastrar Produtos		INSERT INTO Produtos		VALUES (@nome, @preco, @descricao, @categoria, @imagem, @tempoPreparo @estoque)
-- cadastrar Contas			INSERT INTO 
select * from Produto

CREATE PROCEDURE abreConta
(
	@localizacao_id		int,
	@cliente_id			int,
	@dataAbertura		datetime,
	@dataFechamento		datetime,
	@status				int,
	@valor				decimal(15,2),
	@formaPagamento		int
)
as
begin
	INSERT INTO Contas VALUES(@localizacao_id, @cliente_id, @dataAbertura, @dataFechamento, @status, @valor, @formaPagamento)
end
*/





















/*insert into Pessoas(nome, email, senha, cpf) 
values ('Xablau', 'xablau@xablau.com', '654321', '123.123.123-12')

insert into Clientes(pessoa_id, porcentagemDesconto)
values ( 1, 0.1)   

select	p.id ID,
		p.nome Nome,
		p.senha Senha,
		p.cpf CPF,
			c.porcentagemDesconto Desconto
from Pessoas p, Clientes c
where p.id = c.pessoa_id
go
create procedure cadcliente
(
	@nome					varchar(50),
	@email					varchar(100),
	@senha					varchar(32),
	@cpf					varchar(16),
	@porcentagemDesconto	decimal(4,2)	
)
as
begin
	INSERT INTO Pessoas	VALUES(@nome, @email, @senha, @cpf)
	INSERT INTO Clientes VALUES(@@IDENTITY, @porcentagemDesconto)
end
exec cadcliente 'toblito', 'toblito@gmail.com', 'senha', '321.321.321-21', 0.05

go
create procedure cadfuncionario
(
	@nome					varchar(50),
	@email					varchar(100),
	@senha					varchar(32),
	@cpf					varchar(16),
	@cargo					varchar(24),
	@horarioEntrada			datetime,
	@horarioSaida			datetime
)
as
begin
	INSERT INTO Pessoas	VALUES(@nome, @email, @senha, @cpf)
	INSERT INTO Funcionarios VALUES(@@IDENTITY, @cargo, @horarioEntrada, @horarioSaida)
end

exec cadfuncionario 'Jack deniels', 'jackdeniels@gmail.com', 'senha', '321.321.311-21', 'garçom', null, null

select *
from Funcionarios f, Pessoas p
where p.id = f.pessoa_id
*/