USE db_consultas;
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Consulta' and xtype='U') 
	CREATE TABLE Consulta (
	    IdConsulta INT PRIMARY KEY IDENTITY,
		IdMedico INT,
		IdPaciente INT,
	    DtConsulta DATETIME NOT NULL,
	    Observacoes VARCHAR(MAX),
	    Inativa BIT NOT NULL	    
	);