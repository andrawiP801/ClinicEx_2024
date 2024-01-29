DROP DATABASE IF EXISTS ClinicEx_2024;
CREATE DATABASE ClinicEx_2024;
USE ClinicEx_2024;

CREATE TABLE Pacientes(
    ID_Paciente INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50),
    ApellidoP VARCHAR(50),
    ApellidoM VARCHAR(50),
    FechaN DATE,
    Sexo VARCHAR(10)
);

CREATE TABLE Consultas (
    ID_Consulta INT AUTO_INCREMENT PRIMARY KEY,
    ID_Paciente INT,
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
    EstadoNutricional varchar(15),
    Alergias VARCHAR(45),
    PadecimientoActual TEXT,
    AntecedentesImportancia TEXT,
    HallazgosExploracionFisica TEXT,
    PruebasDiagnosticasRealizadas TEXT,  
    Diagnostico TEXT,
    Tratamiento TEXT,
    Pronostico TEXT,
    foreign key (ID_Paciente) references Pacientes(ID_Paciente)
);

CREATE TABLE Imagenes (
    ID_Imagen INT AUTO_INCREMENT PRIMARY KEY,
    Imagen LONGBLOB
);


CREATE TABLE Expediente (
    ID_Consulta INT,
    ID_Imagen INT,
    foreign key (ID_Consulta) references Consultas(ID_Consulta),
    foreign key (ID_Imagen) references Imagenes(ID_Imagen)
);

SELECT * FROM Pacientes;
SELECT * FROM Consultas;
SELECT * FROM Imagenes;
SELECT *FROM Expediente;
