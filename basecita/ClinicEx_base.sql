drop database if exists ClinicEx_2024;
create database ClinicEx_2024;
use ClinicEx_2024;

CREATE TABLE Pacientes (
    PacienteID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50),
    ApellidoP VARCHAR(50),
    ApellidoM varchar(50),
    FechaN DATE,
    Sexo varchar(10)
);

CREATE TABLE Consultas (
    VisitaID INT AUTO_INCREMENT PRIMARY KEY,
    PacienteID INT,
    FechaConsulta DATE,
    PadecimientoActual TEXT,
    AntecedentesImportancia TEXT,
    HallazgosExploracionFisica TEXT,
    PruebasDiagnosticasRealizadas TEXT,
    PuebasDiagnosticasRealizadas TEXT,
    Diagnostico TEXT,
    Tratamiento TEXT,
    Pronostico TEXT,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID)
);

CREATE TABLE SignosVitales (
    SignoVitalID INT AUTO_INCREMENT PRIMARY KEY,
    VisitaID INT,
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
    Alergias Varchar(45),
    FOREIGN KEY (VisitaID) REFERENCES Consultas(VisitaID)
);

select* from Pacientes;
select * from SignosVitales;
select* from Consultas;
