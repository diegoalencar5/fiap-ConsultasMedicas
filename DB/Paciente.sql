USE db_consultas;
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Paciente' and xtype='U') 
	CREATE TABLE Paciente (
		IdPaciente INT PRIMARY KEY IDENTITY,	    
	    Nome VARCHAR(100),
		DtNascimento DATETIME NOT NULL,
		Sexo CHAR(1),
		Endereco VARCHAR(100),
		Email VARCHAR(100),
		Telefone varchar(20),
	);