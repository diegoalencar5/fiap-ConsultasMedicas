USE db_consultas;
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Medico' and xtype='U') 
	CREATE TABLE Medico (
		IdMedico INT PRIMARY KEY IDENTITY,	    
	    Nome VARCHAR(100),
	);