create database BDNotas
go

use BDNotas
go

create table Pessoa
(
	Id		int				primary key		identity,
	Nome	varchar(60)		not null,
	Email	varchar(100)	not null		unique,
	Senha	varchar(20)		not null
)

insert into Pessoa values ('Fulano', 'fulano@gmail.com', '123456')
insert into Pessoa values ('Ciclano', 'ciclano@hotmail.com', '132456')
insert into Pessoa values ('Beltrano', 'ciclano@outlook.com', '123456')

create table Professor
(
	Id		int				primary key,
	Titulo	varchar(20)		not null,
	foreign key (Id) references Pessoa (Id)
)

insert into Professor values (1, 'Mestre')

create table Aluno
(
	Id			int				primary key,
	Matricula	varchar(20)		not null,
	foreign key (Id) references Pessoa (Id)
)

insert into Aluno values (2, '0001')
insert into Aluno values (3, '0002')

create table Disciplina
(
	Id			int				primary key		identity,
	IdProfessor	int				not null		references Professor (Id),
	Nome		varchar(60)		not null
)

insert into Disciplina values (1, 'Programação Orientada a Objetos')

create table Nota
(
	IdDisciplina	int				not null	references Disciplina(Id),
	IdAluno			int				not null	references Aluno(Id),
	Nota			numeric(4,2)	not null,
	primary key (IdDisciplina, IdAluno)
)

insert into Nota values (1, 2, 5)
insert into Nota values (1, 3, 6)