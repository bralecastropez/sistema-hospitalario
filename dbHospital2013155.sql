USE master
GO
DROP DATABASE dbHospital2013155
GO
CREATE DATABASE dbHospital2013155
GO
USE dbHospital2013155
GO
CREATE TABLE Paciente(
	DPI INT NOT NULL,
	noIGSS INT NOT NULL,
	nombre VARCHAR(255) NOT NULL,
	apellido VARCHAR(255) NOT NULL,
	fechaNacimiento DATE NOT NULL,
	PRIMARY KEY (DPI)
)
CREATE TABLE Medico(
	codigoMedico INT NOT NULL,
	nombre VARCHAR (255) NOT NULL,
	apellido VARCHAR(255) NOT NULL,
	PRIMARY KEY(codigoMedico)
)
CREATE TABLE Planta(
	idPlanta INT IDENTITY (1,1) NOT  NULL,
	nombre VARCHAR (255) NOT NULL,
	noCamas INT NOT NULL,
	PRIMARY KEY(idPlanta)
)
CREATE TABLE Cama(
	idCama INT IDENTITY (1,1) NOT NULL,
	idPlanta INT NOT NULL,
	estado Bit NOT NULL,
	PRIMARY KEY (idCama),
	FOREIGN KEY (idPlanta) REFERENCES Planta(idPlanta)
)
CREATE TABLE Cama_Paciente(
	idCama INT NOT NULL,
	DPI INT NOT NULL,
	fecha DATE NOT NULL,
	PRIMARY KEY (idCama, DPI),
	FOREIGN KEY (idCama) REFERENCES Cama(idCama),
	FOREIGN KEY (DPI) REFERENCES Paciente(DPI)
)
CREATE TABLE TarjetaVisita(
	noVisita INT IDENTITY (1,1) NOT NULL,
	DPI INT NOT NULL,
	horaComienzo DATE NOT NULL,
	horaFin DATE NOT NULL,
	PRIMARY KEY(noVisita),
	FOREIGN KEY (DPI) REFERENCES Paciente(DPI)
)
CREATE TABLE Diagnostico(
	codigoDiagnostico INT IDENTITY (1,1) NOT NULL,
	descripcion VARCHAR (255) NOT NULL,
	PRIMARY KEY (codigoDiagnostico)
)
CREATE TABLE Diagnostico_Paciente(
	codigoDiagnostico INT NOT NULL,
	DPI INT NOT NULL,
	fecha DATE NOT NULL,
	PRIMARY KEY (codigoDiagnostico, DPI),
	FOREIGN KEY (DPI) REFERENCES Paciente(DPI),
	FOREIGN KEY (codigoDiagnostico)	 REFERENCES Diagnostico(codigoDiagnostico)
)
CREATE TABLE Diagnostico_Medico(
	codigoMedico INT NOT NULL,
	codigoDiagnostico INT NOT NULL,
	PRIMARY KEY (codigoMedico, codigoDiagnostico),
	FOREIGN KEY (codigoMedico) REFERENCES Medico(codigoMedico),
	FOREIGN KEY (codigoDiagnostico)	 REFERENCES Diagnostico(codigoDiagnostico)
)
CREATE TABLE Medico_Paciente(
	codigoMedico INT NOT NULL,
	DPI INT NOT NULL,
	fecha DATE NOT NULL,
	PRIMARY KEY (codigoMedico, DPI),
	FOREIGN KEY (codigoMedico) REFERENCES Medico(codigoMedico),
	FOREIGN KEY (DPI) REFERENCES Paciente(DPI)
)
INSERT INTO Paciente(DPI, noIGSS, nombre, apellido, fechaNacimiento) VALUES(2013155,12345, 'Brandon','Castro','2013-12-12')
SELECT * FROM Paciente