CREATE DATABASE Lemuria
GO

USE Lemuria
GO

CREATE TABLE Plano 
(
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Preco DECIMAL(10,2) NOT NULL,
	Armazenamento INT NOT NULL,
	Subdominios INT NOT NULL,
	Emails INT NOT NULL,
	Recomendado BIT DEFAULT 0
)
GO

SELECT * FROM Plano


CREATE TABLE Assinatura(
	Id int IDENTITY PRIMARY KEY NOT NULL,
	IdPlano int NOT NULL FOREIGN KEY REFERENCES Plano(Id) ,
	Cliente varchar(50) NOT NULL,
	Cpf varchar(15) NOT NULL,
	Email varchar(50) NOT NULL,
	Telefone varchar(20) NOT NULL,
	Preco decimal(10, 2) NOT NULL,
	DataAssinatura date NOT NULL
)

SELECT * FROM Assinatura 