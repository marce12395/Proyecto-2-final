CREATE TABLE Usuario
(
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY, 
    correo VARCHAR(50) NOT NULL UNIQUE,      
    clave VARCHAR(20) NOT NULL,              
    nombre VARCHAR(50) NOT NULL              
);


INSERT INTO Usuario (correo, clave, nombre) VALUES ('emurillo', '123', 'Esteban Murillo');
INSERT INTO Usuario (correo, clave, nombre) VALUES ('scarmona', '456', 'Sofia Carmona');
INSERT INTO Usuario (correo, clave, nombre) VALUES ('marce', '2025', 'Mattias Arce');


SELECT * FROM Usuario;


UPDATE Usuario 
SET clave = '789' 
WHERE nombre = 'Sofia Carmona';


DELETE FROM Usuario WHERE correo = 'emurillo';


SELECT * FROM Usuario;



--Tabla de de clientes

DROP TABLE IF EXISTS Cliente;--Para eliminar la trabla y volverla a hacer

CREATE TABLE Cliente (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,              
    Nombre VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL
);


INSERT INTO Cliente (Nombre, CorreoElectronico, Telefono)VALUES ('Esteban Murillo', 'emurillo@correo.com', '8888-1234');

INSERT INTO Cliente (Nombre, CorreoElectronico, Telefono) VALUES ('Sofia Carmona', 'sofia@correo.com', '8888-5678');

SELECT * FROM Cliente WHERE UsuarioID = 1;

DELETE FROM Cliente WHERE UsuarioID = 1;

SELECT * FROM Cliente;




-- Crear tabla Equipos
CREATE TABLE Equipos (
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,   -- Relación con Cliente
    Tipo VARCHAR(50) NOT NULL,
	Modelo VARCHAR(50) NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Cliente(UsuarioID)
);


INSERT INTO Equipos (UsuarioID, Tipo, Modelo)  VALUES (1, 'Laptop','MAC');
SELECT * FROM Equipos;

UPDATE Equipos SET Tipo = 'Celular' WHERE EquipoID = 1;

DELETE FROM Equipos WHERE EquipoID = 2;

--Crear tabla reparaciones

CREATE TABLE Reparaciones (
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT NOT NULL,
    FechaSolicitud DATE NOT NULL,
    Estado VARCHAR(100),
    FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
);

INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (3, '2025-12-13', 'Activo');
SELECT * FROM Reparaciones;
UPDATE Reparaciones SET FechaSolicitud = '2025-12-15', Estado = 'En proceso' WHERE ReparacionID = 1;

DELETE FROM Reparaciones WHERE ReparacionID = 1;

--Creasr tabla Tecnico 
CREATE TABLE Tecnicos (
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Especialidad VARCHAR(50) NOT NULL,   
);


INSERT INTO Tecnicos (Nombre, Especialidad) VALUES ('Carlos Pérez', 'Hardware');

SELECT * FROM Tecnicos;

UPDATE Tecnicos SET Especialidad = 'Software' WHERE TecnicoID = 1;

DELETE FROM Tecnicos WHERE TecnicoID = 1;

--Creasr tabla Tecnico 

CREATE TABLE Asignaciones (
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT NOT NULL,
    TecnicoID INT NOT NULL,
    FechaAsignacion DATE NOT NULL,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
);

INSERT INTO Asignaciones (ReparacionID, TecnicoID) VALUES (1, 4, '2025-12-13');
SELECT * FROM Asignaciones;

UPDATE Asignaciones SET TecnicoID = 2 WHERE AsignacionID = 1;

DELETE FROM Asignaciones WHERE AsignacionID = 1;

--tTabla detalle

CREATE TABLE Detalle (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),   
    ReparacionID INT NOT NULL,                 
    Descripcion VARCHAR(200) NOT NULL,         
    FechaInicio DATE NOT NULL,                 
    FechaFin DATE NULL,                        
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
);

INSERT INTO Detalle (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES (1, 'Diagnóstico  del equipo', '2025-12-15', '2025-12-30');
SELECT * FROM Detalle;

UPDATE Detalle SET Descripcion = 'Diagnóstico final del equipo' WHERE DetalleID = 2;


DELETE FROM Detalle WHERE DetalleID = 4;

