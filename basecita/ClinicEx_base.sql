DROP DATABASE IF EXISTS ClinicEx_2024;
CREATE DATABASE ClinicEx_2024;
USE ClinicEx_2024;

CREATE TABLE Pacientes (
    PacienteID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50),
    ApellidoP VARCHAR(50),
    ApellidoM VARCHAR(50),
    FechaN DATE,
    Sexo VARCHAR(10)
);

CREATE TABLE Consultas (
    ID_Consulta INT AUTO_INCREMENT PRIMARY KEY,
    PacienteID INT,
    FechaConsulta DATE,
    PresionArterial VARCHAR(10),
    Temperatura DECIMAL(4,2),
    FrecuenciaCardiaca INT,
    FrecuenciaRespiratoria INT,
    Peso DECIMAL(5,2),
    Talla DECIMAL(5,2),
    IMC DECIMAL(5,2),
    CircunferenciaCintura DECIMAL(5,2),
    SaturacionOxigeno DECIMAL(5,2),
    Glucemia DECIMAL(5,2),
    Alergias VARCHAR(45),
    PadecimientoActual TEXT,
    AntecedentesImportancia TEXT,
    HallazgosExploracionFisica TEXT,
    PruebasDiagnosticasRealizadas TEXT,
    PuebasDiagnosticasRealizadas TEXT, 
    Diagnostico TEXT,
    Tratamiento TEXT,
    Pronostico TEXT
);

CREATE TABLE Expendiente (
    ID_Expediente INT AUTO_INCREMENT PRIMARY KEY,
    PacienteID INT,
    ID_Consulta INT,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID),
    FOREIGN KEY (ID_Consulta) REFERENCES Consultas(ID_Consulta)
);


SELECT * FROM Pacientes;
SELECT * FROM Consultas;
