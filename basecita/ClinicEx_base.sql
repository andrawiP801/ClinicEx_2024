drop database if exists ClinicEx_2024;
create database ClinicEx_2024;
use ClinicEx_2024;
CREATE TABLE Pacientes (
    PacienteID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Edad int
);

CREATE TABLE Visitas (
    VisitaID INT AUTO_INCREMENT PRIMARY KEY,
    PacienteID INT,
    FechaConsulta DATE,
    PadecimientoActual TEXT,
    AntecedentesImportancia TEXT,
    HallazgosExploracionFisica TEXT,
    PruebasDiagnosticasRealizadas TEXT,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID)
);

CREATE TABLE SignosVitales (
    SignoVitalID INT AUTO_INCREMENT PRIMARY KEY,
    VisitaID INT,
    Peso DECIMAL(5,2),
    Talla DECIMAL(5,2),
    IMC DECIMAL(5,2),
    CircunferenciaCintura DECIMAL(5,2),
    PresionArterial VARCHAR(10),
    FrecuenciaCardiaca INT,
    FrecuenciaRespiratoria INT,
    Temperatura DECIMAL(4,2),
    SaturacionOxigeno DECIMAL(5,2),
    Glucemia DECIMAL(5,2),
    FOREIGN KEY (VisitaID) REFERENCES Visitas(VisitaID)
);
select* from Pacientes;
select* from Visitas;
